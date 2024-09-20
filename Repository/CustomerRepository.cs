using BusinessObject;
using DataAccess;
using Microsoft.Extensions.Configuration;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        public string AddCustomer(Customer customer)
        => CustomerDAO.AddCustomer(customer);

        public string DeleteCustomer(Customer customer)
        => CustomerDAO.DeleteCustomer(customer);

        public List<Customer> GetAll()
        => CustomerDAO.GetCustomers();

        public Customer GetCustomerByName(string name)
        => CustomerDAO.FindCustomerByName(name);

        public string UpdateCustomer(Customer customer)
        => CustomerDAO.UpdateCustomer(customer);
    }
}
