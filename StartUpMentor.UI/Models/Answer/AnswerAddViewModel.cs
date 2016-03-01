using System;

namespace StartUpMentor.UI.Models.Answer
{
	public class AnswerAddViewModel
    {
        public Guid QuestionId { get; set; }
        public AnswerViewModel AVM { get; set; }
    }
}