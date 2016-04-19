namespace ShoppingApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShoppingModel : DbContext
    {
        // Your context has been configured to use a 'ShoppingModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ShoppingApplication.Models.ShoppingModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShoppingModel' 
        // connection string in the application configuration file.
        public ShoppingModel()
            : base("name=ShoppingModel")
        {
            Database.SetInitializer<ShoppingModel>(null);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShoppingModel>());
        }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderStatus> OrderStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                  .HasMany<Order>(e => e.Orders)
                  .WithRequired(e => e.customer)
                  .HasForeignKey(e => e.Custid);

            modelBuilder.Entity<OrderStatus>()
                  .HasMany<Order>(e => e.Orders)
                  .WithRequired(e => e.Ostatus)
                  .HasForeignKey(e => e.OStatusId);


            modelBuilder.Entity<Order>()
                .HasMany<Product>(s => s.Products)
                .WithMany(c => c.Orders)
                .Map(cs =>
                {
                    cs.MapLeftKey("OrderId");
                    cs.MapRightKey("ProductId");
                    cs.ToTable("OrderProducts ");
                });

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