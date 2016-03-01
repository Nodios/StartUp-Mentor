using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Service.Common;
using System;
using System.Security.Cryptography;
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

		public async Task<System.Collections.Generic.IEnumerable<IUser>> GetAllUsers()
		{
			return await Repository.GetAllUsers();
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

        public async Task<IUser> FindAsync(string Email, string password)
        {
            try
            {
				var user = await Repository.GetByEmail(Email);
				if(user != null)
				{
					string passwordHash = await HashPassword(password, user.salt);
					if(user.passwordHash == passwordHash)
					{
						return user;
					}
					else
					{
						return null;
					}
				}
				return null;
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
				user.salt = await GenerateSalt();
				user.passwordHash = await HashPassword(password, user.salt);
				var result = await Repository.RegisterUser(user);
				return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		private async Task<string> GenerateSalt()
		{
			byte[] byteArray = new byte[16];
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			rng.GetBytes(byteArray);
			return Convert.ToBase64String(byteArray);
		}

		private async Task<string> HashPassword(string password,string salt)
		{
			byte[] byteArraySalt = Encoding.Default.GetBytes(salt);

			Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(password, byteArraySalt);
			hasher.IterationCount = 128;
			var test = hasher.GetHashCode();
			var output = Convert.ToBase64String(hasher.GetBytes(64));
			return output;
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
