using StartUpMentor.Repository.Common;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StartUpMentor.DAL.Models;
using StartUpMentor.DAL;
using StartUpMentor.Model.Common;
using System.Linq.Expressions;
using StartUpMentor.DAL.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace StartUpMentor.Repository
{
	public class UserRepository : IUserRepository
	{
		protected IGenericRepository Repository { get; private set; }

		public UserRepository(IGenericRepository repository)
		{
			Repository = repository;
		}

		public Task<int> AddUser(IUser user)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(IUser user)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<IUser>> GetAsync(Expression<Func<IUser, bool>> match)
		{
			throw new NotImplementedException();
		}

		public async Task<IUser> GetAsync(string username)
		{
			try
			{
				UserEntity user = Repository.GetWhere<UserEntity>().Where(u => u.UserName == username).ToList().DefaultIfEmpty(null).First();
	
				if (user == null)
				{
					return null;
				}
				else
				{
					return AutoMapper.Mapper.Map<IUser>(user);
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IUser> GetByEmail(string Email)
		{
			try
			{
				UserEntity user = Repository.GetWhere<UserEntity>().Where(e => e.Email == Email).ToList().DefaultIfEmpty(null).First();

				if (user == null)
				{
					return null;
				}
				else
				{
					return AutoMapper.Mapper.Map<IUser>(user);
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task<IUser> GetAsync(string username, string passwordHash)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> RegisterUser(IUser user, string password)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> RegisterUser(IUser user)
		{
			try
			{
				var entityUser = AutoMapper.Mapper.Map<UserEntity>(user);
				entityUser.Id = Guid.NewGuid();

				entityUser.Roles = new System.Collections.ObjectModel.Collection<RoleEntity>();

				var asyncResult = await Repository.AddAsync(entityUser);

				if (asyncResult != 0)
				{
					AutoMapper.Mapper.Map<UserEntity,IUser>(entityUser,user);
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (DbEntityValidationException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task<int> UpdateAsync(IUser user)
		{
			throw new NotImplementedException();
		}

		public Task<IUser> UpdateUserAsync(IUser user, string password)
		{
			throw new NotImplementedException();
		}

		public Task<IUser> UpdateUserEmailOrUsernameAsync(IUser user, string password)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateUserPasswordAsync(string userId, string oldPassword, string newPassword)
		{
			throw new NotImplementedException();
		}
	}

}
