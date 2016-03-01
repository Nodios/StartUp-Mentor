
using System.Collections.Generic;

namespace StartUpMentor.UI.Models
{
	public class UserViewModel //: IdentityUser
    {
<<<<<<< HEAD
=======
        public UserViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }

>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4
        public virtual InfoViewModel Info { get; set; }

        public virtual ICollection<FieldViewModel> Fields { get; set; }
        //User can ask many questions
        public virtual ICollection<QuestionViewModel> Questions { get; set; }
        //If mentor - User can have many answers
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}
