﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Factory;
using StartUpMentor.DAL;
using StartUpMentor.Repository.Common.IGenericRepository;
using StartUpMentor.Repository.GenericRepository;
using StartUpMentor.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StartUpMentor.Repository.Common;

namespace StartUpMentor.Repository
{
    //TODO: Build dependencies
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            //Context, generic repository and unit of work
            Bind<IApplicationDbContext>().To<ApplicationDbContext>();
            Bind<IGenericRepository>().To<GenericRepository.GenericRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory();

            //User store and manager
            Bind<UserManager<ApplicationUser>>().ToSelf().WithConstructorArgument(typeof(IUserStore<ApplicationUser>), new UserStore<ApplicationUser>(new ApplicationDbContext()));
            Bind<StartUpMentor.Repository.UserRepository.IUserManagerFactory>().ToFactory();

            //Repository binding
            Bind<IAnswerRepository>().To<AnswerRepository>();
            Bind<IFieldRepository>().To<FieldRepository>();
            Bind<IInfoRepository>().To<InfoRepository>();
            Bind<IQuestionRepository>().To<QuestionRepository>();
            Bind<IVideoRepository>().To<VideoRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IVideoRepository>().To<VideoRepository>();
        }
    }
}
