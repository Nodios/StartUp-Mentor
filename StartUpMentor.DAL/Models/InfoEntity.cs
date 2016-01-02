using System;
using System.Collections.Generic;

namespace StartUpMentor.DAL.Models
{
    public partial class InfoEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        //FK for user
        public string UserId { get; set; }

        //One to one
        public virtual UserEntity User { get; set; }
    }
}
