using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        //FK for Field
        public Guid FieldId { get; set; }
        //One to one - Question can be related to one Field
        public virtual FieldViewModel Field { get; set; }

        //One to many - One Question can have many Answers
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}