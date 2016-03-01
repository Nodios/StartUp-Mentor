using System;
using System.Collections.Generic;

namespace StartUpMentor.Model.Common
{
	public interface IQuestion
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string QuestionText { get; set; }
        string VideoPath { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }

        //FK for Field
        Guid FieldId { get; set; }
        //One to one - Question can be related to one Field
        IField Field { get; set; }

        //FK for User
        string UserId { get; set; }
        //One to one - Question is related to one user
        IUser User { get; set; }

        //One to many - One Question can have many Answers
        ICollection<IAnswer> Answers { get; set; }
    }
}
