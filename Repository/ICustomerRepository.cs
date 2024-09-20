using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICustomerRepository
    {
        string AddCustomer(Customer customer);
        Customer GetCustomerByName(string name);
        string DeleteCustomer(Customer customer);
        string UpdateCustomer(Customer customer);
        List<Customer> GetAll();
    }
}
