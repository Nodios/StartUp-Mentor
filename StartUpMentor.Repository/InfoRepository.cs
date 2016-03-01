using StartUpMentor.DAL.Models;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Threading.Tasks;

namespace StartUpMentor.Repository
{
	public class InfoRepository : IInfoRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public InfoRepository(IGenericRepository repository)
        {
            Repository = repository;
        }

        public async Task<IInfo> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IInfo>(await Repository.GetAsync<InfoEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(IInfo info)
        {
            try
            {
                return await Repository.AddAsync<InfoEntity>(AutoMapper.Mapper.Map<InfoEntity>(info));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(IInfo info)
        {
            try
            {
                return await Repository.UpdateAsync<InfoEntity>(AutoMapper.Mapper.Map<InfoEntity>(info));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(IInfo info)
        {
            try
            {
                return await Repository.DeleteAsync<InfoEntity>(AutoMapper.Mapper.Map<InfoEntity>(info));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await Repository.DeleteAsync<InfoEntity>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
