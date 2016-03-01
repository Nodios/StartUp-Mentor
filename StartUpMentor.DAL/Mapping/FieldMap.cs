using StartUpMentor.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Mapping
{
	public class FieldMap : EntityTypeConfiguration<FieldEntity>
    {
        public FieldMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired().HasMaxLength(100);            
        }
    }
}
