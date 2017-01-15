using System;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

namespace Packt.CS7
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new Northwind();

            var query = db.Products
                .Where(product => product.UnitPrice < 10M)
                .OrderByDescending(product => product.UnitPrice);

            WriteLine("Products that cost less than $10.");
            foreach (Product item in query)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} costs {item.UnitPrice:$#,##0.00}");
            }
            WriteLine();

            var categories = db.Categories.Select(c => new { c.CategoryID, c.CategoryName }).ToArray();
            var products = db.Products.Select(p => new { p.ProductID, p.ProductName, p.CategoryID }).ToArray();

            // join every product to its category to return 77 matches
            var queryJoin = categories.Join(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                .OrderBy(cp => cp.ProductID);

            foreach (var item in queryJoin)
            {
                WriteLine($"{item.ProductID}: {item.ProductName} is in {item.CategoryName}.");
            }

            // group all products by their category to return 8 matches
            var queryGroup = categories.GroupJoin(products,
                category => category.CategoryID,
                product => product.CategoryID,
                (c, Products) => new { c.CategoryName,
                    Products = Products.OrderBy(p => p.ProductName) });

            foreach (var item in queryGroup)
            {
                WriteLine($"{item.CategoryName} has {item.Products.Count()} products.");
                foreach (var product in item.Products)
                {
                    WriteLine($"  {product.ProductName}");
                }
            }

            var productsForXml = db.Products.ToArray();

            var xml = new XElement("products",
                            from p in productsForXml
                            select new XElement("product",
                                new XAttribute("id", p.ProductID),
                                new XAttribute("price", p.UnitPrice),
                                new XElement("name", p.ProductName)));

            WriteLine(xml.ToString());

            XDocument doc = XDocument.Load(@"settings.xml");

            var appSettings = doc.Descendants(
                    "appSettings").Descendants("add")
                .Select(node => new
                {
                    Key = node.Attribute("key").Value,
                    Value = node.Attribute("value").Value
                })
                .ToArray();

            foreach (var item in appSettings)
            {
                WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}