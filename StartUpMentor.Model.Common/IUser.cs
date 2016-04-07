using System;
using System.Collections.Generic;

namespace StartUpMentor.Model.Common
{
	public interface IUser
    {

        Guid Id { get; set; }

		string UserName { get; set; }

		string FirstName { get; set; }

		string LastName { get; set; }

		string Email { get; set; }

		string PasswordHash { get; set; }

		string salt { get; set; }

        //One to one relation - User has one Info
        IInfo Info { get; set; }

        //One to many relation
        //User can be part of many fields
        ICollection<IField> Fields { get; set; }
        //User can ask many questions
        ICollection<IQuestion> Questions { get; set; }
        //If mentor - User can have many answers
        ICollection<IAnswer> Answers { get; set; }

		ICollection<IRole> Roles { get; set; }
    }
}
