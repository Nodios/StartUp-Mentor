using StartUpMentor.Repository.Common;
using StartUpMentor.Repository.Common.IGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Repository
{
    public class VideoRepository : IVideoRepository
    {
        protected IGenericRepository Repository { get; private set; }

        public VideoRepository(IGenericRepository repository)
        {
            Repository = repository;
        }
        //Pojma nemam kako ovo izvesti!
    }
}
