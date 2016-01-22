using System;
using System.Collections.Generic;

namespace StartUpMentor.DAL.Models
{
    public partial class QuestionEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string QuestionText { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        //FK for Field
        public Guid FieldId { get; set; }
        //One to one - Question can be related to one Field
        public virtual FieldEntity Field { get; set; }

        //FK for Video
        public Guid VideoId { get; set; }
        //One to one - question can have only one Video
        public virtual VideoEntity Video { get; set; }

        //Fk for User
        public string UserId { get; set; }
        //One to one - Question is related to only one User
        public virtual ApplicationUser User { get; set; }

        //One to many - One Question can have many Answers
        public virtual ICollection<AnswerEntity> Answers { get; set; }
    }
}
