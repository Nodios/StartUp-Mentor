using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Models.Mapping
{
    public class AnswerEntityMap : EntityTypeConfiguration<AnswerEntity>
    {
        public AnswerEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AnswerText)
                .IsRequired();

            this.Property(t => t.UserName)
                .IsRequired();

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AnswerEntity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AnswerText).HasColumnName("AnswerText");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.AnswerEntities)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.QuestionEntity)
                .WithMany(t => t.AnswerEntities)
                .HasForeignKey(d => d.QuestionId);

        }
    }
}
