using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }

        public string AnswerText { get; set; }
        public string VideoPath { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateLastEdited { get; set; }

        //FK for User
        public string UserId { get; set; }
        //One to many - One answer can be posted by a single user
        public virtual UserViewModel User { get; set; }

        //FK for Question
        public Guid QuestionId { get; set; }
        //One Answer is related to one Question
        public virtual QuestionViewModel Question { get; set; }
    }
}