using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;

namespace StartUpMentor.Model
{
    public class Question : IQuestion
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        //One to one - Question can be related to one Field
        public Guid FieldId { get; set; }
        public IField Field { get; set; }
        public Guid VideoId { get; set; }
        public IVideo Video { get; set; }

        //One to many - Question can have many Answers
        public ICollection<IAnswer> Answers { get; set; }
    }
}
