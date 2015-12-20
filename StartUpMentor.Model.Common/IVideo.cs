using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
    public interface IVideo
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string Length { get; set; }
        string Path { get; set; }
        DateTime UploadDate { get; set; }

        Guid QuestionId { get; set; }
        Guid AnswerId { get; set; }
        Guid UserId { get; set; }
        Guid FieldId { get; set; }

        IQuestion Question { get; set; }
        IAnswer Answer { get; set; }
        IUser User { get; set; }
        IField Field { get; set; }
    }
}
