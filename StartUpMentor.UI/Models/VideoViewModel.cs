using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models
{
    public class VideoViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public string Path { get; set; }
        public DateTime UploadDate { get; set; }

        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }

        public virtual QuestionViewModel Question { get; set; }
        public virtual AnswerViewModel Answer { get; set; }
    }
}