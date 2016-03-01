using StartUpMentor.Model.Common;
using System.Threading.Tasks;

namespace StartUpMentor.Service.Common
{
	public interface IUserService
    {
        Task<IUser> FindAsync(string username);
        Task<IUser> FindAsync(string username, string password);
        Task<bool> RegisterUser(IUser user, string password);
        Task<IUser> UpdateEmailOrUsernameAsync(IUser user, string password);
        Task<bool> UpdatePasswordAsync(string userId, string oldPassword, string newPassword);
    }
}
