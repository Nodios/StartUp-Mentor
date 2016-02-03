using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
