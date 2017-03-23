using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static System.Console;
using Packt.CS7;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ch08_EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Northwind())
            {
                using (IDbContextTransaction t =
  db.Database.BeginTransaction())
                {
                    WriteLine($"Transaction started with this isolation level: {t.GetDbTransaction().IsolationLevel}");

                    var loggerFactory = db.GetService<ILoggerFactory>();
                    loggerFactory.AddProvider(new ConsoleLogProvider());

                    WriteLine("List of categories and the number of products:");

                    IQueryable<Category> cats;
                    // = db.Categories.Include(c => c.Products);

                    Write("Enable eager loading? (Y/N): ");
                    bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
                    bool explicitloading = false;
                    WriteLine();
                    if (eagerloading)
                    {
                        cats = db.Categories.Include(c => c.Products);
                    }
                    else
                    {
                        cats = db.Categories;
                        Write("Enable explicit loading? (Y/N): ");
                        explicitloading = (ReadKey().Key == ConsoleKey.Y);
                        WriteLine();
                    }


                    foreach (Category c in cats)
                    {
                        if (explicitloading)
                        {
                            Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
                            if (ReadKey().Key == ConsoleKey.Y)
                            {
                                var products = db.Entry(c).Collection(c2 => c2.Products);
                                if (!products.IsLoaded) products.Load();
                            }
                            WriteLine();
                        }

                        WriteLine(
                          $"{c.CategoryName} has {c.Products.Count} products.");
                    }

                    WriteLine("List of products that cost more than a given price with most expensive first.");
                    string input;
                    decimal price;
                    do
                    {
                        Write("Enter a product price: ");
                        input = ReadLine();
                    } while (!decimal.TryParse(input, out price));

                    IQueryable<Product> prods = db.Products
                        .Where(product => product.UnitPrice > price)
                        .OrderByDescending(product => product.UnitPrice);

                    foreach (Product item in prods)
                    {
                        WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                    }

                    var newProduct = new Product
                    {
                        CategoryID = 6, // Meat & Poultry
                        ProductName = "Bob's Burger",
                        UnitPrice = 500M
                    };
                    // mark product as added in change tracking
                    db.Products.Add(newProduct);
                    // save tracked changes to database
                    db.SaveChanges();
                    foreach (var item in db.Products)
                    {
                        WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                    }

                    Product updateProduct = db.Products.First(
                      p => p.ProductName.StartsWith("Bob"));
                    updateProduct.UnitPrice += 20M;
                    db.SaveChanges();
                    foreach (var item in db.Products)
                    {
                        WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                    }

                    Product deleteProduct = db.Products.First(
                      p => p.ProductName.StartsWith("Bob"));
                    db.Products.Remove(deleteProduct);
                    db.SaveChanges();
                    foreach (var item in db.Products)
                    {
                        WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
                    }

                    t.Commit();
                }
            }
        }
    }
}
