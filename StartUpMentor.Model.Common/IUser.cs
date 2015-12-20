using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
    public interface IUser
    {
        string Id { get; set; }
        string UserName { get; set; }
        string PasswordHash { get; set; }
        string Email { get; set; }

        //One to one relation
        IInfo Info { get; set; }

        //One to many relation
        ICollection<IField> Fields { get; set; }
        ICollection<IQuestion> Questions { get; set; }
        ICollection<IAnswer> Answers { get; set; }
        ICollection<IVideo> Videos { get; set; }
    }
}
