using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public override string Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                if (String.IsNullOrEmpty(Id))
                    base.Id = Guid.NewGuid().ToString();
                else
                    base.Id = value;
            }
        }

        [Index(IsUnique = true)]
        public override string UserName { get; set; }

        //One to one relation - User has one Info
        public virtual InfoEntity Info { get; set; }

        //One to many relation
        //User can be part of many fields
        public virtual ICollection<FieldEntity> Fields { get; set; }
        //User can ask many questions
        public virtual ICollection<QuestionEntity> Questions { get; set; }
        //If mentor - User can have many answers
        public virtual ICollection<AnswerEntity> Answers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
