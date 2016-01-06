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

        //Field can have many users - must define UserField table
        public virtual ICollection<IApplicationUser> Users { get; set; }
        //Field can contain many questions
        public virtual ICollection<IQuestion> Questions { get; set; }
    }
}
