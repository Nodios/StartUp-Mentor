using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
    public interface IAnswer
    {
        Guid Id { get; set; }

        string AnswerText { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }

        string UserId { get; set; }
        Guid QuestionId { get; set; }

        IUser User { get; set; }
        IQuestion Question { get; set; }
    }
}
