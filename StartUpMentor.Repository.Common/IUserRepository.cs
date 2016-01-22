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
        Task<IApplicationUser> GetAsync(string username);
        Task<IEnumerable<IApplicationUser>> GetAsync(Expression<Func<IApplicationUser, bool>> match);
        Task<IApplicationUser> GetAsync(string username, string password);

        Task<int> AddUser(IApplicationUser user);
        Task<bool> RegisterUser(IApplicationUser user, string password);

        Task<int> UpdateAsync(IApplicationUser user);
        Task<IApplicationUser> UpdateUserAsync(IApplicationUser user, string password);
        Task<IApplicationUser> UpdateUserEmailOrUsernameAsync(IApplicationUser user, string password);
        Task<bool> UpdateUserPasswordAsync(string userId, string oldPassword, string newPassword);

        Task<int> DeleteAsync(IApplicationUser user);
        Task<int> DeleteAsync(Guid id);
    }
}
