using StartUpMentor.Model.Common;
using System;

namespace StartUpMentor.UI.Models.Answer
{
	public class AnswerIndexViewModel
    {
        public Guid QuestionId { get; set; }
        public PagedList.IPagedList<StartUpMentor.Model.Common.IAnswer> AnswerList { get; set; }
        public IQuestion Question { get; set; }
    }
}