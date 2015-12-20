using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;

namespace StartUpMentor.Model
{
    public class Field : IField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IUser> Users { get; set; }
        public virtual ICollection<IQuestion> Questions { get; set; }
        public virtual ICollection<IVideo> Videos { get; set; }
    }
}
