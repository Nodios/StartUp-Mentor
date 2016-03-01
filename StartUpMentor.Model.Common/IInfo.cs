namespace StartUpMentor.Model.Common
{
	public interface IInfo
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Contact { get; set; }

        //FK for user
        string UserId { get; set; }

        //One to one
        IUser User { get; set; }
    }
}
