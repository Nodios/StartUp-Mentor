using System.Collections.Generic;
using StartUpMentor.Model.Common;
using System;

namespace StartUpMentor.Model
{
	public class User : IUser
    {
        //One to one relation - User has one Info
        public virtual IInfo Info { get; set; }

        //One to many relation
        //User can be part of many fields
        public virtual ICollection<IField> Fields { get; set; }
        //User can ask many questions
        public virtual ICollection<IQuestion> Questions { get; set; }
        //If mentor - User can have many answers
        public virtual ICollection<IAnswer> Answers { get; set; }

		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string PasswordHash { get; set; }

		public string salt { get; set; }

		public ICollection<IRole> Roles { get; set; }
	}
}
