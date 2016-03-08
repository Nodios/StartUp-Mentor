using System;
using System.Collections.Generic;

namespace StartUpMentor.Model.Common
{
	public interface IRole
	{
		Guid Id { get; set; }
		string roleName { get; set; }
		ICollection<IUser> Users { get; set; }
	}
}
