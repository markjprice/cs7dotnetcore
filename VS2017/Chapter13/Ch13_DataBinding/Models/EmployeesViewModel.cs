using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13_DataBinding.Models
{
    public class EmployeesViewModel
    {
        public HashSet<Employee> Employees { get; set; }

        public EmployeesViewModel()
        {
            Employees = new HashSet<Employee>();
            Employees.Add(new Employee
            {
                EmployeeID = 1,
                FirstName = "Alice",
                LastName = "Smith",
                DOB = new DateTime(1972, 1, 27),
                Salary = 34000M
            });
            Employees.Add(new Employee
            {
                EmployeeID = 2,
                FirstName = "Bob",
                LastName = "Jones",
                DOB = new DateTime(1965, 4, 13),
                Salary = 64000M
            });
        }
    }
}
