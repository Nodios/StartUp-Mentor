using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
    public interface IField
    {
        Guid Id { get; set; }
        string Name { get; set; }

        //Field can have many users - must define UserField table
        ICollection<IUser> Users { get; set; }
        //Field can contain many questions
        ICollection<IQuestion> Questions { get; set; }
    }
}
