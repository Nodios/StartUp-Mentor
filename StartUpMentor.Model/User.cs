using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StartUpMentor.Model
{
    public class User : IdentityUser, IUser
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
        public virtual IInfo Info { get; set; }

        //One to many relation
        public virtual ICollection<IField> Fields { get; set; }
        public virtual ICollection<IQuestion> Questions { get; set; }
        public virtual ICollection<IAnswer> Answers { get; set; }
        public virtual ICollection<IVideo> Videos { get; set; }
    }
}
