using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Service.Common;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace StartUpMentor.Service
{
	public class SecurityService : ISecurityService
	{
		private ISecurityRepository Repository { get; set; }
		private IUserRepository UserRepository { get; set; }
		private ISecurityFactory SecurityFactory { get; set; }

		public SecurityService(ISecurityRepository Repository, IUserRepository UserRepository, ISecurityFactory SecurityFactory)
		{
			this.Repository = Repository;
			this.UserRepository = UserRepository;
			this.SecurityFactory = SecurityFactory;
		}

		public async Task<IUserPrincipal> Authenticate(string token)
		{
			var tokenCookie = await DeserializeToken(token);
			IUser user = await UserRepository.GetAsync(tokenCookie.UserName);

			if (user != null)
			{
				var tokenHash = await HashToken(tokenCookie.token);
				var UserPrincipal = await Authenticate(user.Id, user.UserName, tokenHash);
				UserPrincipal.Roles = AutoMapper.Mapper.Map<ICollection<string>>(user.Roles);
				
				return UserPrincipal;
			}
			else
			{
				return SecurityFactory.CreatePrincipal();
			}
        }

		public async Task<IUserPrincipal> Authenticate (Guid userId, string UserName, string tokenHash)
		{
			var repositoryToken = await Repository.Get(userId, tokenHash);
			IUserIdentity identity;
			
			if(repositoryToken != null && repositoryToken.tokenHash == tokenHash)
			{
				identity = SecurityFactory.CreateIdentity(UserName, true, "TokenAuthentication", null);
			}
			else
			{
				identity = SecurityFactory.CreateIdentity();
			}
			var principal = SecurityFactory.CreatePrincipal(identity);

			return principal;
		}

		public async Task<IUserIdentity> GetIdentity(IUser user, bool isAuthenticated)
		{
			if(user != null)
			{
				return SecurityFactory.CreateIdentity(user.UserName, isAuthenticated, "TokenAuth", AutoMapper.Mapper.Map<ICollection<string>>(user.Roles));
			}
			return SecurityFactory.CreateIdentity();
		}

		public async Task<IUserPrincipal> GetPrincipal(IUserIdentity identity)
		{
			if (identity == null)
            {
				identity = SecurityFactory.CreateIdentity();
			}
			return SecurityFactory.CreatePrincipal(identity);
		}

		public async Task<ISecurityEntity> CreateTokenAsync(Guid UserId, string token)
		{
			var securityToken = SecurityFactory.CreateEntity();
			securityToken.UserId = UserId;
			securityToken.tokenHash = await HashToken(token);
			securityToken.expiryDate = DateTime.Now.AddDays(1);

			if(await Repository.AddToken(securityToken))
			{
				return securityToken;
			}
			else
			{
				return null;
			}
		}

		public async Task<ISecurityEntity> CreateTokenAsync(IUser user, string token)
		{
			return await CreateTokenAsync(user.Id, token); 
		}

		public async Task<ISecurityCookie> CreateTokenCookie(IUser user)
		{
			return await CreateTokenCookie(user.UserName);
		}

		public async Task<ISecurityCookie> CreateTokenCookie(string username)
		{
			var cookie = SecurityFactory.CreateCookie();
			cookie.UserName = username;

			cookie.token = await GenerateToken();

			return cookie;
		}

		public async Task<string> GenerateToken()
		{
			byte[] byteArray = new byte[32];
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			rng.GetBytes(byteArray);
			return Convert.ToBase64String(byteArray);
		}

		public async Task<bool> RemoveTokenAsync(string token)
		{
			var tokenCookie = await DeserializeToken(token);
			var user = await UserRepository.GetAsync(tokenCookie.UserName);
			if(user != null)
			{
				var tokenHash = await HashToken(tokenCookie.token);
				var tokenEntity = Repository.Get(user.Id, tokenHash);
				return await Repository.RemoveToken(user.Id, tokenHash);
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> RemoveTokenAsync(ISecurityEntity token)
		{
			return await RemoveTokenAsync(token.UserId, token.tokenHash);
		}

		public async Task<bool> RemoveTokenAsync(Guid UserId, string tokenHash)
		{
			return await Repository.RemoveToken(UserId, tokenHash);
		}

		public async Task<string> SerializeCookie(ISecurityCookie token)
		{
			var json = JsonConvert.SerializeObject(token);
			return Convert.ToBase64String(Encoding.Default.GetBytes(json));
		}

		public async Task<ISecurityCookie> DeserializeToken(string token)
		{
			ISecurityCookie cookie = SecurityFactory.CreateCookie();
			var json = Encoding.Default.GetString(Convert.FromBase64String(token));
            JsonConvert.PopulateObject(json, cookie);
			return cookie;
		}

		private async Task<string> HashToken(string token)
		{
			byte[] byteArray = Convert.FromBase64String(token);
			System.Security.Cryptography.SHA512Cng hasher = new System.Security.Cryptography.SHA512Cng();
			hasher.ComputeHash(byteArray);
			var output = Convert.ToBase64String(hasher.Hash);
			var size = output.Length;
			return output;
		}
	}
}
