using System;

namespace StartUpMentor.UI.Models
{
	public class InfoViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        //FK for user
        public string UserId { get; set; }

        //One to one
        public virtual UserViewModel User { get; set; }
    }
}