using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public class VideoEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public string Path { get; set; }
        public DateTime UploadDate { get; set; }

        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
        public Guid UserId { get; set; }
        public Guid FieldId { get; set; }

        public virtual QuestionEntity Question { get; set; }
        public virtual AnswerEntity Answer { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual FieldEntity Field { get; set; }
    }
}
