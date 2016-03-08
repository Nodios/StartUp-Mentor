using StartUpMentor.Repository.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common.IGenericRepository;
using StartUpMentor.DAL.Models;

namespace StartUpMentor.Repository
{
	class SecurityRepository : ISecurityRepository
	{
		private IGenericRepository Repository { get; set; }
		
		public SecurityRepository(IGenericRepository Repository)
		{
			this.Repository = Repository;
		}

		public async Task<bool> AddToken(ISecurityEntity token)
		{
			var entity = AutoMapper.Mapper.Map<TokenEntity>(token);
            var result = await Repository.AddAsync(entity);
			if(result == 1)
			{
				token = AutoMapper.Mapper.Map<ISecurityEntity>(entity);
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<ISecurityEntity> Get(Guid UserId, string tokenHash)
		{
			var result = Repository.GetWhere<TokenEntity>().Where(t => t.tokenHash == tokenHash && t.UserId == UserId).ToList().DefaultIfEmpty(null).First();
			ISecurityEntity entity = AutoMapper.Mapper.Map<ISecurityEntity>(result);
			return entity;
		}

		public async Task<bool> RemoveToken(Guid UserId, string tokenHash)
		{
			var entity = Repository.GetWhere<TokenEntity>().Where(t => t.tokenHash == tokenHash && t.UserId == UserId).ToList().DefaultIfEmpty(null).First();

			if (entity != null)
			{
				var result = await Repository.DeleteAsync(entity);
				return (result == 1);
			}
			else
			{
				return false;
			}
		}

	}
}
