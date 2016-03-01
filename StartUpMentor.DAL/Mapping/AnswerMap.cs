using StartUpMentor.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Mapping
{
	public class AnswerMap : EntityTypeConfiguration<AnswerEntity>
    {
        public AnswerMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.UserName).IsRequired();
            Property(t => t.AnswerText).IsRequired();
            Property(t => t.VideoPath).IsRequired();
            Property(t => t.Date).HasColumnType("datetime2");
            Property(t => t.DateLastEdited).HasColumnType("datetime2");

            //HasRequired(c => c.User).WithMany(u => u.Answers).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
            HasRequired(c => c.Question).WithMany(q => q.Answers).HasForeignKey(c => c.QuestionId);
        }
    }
}
