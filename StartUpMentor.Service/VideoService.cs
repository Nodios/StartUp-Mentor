using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Service
{
    public class VideoService : IVideoService
    {
        protected IVideoRepository Repository { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public VideoService(IVideoRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IVideo> GetAsync(Guid id)
        {
            return await Repository.GetAsync(id);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="video">The video.</param>
        /// <returns></returns>
        public async Task<int> AddAsync(IVideo video)
        {
            return await Repository.AddAsync(video);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="video">The video.</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(IVideo video)
        {
            return await Repository.UpdateAsync(video);
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            return await Repository.DeleteAsync(id);
        }
    }
}
