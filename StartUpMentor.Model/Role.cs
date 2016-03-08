using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;

namespace StartUpMentor.Model
{
	class Role : IRole
	{
		public Guid Id { get; set; }
		public string roleName { get; set; }
		public ICollection<IUser> Users { get; set; }
	}
}
