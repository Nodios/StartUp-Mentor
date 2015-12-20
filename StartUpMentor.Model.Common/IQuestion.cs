using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
    public interface IQuestion
    {
        Guid Id { get; set; }
        string Title { get; set; }
        string QuestionText { get; set; }
        string UserName { get; set; }
        DateTime Date { get; set; }

        //One to one - Question can be related to one Field
        Guid FieldId { get; set; }
        IField Field { get; set; }

        //One to many - Question can have many Answers
        ICollection<IAnswer> Answers { get; set; }
    }
}
