using StartUpMentor.DAL.Models;
using StartUpMentor.Model.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StartUpMentor.Repository
{
    public class VideoRepository : IVideoRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public VideoRepository(IGenericRepository repository)
        {
            Repository = repository;
        }



        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IVideo> GetAsync(Guid id)
        {
            try
            {
                return AutoMapper.Mapper.Map<IVideo>(await Repository.GetAsync<VideoEntity>(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Uploads the video.
        /// </summary>
        /// <param name="video">The video.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<int> AddAsync(IVideo video)
        {
            try
            {
                return await Repository.AddAsync<VideoEntity>(AutoMapper.Mapper.Map<VideoEntity>(video));
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }


        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="video">The video.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<int> UpdateAsync(IVideo video)
        {
            try
            {
                return await Repository.UpdateAsync<VideoEntity>(AutoMapper.Mapper.Map<VideoEntity>(video));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="video">The video.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<int> DeleteAsync(IVideo video)
        {
            try
            {
                return await Repository.DeleteAsync<VideoEntity>(AutoMapper.Mapper.Map<VideoEntity>(video));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<int> DeleteAsync(Guid id)
        {
            try
            {
                return await Repository.DeleteAsync<VideoEntity>(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
