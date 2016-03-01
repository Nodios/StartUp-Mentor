using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model
{
	class Role : IRole
	{
		public Guid Id { get; set; }
		public string roleName { get; set; }
		public ICollection<IUser> Users { get; set; }
	}
}
