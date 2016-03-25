using System;
using System.Collections.Generic;

namespace StartUpMentor.Model.Common
{
	public interface IField
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string ImagePath { get; set; }

        //Field can have many users - must define UserField table
        ICollection<IUser> Users { get; set; }
        //Field can contain many questions
        ICollection<IQuestion> Questions { get; set; }
    }
}
