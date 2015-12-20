using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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

        //One to one relation
        public virtual InfoEntity Info { get; set; }

        //One to many relation
        public virtual ICollection<FieldEntity> Fields { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        public virtual ICollection<AnswerEntity> Answers { get; set; }
        public virtual ICollection<VideoEntity> Videos { get; set; }
    }
}
