using Microsoft.EntityFrameworkCore;

namespace Packt.CS7.Models
{
  public class Northwind : DbContext 
  {
    public DbSet<Customer> Customers { get; set; }

    public Northwind(DbContextOptions options) : base(options) {}
  }
}
