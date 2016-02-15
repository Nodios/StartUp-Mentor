using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models
{
    public class AnswerViewModel
    {
        public Guid Id { get; set; }
<<<<<<< HEAD
        [Required]
        public string AnswerText { get; set; }
        public string VideoPath { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLastEdited { get; set; }
=======

        public string AnswerText { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4

        //FK for User
        public string UserId { get; set; }
        //One to many - One answer can be posted by a single user
        public virtual UserViewModel User { get; set; }

        //FK for Question
        public Guid QuestionId { get; set; }
        //One Answer is related to one Question
        public virtual QuestionViewModel Question { get; set; }
    }
}