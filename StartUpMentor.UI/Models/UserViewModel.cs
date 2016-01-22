using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models
{
    public class UserViewModel : IdentityUser
    {
        public virtual InfoViewModel Info { get; set; }

        public virtual ICollection<FieldViewModel> Fields { get; set; }
        //User can ask many questions
        public virtual ICollection<QuestionViewModel> Questions { get; set; }
        //If mentor - User can have many answers
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}