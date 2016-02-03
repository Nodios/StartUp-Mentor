using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models.Question
{
    public class QuestionAddViewModel
    {
        public Guid FieldId { get; set; }
        public QuestionViewModel QVM { get; set; }
    }
}