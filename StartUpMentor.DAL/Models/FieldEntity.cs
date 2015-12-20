using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public class FieldEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        public virtual ICollection<VideoEntity> Videos { get; set; }
    }
}
