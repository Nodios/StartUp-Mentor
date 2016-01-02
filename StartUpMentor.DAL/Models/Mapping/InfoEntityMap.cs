using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Models.Mapping
{
    public class InfoEntityMap : EntityTypeConfiguration<InfoEntity>
    {
        public InfoEntityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired();

            this.Property(t => t.LastName)
                .IsRequired();

            this.Property(t => t.Email)
                .IsRequired();

            this.Property(t => t.Contact)
                .IsRequired();

            this.Property(t => t.User_Id)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("InfoEntity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.User_Id).HasColumnName("User_Id");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.InfoEntities)
                .HasForeignKey(d => d.User_Id);

        }
    }
}
