using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartUpMentor.Service
{
	public class FieldService : IFieldService
    {
        protected IFieldRepository Repository { get; private set; }

        public FieldService(IFieldRepository repository)
        {
            Repository = repository;
        }

		public async Task<System.Collections.Generic.IEnumerable<IField>> GetAllFields()
		{
			return await Repository.GetAllFields();
		}

		public async Task<IField> GetAsync(Guid id)
        {
            return await Repository.GetAsync(id);
        }

        public async Task<IEnumerable<IField>> GetRangeAsync(GenericFilter filter = null)
        {
            return await Repository.GetRangeAsync(filter);
        }

        public async Task<int> AddAsnyc(IField field)
        {
            return await Repository.AddAsync(field);
        }

        public async Task<int> UpdateAsync(IField field)
        {
            return await Repository.UpdateAsync(field);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }
    }
}
