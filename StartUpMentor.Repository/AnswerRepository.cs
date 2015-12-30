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
    public class AnswerRepository : IAnswerRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public AnswerRepository(IGenericRepository repository)
        {
            Repository = repository;
        }

        public async Task<IAnswer> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IAnswer>(await Repository.GetAsync<AnswerEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAnswer>> GetAsync(GenericFilter filter)
        {
            try
            {
                if (filter != null)
                {
                    var answers = AutoMapper.Mapper.Map<IEnumerable<IAnswer>>(await Repository.GetRangeAsync<AnswerEntity>()).ToList();

                    if (!string.IsNullOrWhiteSpace(filter.SearchString))
                    {
                        answers = answers.Where(a => a.Date.ToShortDateString().Contains(filter.SearchString)).ToList();
                    }

                    var page = answers.ToPagedList(filter.PageNumber, filter.PageSize);
                    var answerPagedList = new StaticPagedList<IAnswer>(page, page.GetMetaData());
                    return answerPagedList;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<IAnswer>>(await Repository.GetRangeAsync<AnswerEntity>()).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IAnswer>> GetRangeAsync(Guid questionId, GenericFilter filter)
        {
            try
            {
                if (filter != null)
                {
                    var answers = AutoMapper.Mapper.Map<IEnumerable<IAnswer>>(await Repository.GetWhere<AnswerEntity>().Where(a => a.QuestionId.Equals(questionId)).ToListAsync());

                    var page = answers.ToPagedList(filter.PageNumber, filter.PageSize);
                    var answersPagedList = new StaticPagedList<IAnswer>(page, page.GetMetaData());
                    return answersPagedList;
                }
                else
                {
                    return AutoMapper.Mapper.Map<IEnumerable<IAnswer>>(await Repository.GetRangeAsync<AnswerEntity>()).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> AddAsync(IAnswer answer)
        {
            try
            {
                return await Repository.AddAsync<AnswerEntity>(AutoMapper.Mapper.Map<AnswerEntity>(answer));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateAsync(IAnswer answer)
        {
            try
            {
                return await Repository.UpdateAsync<AnswerEntity>(AutoMapper.Mapper.Map<AnswerEntity>(answer));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteAsync(IAnswer answer)
        {
            try
            {
                return await Repository.DeleteAsync<AnswerEntity>(AutoMapper.Mapper.Map<AnswerEntity>(answer));
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
                return await Repository.DeleteAsync<AnswerEntity>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
