using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Service.Common
{
    public interface IVideoService
    {
        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IVideo> GetAsync(Guid id);
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="video">The video.</param>
        /// <returns></returns>
        Task<int> AddAsync(IVideo video);
        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="video">The video.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(IVideo video);
        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);
    }
}
