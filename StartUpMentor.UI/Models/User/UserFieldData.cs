using System;

namespace StartUpMentor.UI.Models.User
{
	public class UserFieldData
    {
        public Guid FieldId { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }

	public class IndexViewModel
	{
		public bool HasPassword { get; set; }
		//public IList<UserLoginInfo> Logins { get; set; }
		public string PhoneNumber { get; set; }
		public bool TwoFactor { get; set; }
		public bool BrowserRemembered { get; set; }
	}
}