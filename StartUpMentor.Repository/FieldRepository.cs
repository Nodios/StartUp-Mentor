using StartUpMentor.Common.Filters;
using StartUpMentor.DAL.Models;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace StartUpMentor.Repository
{
    public class FieldRepository : IFieldRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public FieldRepository(IGenericRepository repository)
        {
            Repository = repository;
        }

        public async Task<IField> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IField>(await Repository.GetAsync<FieldEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IField>> GetRangeAsync(GenericFilter filter = null)
        {
            try
            {
                if (filter != null)
                {
                    //Fetch all fields
                    var fields = AutoMapper.Mapper.Map<IEnumerable<IField>>(await Repository.GetRangeAsync<FieldEntity>()).OrderBy(f => f.Name).ToList();
                    //search by field name
                    if (!string.IsNullOrWhiteSpace(filter.SearchString))
                    {
                        //filter only those matching filter.SearchString from fields
                        //Search by Name of the field
                        fields = fields.Where(f => f.Name.ToLower().Contains(filter.SearchString.ToLower())).ToList();
                    }
                    //Page fields
                    var paged = fields.ToPagedList(filter.PageNumber, filter.PageSize);
                    var fieldsPagedList = new StaticPagedList<IField>(paged, paged.GetMetaData());
                    return fieldsPagedList;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<IField>>(Repository.GetRangeAsync<FieldEntity>()).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> AddAsync(IField field)
        {
            try
            {
                return Repository.AddAsync<FieldEntity>(AutoMapper.Mapper.Map<FieldEntity>(field));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> UpdateAsync(IField field)
        {
            try
            {
                return Repository.UpdateAsync<FieldEntity>(AutoMapper.Mapper.Map<FieldEntity>(field));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> DeleteAsync(IField field)
        {
            try
            {
                return Repository.DeleteAsync<FieldEntity>(AutoMapper.Mapper.Map<FieldEntity>(field));
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
                return await Repository.DeleteAsync<FieldEntity>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
