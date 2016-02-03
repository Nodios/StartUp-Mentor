using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using StartUpMentor.DAL.Models;

namespace StartUpMentor.DAL
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<AnswerEntity> Answers { get; set; }
        DbSet<FieldEntity> Fields { get; set; }
        DbSet<InfoEntity> Info { get; set; }
        DbSet<QuestionEntity> Questions { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
