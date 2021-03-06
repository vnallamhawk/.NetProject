namespace Coaching.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CoachingModels : DbContext
    {
        // Your context has been configured to use a 'CoachingModels' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Coaching.Models.CoachingModels' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CoachingModels' 
        // connection string in the application configuration file.
        public CoachingModels()
            : base("name=CoachingModels")
                   
        {
            Database.SetInitializer<CoachingModels>(null);
            Database.SetInitializer(new DropCreateDatabaseAlways<CoachingModels>());
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teacheres { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Center> Centeres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Center>()
                  .HasMany<Branch>(e => e.Branches)
                  .WithRequired(e => e.center)
                  .HasForeignKey(e => e.centerid);

            modelBuilder.Entity<Center>()
                .HasMany<Teacher>(s => s.Teachers)
                .WithMany(c => c.Centers)
                .Map(cs =>
                {
                    cs.MapLeftKey("CenterId");
                    cs.MapRightKey("TeacherId");
                    cs.ToTable("CenterTeacher");
                });

            modelBuilder.Entity<Teacher>()
                    .HasMany<Student>(e => e.Students)
                    .WithRequired(e => e.teacher)
                    .HasForeignKey(e => e.teacherid);




        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}