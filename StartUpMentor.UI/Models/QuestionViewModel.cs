using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models
{
    public class QuestionViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public string VideoPath { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        //FK for Field
        public Guid FieldId { get; set; }
        //One to one - Question can be related to one Field
        public virtual FieldViewModel Field { get; set; }

        //Fk for User
        public string UserId { get; set; }
        //One to one - Question is related to only one User
        public virtual UserViewModel User { get; set; }

        //One to many - One Question can have many Answers
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}