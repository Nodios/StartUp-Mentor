using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public class UserEntity : IdentityUser
    {
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(Id))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }
        [Index(IsUnique = true)]
        public override string UserName { get; set; }

        //One to one relation - User has one Info
        public virtual InfoEntity Info { get; set; }

        //One to many relation
        //User can be part of many fields
        public virtual ICollection<FieldEntity> Fields { get; set; }
        //User can ask many questions
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        //If mentor - User can have many answers
        public virtual ICollection<AnswerEntity> Answers { get; set; }

        
    }
}
