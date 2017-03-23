using System.Collections.Generic;

namespace Packt.CS7.Models
{
    public interface ICustomerRepository
    {
        Customer Add(Customer c);

        IEnumerable<Customer> GetAll();

        Customer Find(string id);

        bool Remove(string id);

        Customer Update(string id, Customer c);
    }
}
