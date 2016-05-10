using System;
using System.Collections.Generic;
using StartUpMentor.Model.Common;

namespace StartUpMentor.Model
{
	public class Question : IQuestion
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string VideoPath { get; set; }
        //User that posted question
        public string UserName { get; set; }
        public DateTime Date { get; set; }

		public Guid? QuestionFor { get; set; }

		//FK for Field
		public Guid FieldId { get; set; }
        //One to one - Question can be related to one Field
        public virtual IField Field { get; set; }
        
        //FK for User
        public string UserId { get; set; }
        //One to one - Question is related to only one User
        public virtual IUser User { get; set; }

        //One to many - One Question can have many Answers
        public virtual ICollection<IAnswer> Answers { get; set; }
    }
}
