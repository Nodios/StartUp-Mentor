using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public class QuestionsAndAnswers : IDataEntity
    {
        public QuestionsAndAnswers()
        {
            if (Id == null)
                Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public string UserName { get; set; }

        public UserEntity User { get; set; }
    }
}
