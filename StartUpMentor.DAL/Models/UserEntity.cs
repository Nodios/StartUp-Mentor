using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartUpMentor.DAL.Models
{
	public class UserEntity
    {
		[Key]
		public Guid Id { get; set; }

		[Index(IsUnique = true)]
		[StringLength(64)]
		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string passwordHash { get; set; }

		public string salt { get; set; }

        //One to one relation - User has one Info
        public virtual InfoEntity Info { get; set; }

        //One to many relation
        //User can be part of many fields
        public virtual ICollection<FieldEntity> Fields { get; set; }
        //User can ask many questions
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        //If mentor - User can have many answers
        public virtual ICollection<AnswerEntity> Answers { get; set; }

		public virtual ICollection<RoleEntity> Roles { get; set; }
    }
}
