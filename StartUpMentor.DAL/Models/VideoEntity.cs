using System;
using System.Collections.Generic;

namespace StartUpMentor.DAL.Models
{
    public partial class VideoEntity
    {
        public System.Guid Id { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public string Path { get; set; }
        public System.DateTime UploadDate { get; set; }
        public System.Guid QuestionId { get; set; }
        public System.Guid AnswerId { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid FieldId { get; set; }
    }
}
