using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartUpMentor.Model.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace StartUpMentor.Model
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        //One to one relation - User has one Info
        public virtual IInfo Info { get; set; }

        //One to many relation
        //User can be part of many fields
        public virtual ICollection<IField> Fields { get; set; }
        //User can ask many questions
        public virtual ICollection<IQuestion> Questions { get; set; }
        //If mentor - User can have many answers
        public virtual ICollection<IAnswer> Answers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
