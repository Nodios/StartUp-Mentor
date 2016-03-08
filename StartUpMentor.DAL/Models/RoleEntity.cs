using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StartUpMentor.DAL.Models
{
	public class RoleEntity
	{
		[Key]
		public Guid id { get; set; }

		public string roleName { get; set; }

		public virtual ICollection<UserEntity> Users { get; set; }
	}
}
