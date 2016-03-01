using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common
{
	public interface IFieldRepository
    {
        Task<IField> GetAsync(Guid id);
        Task<IEnumerable<IField>> GetRangeAsync(GenericFilter filter = null);

        Task<int> AddAsync(IField field);
        Task<int> UpdateAsync(IField field);
        Task<int> DeleteAsync(IField field);
        Task<int> DeleteAsync(Guid id);
    }
}
