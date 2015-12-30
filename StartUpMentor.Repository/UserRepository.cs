using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StartUpMentor.DAL.Models;
using StartUpMentor.DAL;

namespace StartUpMentor.Repository
{
    public class UserRepository : IUserRepository
    {
        protected IGenericRepository Repository { get; private set; }
        protected IUserManagerFactory UserManagerFactory { get; private set; }

        public UserRepository(IGenericRepository repository, IUserManagerFactory userManagerFactory)
        {
            Repository = repository;
            UserManagerFactory = userManagerFactory;
        }

        #region UserManager
        public UserManager<UserEntity> CreateUserManager()
        {
            return UserManagerFactory.CreateUserManager();
        }

        /// <summary>
        /// Initialize user manager
        /// </summary>
        /// <returns>new user manager</returns>
        private UserManager<UserEntity> createUserManager()
        {
            return new UserManager<UserEntity>(new UserStore<UserEntity>(new ApplicationDbContext()));
        }
        #endregion

        public async Task<StartUpMentor.Model.Common.IUser> GetAsync(string username)
        {
            try
            {
                return AutoMapper.Mapper.Map<Model.Common.IUser>(await Repository.GetAsync<UserEntity>(u => u.UserName.Equals(username)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Model.Common.IUser>> GetAsync(System.Linq.Expressions.Expression<Func<Model.Common.IUser, bool>> match)
        {
            try
            {
                return AutoMapper.Mapper.Map<IEnumerable<StartUpMentor.Model.Common.IUser>>(await Repository.GetRangeAsync<UserEntity>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Common.IUser> GetAsync(string username, string password)
        {
            try
            {
                UserManager<UserEntity> userManager = CreateUserManager();

                UserEntity user = await userManager.FindAsync(username, password);

                return AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IUser>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUser(Model.Common.IUser user)
        {
            try
            {
                return await Repository.AddAsync<UserEntity>(AutoMapper.Mapper.Map<UserEntity>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RegisterUser(Model.Common.IUser user, string password)
        {
            try
            {
                UserManager<UserEntity> userManager = this.CreateUserManager();
                IdentityResult result = await userManager.CreateAsync(AutoMapper.Mapper.Map<UserEntity>(user), password);

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(Model.Common.IUser user)
        {
            try
            {
                return await Repository.UpdateAsync<UserEntity>(AutoMapper.Mapper.Map<UserEntity>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Common.IUser> UpdateUserAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<UserEntity> result = null;

                UserManager<UserEntity> UserManager = CreateUserManager();

                UserEntity userToCheck = await UserManager.FindByIdAsync(user.Id);
                passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);

                if (passwordValid)
                    result = uow.UpdateWithAddAsync<UserEntity>(AutoMapper.Mapper.Map<UserEntity>(user));
                else
                    throw new Exception("Invalid password");

                await uow.CommitAsync();
                return await Task.FromResult(AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IUser>(result.Result) as StartUpMentor.Model.Common.IUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Common.IUser> UpdateUserEmailOrUsernameAsync(Model.Common.IUser user, string password)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<UserEntity> result = null;

                UserManager<UserEntity> UserManager = CreateUserManager();

                UserEntity userToCheck = await UserManager.FindByIdAsync(user.Id);
                passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);

                if (passwordValid)
                    result = uow.UpdateWithAddAsync<UserEntity>(AutoMapper.Mapper.Map<UserEntity>(user), u => u.Email, u => u.UserName);
                else
                    throw new Exception("Invalid password");

                await uow.CommitAsync();
                return await Task.FromResult(AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IUser>(result.Result) as StartUpMentor.Model.Common.IUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUserPasswordAsync(string userId, string oldPassword, string newPassword)
        {
            try
            {
                UserManager<UserEntity> UserManager = CreateUserManager();
                IdentityResult result = await UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(Model.Common.IUser user)
        {
            try
            {
                return await Repository.DeleteAsync<UserEntity>(AutoMapper.Mapper.Map<UserEntity>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await this.DeleteAsync(AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IUser>(await Repository.GetAsync<UserEntity>(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public interface IUserManagerFactory
        {
            UserManager<UserEntity> CreateUserManager();
        }
    }
}
