using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public interface IDataEntity
    {
        Guid Id { get; set; }
    }
}
