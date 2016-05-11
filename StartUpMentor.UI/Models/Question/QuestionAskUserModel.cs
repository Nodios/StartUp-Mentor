using System;
using System.Collections.Generic;

namespace StartUpMentor.UI.Models.Question
{
	public class QuestionAskUserModel
	{
        public Guid FieldId { get; set; }
		public Guid UserId { get; set; }
        public string Title { get; set; }
		public string QuestionText { get; set; }
		public IEnumerable<StartUpMentor.Model.Common.IField> FieldList { get; set; }
    }
}