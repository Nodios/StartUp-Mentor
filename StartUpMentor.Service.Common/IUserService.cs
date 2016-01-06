using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Service.Common
{
    public interface IUserService
    {
        Task<IApplicationUser> FindAsync(string username);
        Task<IApplicationUser> FindAsync(string username, string password);
        Task<bool> RegisterUser(IApplicationUser user, string password);
        Task<IApplicationUser> UpdateEmailOrUsernameAsync(IApplicationUser user, string password);
        Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword);
    }
}
