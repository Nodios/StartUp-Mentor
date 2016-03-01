using StartUpMentor.Model.Common;

namespace StartUpMentor.Model
{
	public class Info : IInfo
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        //FK for user
        public string UserId { get; set; }

        //One to one
        public virtual IUser User { get; set; }
    }
}
