using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomers()
        {
            var listCustomers = new List<Customer>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listCustomers = context.Customers.ToList();
                }
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine($"Error fetching customers: {e.Message}");
                Console.WriteLine($"Stack trace: {e.StackTrace}");
                throw;
            }
            return listCustomers;
        }

        public static Customer FindCustomerByName(string _name)
        {
            Customer c = new Customer();
            try
            {
                using (var context = new MyDbContext())
                {
                    c = context.Customers.SingleOrDefault(x => x.username == _name);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return c;
        }

        public static string AddCustomer(Customer c)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Customers.Add(c);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to add new customer");
            }
            return "Add new Customer Success";
        }

        public static string UpdateCustomer(Customer customer)
        {
            try
            {
                Console.WriteLine(customer.username);
                Console.WriteLine(customer.password);
                Console.WriteLine(customer.fullname);
                Console.WriteLine(customer.gender);
                Console.WriteLine(customer.birthday);
                Console.WriteLine(customer.address);
                using (var context = new MyDbContext())
                {
                    //var customer = FindCustomerByName(c.username);

                    context.Entry<Customer>(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return "Update Complete";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Update Failed");
            }
            
        }

        public static string DeleteCustomer(Customer _customer)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Customers.SingleOrDefault(c => c.username == _customer.username);
                    context.Customers.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Delete failed");
            }
            return "Delete Success";
        }
    }
}
