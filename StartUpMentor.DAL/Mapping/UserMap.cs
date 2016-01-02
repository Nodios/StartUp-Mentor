using StartUpMentor.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.DAL.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            HasOptional(u => u.Info).WithRequired(i => i.User);

            //This creates separate table with
            HasMany(t => t.Fields).WithMany(f => f.Users).Map(uf =>
            {
                uf.MapLeftKey("UserRefId");
                uf.MapRightKey("FieldRefId");
                uf.ToTable("UserField");
            });
        }
    }
}
