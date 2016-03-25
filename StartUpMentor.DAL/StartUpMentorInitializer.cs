using System;
using System.Collections.Generic;
using System.Data.Entity;
using StartUpMentor.DAL.Models;

namespace StartUpMentor.DAL
{
	public class StartUpMentorInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
	{
		protected override void Seed(ApplicationDbContext context)
		{
			base.Seed(context);

			context.Fields.Add(new FieldEntity()
			{
				Name = "IT",
                ImagePath = "~/Uploads/FieldImages/startup1.jpg",
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
			});
			context.Fields.Add(new FieldEntity()
			{
				Name = "Economy",
                ImagePath = "~/Uploads/FieldImages/startup2.jpg",
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
			});

			context.SaveChanges();
		}
	}
}