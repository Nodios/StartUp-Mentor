using System;
using System.Collections.Generic;

namespace StartUpMentor.DAL.Models
{
    public partial class FieldEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        //Field can have many users - must define UserField table
        public virtual ICollection<UserEntity> Users { get; set; }
        //Field can contain many questions
        public virtual ICollection<QuestionEntity> Questions { get; set; }
    }
}
