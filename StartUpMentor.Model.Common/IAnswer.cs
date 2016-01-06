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
        
        //FK for User
        string UserId { get; set; }
        //One to many - One answer can be posted by a single user
        IApplicationUser User { get; set; }

        //FK for Question
        Guid QuestionId { get; set; }
        //One Answer is related to one Question
        IQuestion Question { get; set; }
    }
}
