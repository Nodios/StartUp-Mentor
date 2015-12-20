using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public class QuestionEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        //One to one - Question can be related to one Field and have one Video
        public Guid FieldId { get; set; }
        public FieldEntity Field { get; set; }
        public Guid VideoId { get; set; }
        public VideoEntity Video { get; set; }

        //One to many - Question can have many Answers
        public ICollection<AnswerEntity> Answers { get; set; }
    }
}
