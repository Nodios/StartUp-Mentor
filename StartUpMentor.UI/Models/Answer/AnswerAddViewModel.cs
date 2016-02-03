using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models.Answer
{
    public class AnswerAddViewModel
    {
        public Guid QuestionId { get; set; }
        public AnswerViewModel AVM { get; set; }
    }
}