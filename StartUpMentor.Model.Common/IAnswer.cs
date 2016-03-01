using System;

namespace StartUpMentor.Model.Common
{
	public interface IAnswer
    {
        Guid Id { get; set; }

        string AnswerText { get; set; }
        string VideoPath { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }
        DateTime DateLastEdited { get; set; }
        
        //FK for User
        string UserId { get; set; }
        //One to many - One answer can be posted by a single user
        IUser User { get; set; }

        //FK for Question
        Guid QuestionId { get; set; }
        //One Answer is related to one Question
        IQuestion Question { get; set; }
    }
}
