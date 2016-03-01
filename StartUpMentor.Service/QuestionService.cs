using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartUpMentor.Service
{
	public class QuestionService : IQuestionService
    {
        protected IQuestionRepository Repository { get; private set; }

        public QuestionService(IQuestionRepository repository)
        {
            Repository = repository;
        }

        public async Task<IQuestion> GetAsync(Guid id)
        {
            return await Repository.GetAsync(id);
        }

        public async Task<IEnumerable<IQuestion>> GetRangeAsync(Guid fieldId, GenericFilter filter)
        {
            return await Repository.GetRangeAsync(fieldId, filter);
        }

        public async Task<int> AddAsync(IQuestion question)
        {
            return await Repository.AddAsync(question);
        }

        public async Task<int> UpdateAsync(IQuestion question)
        {
            return await Repository.UpdateAsync(question);
        }

        public async Task<int> DeleteAsync(IQuestion question)
        {
            return await Repository.DeleteAsync(question);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }
    }
}
