using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace Packt.CS7.Models
{
  public class CustomerRepository : ICustomerRepository
  {
    // cache the customers in a thread-safe dictionary
    // so restarting the service will reset the customers
    // in real world the repository would perform CRUD
    // on the database
    private static 
      ConcurrentDictionary<string, Customer> customers;

    public CustomerRepository(Northwind db)
    {
      // load custoemrs from database as a normal
      // Dictionary with CustomerID is the key, 
      // then convert to a thread-safe
      // ConcurrentDictionary
      customers = new ConcurrentDictionary<string, Customer>(
        db.Customers.ToDictionary(c => c.CustomerID));
    }

    public Customer Add(Customer c)
    {
         // normalize CustomerID into uppercase
      c.CustomerID = c.CustomerID.ToUpper();
      // if the customer is new, add it, else
      // call Update method
      return customers.AddOrUpdate(c.CustomerID, c, Update);
    }

    public IEnumerable<Customer> GetAll()
    {
      return customers.Values;
    }

    public Customer Find(string id)
    {
      id = id.ToUpper();
      Customer c;
      customers.TryGetValue(id, out c);
      return c;
    }

    public bool Remove(string id)
    {
      id = id.ToUpper();
      Customer c;
      return customers.TryRemove(id, out c);
    }

    public Customer Update(string id, Customer c)
    {
      id = id.ToUpper();
      c.CustomerID = c.CustomerID.ToUpper();
      Customer old;
      if (customers.TryGetValue(id, out old))
      {
        if (customers.TryUpdate(id, c, old))
        {
          return c;
        }
      }
      return null;
    }
  }
}
