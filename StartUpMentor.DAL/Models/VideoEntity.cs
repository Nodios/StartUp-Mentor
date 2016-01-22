using System;
using System.Collections.Generic;

namespace StartUpMentor.DAL.Models
{
    public partial class VideoEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public string Path { get; set; }
        public DateTime UploadDate { get; set; }

        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }

        public virtual QuestionEntity Question { get; set; }
        public virtual AnswerEntity Answer { get; set; }
    }
}
