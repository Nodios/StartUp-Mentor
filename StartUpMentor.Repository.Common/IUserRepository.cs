using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common
{
	public interface IUserRepository
    {
		Task<IEnumerable<IUser>> GetAllUsers();
        Task<IUser> GetAsync(string username);
        Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match);
		Task<IUser> GetAsync(string username, string passwordHash);
		Task<IUser> GetByEmail(string Email);

		Task<int> AddUser(IUser user);
        Task<bool> RegisterUser(IUser user, string password);
		Task<bool> RegisterUser(IUser user);

        Task<int> UpdateAsync(IUser user);
        Task<IUser> UpdateUserAsync(IUser user, string password);
        Task<IUser> UpdateUserEmailOrUsernameAsync(IUser user, string password);
        Task<bool> UpdateUserPasswordAsync(string userId, string oldPassword, string newPassword);

        Task<int> DeleteAsync(IUser user);
        Task<int> DeleteAsync(Guid id);
    }
}
