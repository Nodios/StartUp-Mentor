using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartUpMentor.Service
{
	public class AnswerService : IAnswerService
    {
        protected IAnswerRepository Repository { get; private set; }

        public AnswerService(IAnswerRepository repository)
        {
            Repository = repository;
        }

        public async Task<IAnswer> GetAsync(Guid id)
        {
            return await Repository.GetAsync(id);
        }

        public async Task<IEnumerable<IAnswer>> GetRangeAsync(Guid questionId, GenericFilter filter)
        {
            return await Repository.GetRangeAsync(questionId, filter);
        }

        public async Task<int> AddAsync(IAnswer answer)
        {
            return await Repository.AddAsync(answer);
        }

        public async Task<int> UpdateAsync(IAnswer answer)
        {
            return await Repository.UpdateAsync(answer);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }
    }
}
