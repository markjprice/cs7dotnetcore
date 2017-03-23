using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
        {
            // for Microsoft SQL Server
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\mssqllocaldb;" +
                "Initial Catalog=Northwind;" +
                "Integrated Security=true;");

            // for SQLite
            //optionsBuilder.UseSqlite(
            //"Filename=../../../../Northwind.db");
        }
    }
}
