using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using StartUpMentor.DAL.Models;

namespace StartUpMentor.DAL
{
    public class StartUpMentorInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string name = "Admin";
            //string password = "123456";
            string email = "admin@admin.com";

            //var userInfo = new InfoEntity()
            //{
            //    FirstName = "Dino",
            //    LastName = "Repac",
            //    Contact = "0955833733"
            //};
            //context.Info.Add(userInfo);
            //context.SaveChanges();

            if (!RoleManager.RoleExists(name))
            {
                var roleResult = RoleManager.Create(new IdentityRole(name));
            }

            //var user = new ApplicationUser()
            //{
            //    UserName = name,
            //    Email = email,
            //    Info = userInfo
            //};

            //var result = UserManager.Create(user, password);

            //if (result.Succeeded)
            //    result = UserManager.AddToRole(user.Id, "Admin");


            context.Fields.Add(new FieldEntity() 
            {
                Name = "IT",
<<<<<<< HEAD
                Questions = new List<QuestionEntity>()
                {
                    new QuestionEntity()
                    {
                        Title = "How to C#?",
                        QuestionText = "How to create this project?",
                        VideoPath = "null",
                        Date = DateTime.Parse("2015/12/20"),
                        UserName = "Dino",
                        Answers = new List<AnswerEntity>()
                        {
                            new AnswerEntity()
                            {
                                AnswerText = "Ovo je testni odgovor",
                                UserName = "Ivan",
                                VideoPath = "null",
                                Date = DateTime.Parse("2016/01/23")
                            }
                        }
                    },
                    new QuestionEntity()
                    {
                        Title = "How to Java?",
                        QuestionText = "How to create this project in Java?",
                        VideoPath = "null",
                        Date = DateTime.Parse("2015/12/20"),
                        UserName = "Luka"
                    }                    
                }
=======
                //Questions = new List<QuestionEntity>()
                //{
                //    new QuestionEntity()
                //    {
                //        Title = "How to C#?",
                //        QuestionText = "How to create this project?",
                //        Date = DateTime.Parse("2015/12/20"),
                //        UserName = "Dino",
                //        User = user
                //    },
                //    new QuestionEntity()
                //    {
                //        Title = "How to Java?",
                //        QuestionText = "How to create this project in Java?",
                //        Date = DateTime.Parse("2015/12/20"),
                //        UserName = "Luka",
                //        User = user
                //    }                    
                //}
>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4
            });
            context.Fields.Add(new FieldEntity()
            {
                Name="Economy",
<<<<<<< HEAD
                Questions = new List<QuestionEntity>()
                {
                    new QuestionEntity()
                    {
                        Title = "How to plan?",
                        QuestionText = "I have no idea?",
                        VideoPath = "null",
                        Date = DateTime.Parse("2015/12/20"),
                        UserName = "Ivan"
                    }
                }
=======
                //Questions = new List<QuestionEntity>()
                //{
                //    new QuestionEntity()
                //    {
                //        Title = "How to plan?",
                //        QuestionText = "I have no idea?",
                //        Date = DateTime.Parse("2015/12/20"),
                //        UserName = "Ivan",
                //        User = user
                //    }
                //}
>>>>>>> c2ed2912f8c20e58d04b3078661002db0eb318f4
            });

            context.SaveChanges();

            //QuestionEntity question1 = context.Questions.Where(q => q.Title == "How to C#?").First();
            //question1.Video = new VideoEntity()
            //{
            //    Id = question1.Id,
            //    Length = "6:00",
            //    UploadDate = DateTime.Parse("2015/12/19")
            //};
        }
    }
}
