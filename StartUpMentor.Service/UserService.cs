using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Service
{
    public class UserService : IUserService
    {
        protected IUserRepository Repository { get; private set; }

        public UserService(IUserRepository repository)
        {
            Repository = repository;
        }

        public async Task<IUser> FindAsync(string username)
        {
            try
            {
                return await Repository.GetAsync(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IUser> FindAsync(string username, string password)
        {
            try
            {
                return await Repository.GetAsync(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RegisterUser(IUser user, string password)
        {
            try
            {
                return await Repository.RegisterUser(user, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IUser> UpdateEmailOrUsernameAsync(IUser user, string password)
        {
            try
            {
                return await Repository.UpdateUserEmailOrUsernameAsync(user, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            try
            {
                return await Repository.UpdateUserPasswordAsync(userId, oldPassword, newPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
