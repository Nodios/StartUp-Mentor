using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common
{
    public interface IUserRepository
    {
        Task<IUser> GetAsync(string username);
        Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match);
        Task<IUser> GetAsync(string username, string password);

        Task<int> AddUser(IUser user);
        Task<bool> RegisterUser(IUser user, string password);

        Task<int> UpdateAsync(IUser user);
        Task<IUser> UpdateUserAsync(IUser user, string password);
        Task<IUser> UpdateUserEmailOrUsernameAsync(IUser user, string password);
        Task<bool> UpdateUserPasswordAsync(string userId, string oldPassword, string newPassword);

        Task<int> DeleteAsync(IUser user);
        Task<int> DeleteAsync(Guid id);
    }
}
