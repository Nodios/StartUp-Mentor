using Ninject.Extensions.Factory;
using StartUpMentor.DAL;
using StartUpMentor.Repository.Common.IGenericRepository;
using StartUpMentor.Repository.GenericRepository;
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
		 /*
            //User store and manager
            Bind<UserManager<ApplicationUser>>().ToSelf().WithConstructorArgument(typeof(IUserStore<ApplicationUser>), new UserStore<ApplicationUser>(new ApplicationDbContext()));
            Bind<StartUpMentor.Repository.UserRepository.IUserManagerFactory>().ToFactory();
		 */

            //Repository binding
            Bind<IAnswerRepository>().To<AnswerRepository>();
            Bind<IFieldRepository>().To<FieldRepository>();
            Bind<IInfoRepository>().To<InfoRepository>();
            Bind<IQuestionRepository>().To<QuestionRepository>();
            Bind<IUserRepository>().To<UserRepository>();
			Bind<ISecurityRepository>().To<SecurityRepository>();

        }
    }
}
