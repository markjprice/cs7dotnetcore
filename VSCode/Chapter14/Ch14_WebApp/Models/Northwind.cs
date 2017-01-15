using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
  public class Northwind : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }

    public Northwind(DbContextOptions options) : base(options) {}
  }
}
