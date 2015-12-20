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
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public Guid QuestionId { get; set; }

        public virtual IUser User { get; set; }
        public virtual IQuestion Question { get; set; }
    }
}
