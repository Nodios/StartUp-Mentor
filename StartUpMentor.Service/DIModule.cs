using StartUpMentor.Service.Common;

namespace StartUpMentor.Service
{
	public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IAnswerService>().To<AnswerService>();
            Bind<IFieldService>().To<FieldService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<IUserService>().To<UserService>();
			Bind<ISecurityService>().To<SecurityService>();
        }
    }
}
