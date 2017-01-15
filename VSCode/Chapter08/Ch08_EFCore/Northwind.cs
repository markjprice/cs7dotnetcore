using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    // this manages the connection to the database
    public class Northwind : DbContext
    {
        // these properties map to tables in the database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // for Microsoft SQL Server
            // optionsBuilder.UseSqlServer(
            //     @"Data Source=(localdb)\mssqllocaldb;" +
            //     "Initial Catalog=Northwind;" +
            //     "Integrated Security=true;");

            // for SQLite
            optionsBuilder.UseSqlite("Filename=../../../../Northwind.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}