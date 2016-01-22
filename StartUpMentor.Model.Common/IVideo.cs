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
        byte[] VideoFile { get; set; }

        //FK for Question
        Guid QuestionId { get; set; }
        //One Video is related to one Question
        IQuestion Question { get; set; }

        //FK for Answer
        Guid AnswerId { get; set; }
        //One Video is related to one Question
        IAnswer Answer { get; set; }
    }
}
