using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Models.Mapping
{
    public class QuestionEntityMap : EntityTypeConfiguration<QuestionEntity>
    {
        public QuestionEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired();

            this.Property(t => t.QuestionText)
                .IsRequired();

            this.Property(t => t.UserName)
                .IsRequired();

            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("QuestionEntity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.QuestionText).HasColumnName("QuestionText");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FieldId).HasColumnName("FieldId");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.QuestionEntities)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.FieldEntity)
                .WithMany(t => t.QuestionEntities)
                .HasForeignKey(d => d.FieldId);

        }
    }
}
