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

        //One to one relation - User has one Info
        IInfo Info { get; set; }

        //One to many relation
        //User can be part of many fields
        ICollection<IField> Fields { get; set; }
        //User can ask many questions
        ICollection<IQuestion> Questions { get; set; }
        //If mentor - User can have many answers
        ICollection<IAnswer> Answers { get; set; }
    }
}
