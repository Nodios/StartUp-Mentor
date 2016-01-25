using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Service.Common
{
    public interface IFieldService
    {
        Task<IField> GetAsync(Guid id);
        Task<IEnumerable<IField>> GetRangeAsync(GenericFilter filter = null);
        Task<int> AddAsnyc(IField field);
        Task<int> UpdateAsync(IField field);
        Task<int> DeleteAsync(Guid id);
    }
}
