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
    public class VideoMap : EntityTypeConfiguration<VideoEntity>
    {
        public VideoMap()
        {
            HasKey(v => v.Id);

            Property(v => v.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(v => v.Title);
            Property(v => v.Length);
            Property(v => v.Path).IsRequired();
            Property(v => v.UploadDate).HasColumnType("datetime2");
        }
    }
}
