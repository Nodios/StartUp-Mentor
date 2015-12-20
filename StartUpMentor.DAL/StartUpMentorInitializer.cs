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
            context.Fields.Add(new FieldEntity() 
            {
                Name = "IT",
                Questions = new List<QuestionEntity>()
                {
                    new QuestionEntity()
                    {
                        Title = "How to C#?",
                        QuestionText = "How to create this project?",
                        Date = DateTime.Parse("2015/12/20"),
                        UserName = "Dino"
                    },
                    new QuestionEntity()
                    {
                        Title = "How to Java?",
                        QuestionText = "How to create this project in Java?",
                        Date = DateTime.Parse("2015/12/20"),
                        UserName = "Luka"
                    }                    
                }
            });
            context.Fields.Add(new FieldEntity()
            {
                Name="Economy",
                Questions = new List<QuestionEntity>()
                {
                    new QuestionEntity()
                    {
                        Title = "How to plan?",
                        QuestionText = "I have no idea?",
                        Date = DateTime.Parse("2015/12/20"),
                        UserName = "Ivan"
                    }
                }
            });

            context.SaveChanges();

            QuestionEntity question1 = context.Questions.Where(q => q.Title == "How to C#?").First();
            question1.Video = new VideoEntity()
            {
                Id = question1.Id,
                Length = "6:00",
                UploadDate = DateTime.Parse("2015/12/19")
            };
        }
    }
}
