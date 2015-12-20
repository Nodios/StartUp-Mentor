using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;

namespace StartUpMentor.Model
{
    public class Video : IVideo
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

        public virtual IQuestion Question { get; set; }
        public virtual IAnswer Answer { get; set; }
        public virtual IUser User { get; set; }
        public virtual IField Field { get; set; }
    }
}
