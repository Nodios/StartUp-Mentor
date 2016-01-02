using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Models.Mapping
{
    public class VideoEntityMap : EntityTypeConfiguration<VideoEntity>
    {
        public VideoEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("VideoEntity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Path).HasColumnName("Path");
            this.Property(t => t.UploadDate).HasColumnName("UploadDate");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FieldId).HasColumnName("FieldId");
        }
    }
}
