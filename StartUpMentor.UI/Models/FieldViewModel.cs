using System;
using System.Collections.Generic;

namespace StartUpMentor.UI.Models
{
	public class FieldViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        //Field can have many users - must define UserField table
        public virtual ICollection<UserViewModel> Users { get; set; }
        //Field can contain many questions
        public virtual ICollection<QuestionViewModel> Questions { get; set; }
    }
}