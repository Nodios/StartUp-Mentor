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
using System.Data.Entity;
using PagedList;

namespace StartUpMentor.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public QuestionRepository(IGenericRepository repository)
        {
            Repository = repository;
        }

        public async Task<IQuestion> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IQuestion>(await Repository.GetAsync<QuestionEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IQuestion>> GetRangeAsync(Guid fieldId, GenericFilter filter)
        {
            try
            {
                if (filter != null)
                {
                    //Get all questions from a field with matching id
                    //var questions = AutoMapper.Mapper.Map<IEnumerable<IQuestion>>(await Repository.GetAsync<QuestionEntity>(q => q.Field.Id.Equals(fieldId)));
                    var questions = AutoMapper.Mapper.Map<IEnumerable<IQuestion>>(await Repository.GetWhere<QuestionEntity>().Where(q => q.FieldId.Equals(fieldId)).ToListAsync());

                    if (!string.IsNullOrWhiteSpace(filter.SearchString))
                    {
                        questions = questions.Where(q => q.Title.ToLower().Contains(filter.SearchString.ToLower())).ToList();
                    }

                    var page = questions.ToPagedList(filter.PageNumber, filter.PageSize);
                    var questionPagedList = new StaticPagedList<IQuestion>(page, page.GetMetaData());
                    return questionPagedList;
                }
                else
                {
                    //If filter is null, return all questions from field
                    return AutoMapper.Mapper.Map<IEnumerable<IQuestion>>(await Repository.GetAsync<QuestionEntity>(q => q.Field.Id.Equals(fieldId))).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(IQuestion question)
        {
            try
            {
                return await Repository.AddAsync<QuestionEntity>(AutoMapper.Mapper.Map<QuestionEntity>(question));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(IQuestion question)
        {
            try
            {
                return await Repository.UpdateAsync<QuestionEntity>(AutoMapper.Mapper.Map<QuestionEntity>(question));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(IQuestion question)
        {
            try
            {
                return await Repository.DeleteAsync<QuestionEntity>(AutoMapper.Mapper.Map<QuestionEntity>(question));
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
                return await Repository.DeleteAsync<QuestionEntity>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
