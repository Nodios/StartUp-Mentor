using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public class AnswerEntity
    {
        public Guid Id { get; set; }

        public string AnswerText { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public Guid QuestionId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual QuestionEntity Question { get; set; }
    }
}
