using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;

namespace StartUpMentor.Model
{
    public class Answer : IAnswer
    {
        public Guid Id { get; set; }

        public string AnswerText { get; set; }
        public string VideoPath { get; set; }
        //User that answered question
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateLastEdited { get; set; }

        //FK for User
        public string UserId { get; set; }
        //One to many - One answer can be posted by a single user
        public virtual IApplicationUser User { get; set; }

        //FK for Question
        public Guid QuestionId { get; set; }
        //One Answer is related to one Question
        public virtual IQuestion Question { get; set; }
    }
}
