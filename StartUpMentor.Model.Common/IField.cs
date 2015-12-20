using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Model.Common
{
    public interface IField
    {
        Guid Id { get; set; }
        string Name { get; set; }

        ICollection<IUser> Users { get; set; }
        ICollection<IQuestion> Questions { get; set; }
        ICollection<IVideo> Videos { get; set; }
    }
}
