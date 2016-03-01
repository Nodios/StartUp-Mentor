using StartUpMentor.DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace StartUpMentor.DAL.Mapping
{
	public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            HasOptional(u => u.Info).WithRequired(i => i.User);

            //This creates separate table with Id of Field and Id of User
            HasMany(t => t.Fields).WithMany(f => f.Users).Map(uf =>
            {
                uf.MapLeftKey("UserRefId");
                uf.MapRightKey("FieldRefId");
                uf.ToTable("UserField");
            });
        }
    }
}
