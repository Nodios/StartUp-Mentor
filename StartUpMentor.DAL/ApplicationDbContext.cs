using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StartUpMentor.DAL.Models;
using StartUpMentor.DAL.Mapping;
using StartUpMentor.Common;

namespace StartUpMentor.DAL
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Constructors
        public ApplicationDbContext() : base(ConnectionStrings.CONNECTION)
        {
			Database.SetInitializer(new StartUpMentorInitializer());
        }
        public ApplicationDbContext(string connection) : base(connection)
		{
			Database.SetInitializer(new StartUpMentorInitializer());
        }
        #endregion

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<AnswerEntity> Answers { get; set; }
        public DbSet<FieldEntity> Fields { get; set; }
        public DbSet<InfoEntity> Info { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
		public DbSet<TokenEntity> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new FieldMap());
            modelBuilder.Configurations.Add(new InfoMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new UserMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        // Summary:
        //     A DbSet represents the collection of all entities in the context, or that
        //     can be queried from the database, of a given type. DbSet objects are created
        //     from a DbContext using the DbContext.Set method.
        //
        // Type parameters:
        //   T:
        //     The type that defines the set.
        //
        // Remarks:
        //     Note that DbSet does not support MEST (Multiple Entity Sets per Type) meaning
        //     that there is always a one-to-one correlation between a type and a set
        public override DbSet<T> Set<T>()
        {
            return base.Set<T>();
        }

        //Check for model validation errors
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
