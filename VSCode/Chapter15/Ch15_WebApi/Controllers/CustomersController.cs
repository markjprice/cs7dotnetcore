using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Packt.CS7.Models;

namespace Packt.CS7.Controllers
{
  // base address: api/customers
  [Route("api/[controller]")]
  public class CustomersController : Controller
  {
    private ICustomerRepository repo;

    // constructor injects registered repository
    public CustomersController(ICustomerRepository repo)
    {
      this.repo = repo;
    }

    // GET: api/customers
    // GET: api/customers/?country=[country]
    [HttpGet]
    public IEnumerable<Customer> GetCustomers(string country)
    {
      if (string.IsNullOrWhiteSpace(country))
      {
        return repo.GetAll();
      }
      else
      {
        return repo.GetAll()
          .Where(customer => customer.Country == country);
      }
    }

    // GET: api/customers/[id]
    [HttpGet("{id}", Name = "GetCustomer")]
    public IActionResult GetCustomer(string id)
    {
      Customer c = repo.Find(id);
      if (c == null)
      {
        return NotFound(); // 404 Resource not found
      }
      return new ObjectResult(c); // 200 OK
    }

    // POST: api/customers
    // BODY: Customer (JSON, XML)
    [HttpPost]
    public IActionResult Create([FromBody] Customer c)
    {
      if (c == null)
      {
        return BadRequest(); // 400 Bad request
      }
      repo.Add(c);
      return CreatedAtRoute("GetCustomer", 
        new { id = c.CustomerID.ToLower() }, c); // 201 Created
    }

    // PUT: api/customers/[id]
    // BODY: Customer (JSON, XML)
    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] Customer c)
    {
      id = id.ToUpper();
      c.CustomerID = c.CustomerID.ToUpper();

      if (c == null || c.CustomerID != id)
      {
        return BadRequest(); // 400 Bad request
      }

      var existing = repo.Find(id);
      if (existing == null)
      {
        return NotFound(); // 404 Resource not found
      }

      repo.Update(id, c);
      return new NoContentResult(); // 204 No content
    }

    // DELETE: api/customers/[id]
    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
      var existing = repo.Find(id);
      if (existing == null)
      {
        return NotFound(); // 404 Resource not found
      }

      repo.Remove(id);
      return new NoContentResult(); // 204 No content
    }
  }
}
