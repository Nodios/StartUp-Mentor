using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
	public interface IRole
	{
		Guid Id { get; set; }
		string roleName { get; set; }
		ICollection<IUser> Users { get; set; }
	}
}
