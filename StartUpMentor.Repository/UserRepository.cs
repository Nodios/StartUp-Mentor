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
        public UserManager<ApplicationUser> CreateUserManager()
        {
            return UserManagerFactory.CreateUserManager();
        }

        /// <summary>
        /// Initialize user manager
        /// </summary>
        /// <returns>new user manager</returns>
        private UserManager<ApplicationUser> createUserManager()
        {
            return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
        #endregion

        public async Task<StartUpMentor.Model.Common.IApplicationUser> GetAsync(string username)
        {
            try
            {
                return AutoMapper.Mapper.Map<Model.Common.IApplicationUser>(await Repository.GetAsync<ApplicationUser>(u => u.UserName.Equals(username)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Model.Common.IApplicationUser>> GetAsync(System.Linq.Expressions.Expression<Func<Model.Common.IApplicationUser, bool>> match)
        {
            try
            {
                return AutoMapper.Mapper.Map<IEnumerable<StartUpMentor.Model.Common.IApplicationUser>>(await Repository.GetRangeAsync<ApplicationUser>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Common.IApplicationUser> GetAsync(string username, string password)
        {
            try
            {
                UserManager<ApplicationUser> userManager = CreateUserManager();

                ApplicationUser user = await userManager.FindAsync(username, password);

                return AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IApplicationUser>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddUser(Model.Common.IApplicationUser user)
        {
            try
            {
                return await Repository.AddAsync<ApplicationUser>(AutoMapper.Mapper.Map<ApplicationUser>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RegisterUser(Model.Common.IApplicationUser user, string password)
        {
            try
            {
                UserManager<ApplicationUser> userManager = this.CreateUserManager();
                IdentityResult result = await userManager.CreateAsync(AutoMapper.Mapper.Map<ApplicationUser>(user), password);

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(Model.Common.IApplicationUser user)
        {
            try
            {
                return await Repository.UpdateAsync<ApplicationUser>(AutoMapper.Mapper.Map<ApplicationUser>(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Common.IApplicationUser> UpdateUserAsync(Model.Common.IApplicationUser user, string password)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<ApplicationUser> result = null;

                UserManager<ApplicationUser> UserManager = CreateUserManager();

                ApplicationUser userToCheck = await UserManager.FindByIdAsync(user.Id);
                passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);

                if (passwordValid)
                    result = uow.UpdateWithAddAsync<ApplicationUser>(AutoMapper.Mapper.Map<ApplicationUser>(user));
                else
                    throw new Exception("Invalid password");

                await uow.CommitAsync();
                return await Task.FromResult(AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IApplicationUser>(result.Result) as StartUpMentor.Model.Common.IApplicationUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Model.Common.IApplicationUser> UpdateUserEmailOrUsernameAsync(Model.Common.IApplicationUser user, string password)
        {
            try
            {
                IUnitOfWork uow = Repository.CreateUnitOfWork();
                bool passwordValid = false;
                Task<ApplicationUser> result = null;

                UserManager<ApplicationUser> UserManager = CreateUserManager();

                ApplicationUser userToCheck = await UserManager.FindByIdAsync(user.Id);
                passwordValid = await UserManager.CheckPasswordAsync(userToCheck, password);

                if (passwordValid)
                    result = uow.UpdateWithAddAsync<ApplicationUser>(AutoMapper.Mapper.Map<ApplicationUser>(user), u => u.Email, u => u.UserName);
                else
                    throw new Exception("Invalid password");

                await uow.CommitAsync();
                return await Task.FromResult(AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IApplicationUser>(result.Result) as StartUpMentor.Model.Common.IApplicationUser);
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
                UserManager<ApplicationUser> UserManager = CreateUserManager();
                IdentityResult result = await UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);

                return result.Succeeded;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(Model.Common.IApplicationUser user)
        {
            try
            {
                return await Repository.DeleteAsync<ApplicationUser>(AutoMapper.Mapper.Map<ApplicationUser>(user));
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
                return await this.DeleteAsync(AutoMapper.Mapper.Map<StartUpMentor.Model.Common.IApplicationUser>(await Repository.GetAsync<ApplicationUser>(id)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public interface IUserManagerFactory
        {
            UserManager<ApplicationUser> CreateUserManager();
        }
    }
}
