using StartUpMentor.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Mapping
{
	public class InfoMap : EntityTypeConfiguration<InfoEntity>
    {
        public InfoMap()
        {
            //HasKey(t => t.Id);

            Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.FirstName).IsRequired();
            Property(i => i.LastName).IsRequired();
            Property(i => i.Email).IsRequired();
            Property(i => i.Contact).IsRequired();            
        }
    }
}
