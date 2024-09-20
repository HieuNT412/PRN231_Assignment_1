using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "BusinessObject")).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("CustomerDB"));
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
            new Customer { username = "datnce", password = "1", fullname = "Nguyen Dat", gender = "nam", birthday = new DateTime(2003, 1, 1), address = "123" },
                new Customer { username = "phong", password = "1", fullname = "Thanh Phong", gender = "nam", birthday = new DateTime(2003, 1, 1), address = "123" },
                new Customer { username = "hieu", password = "1", fullname = "Thanh Hieu", gender = "nam", birthday = new DateTime(2003, 1, 1), address = "123" },
                new Customer { username = "minh", password = "1", fullname = "Duy Minh", gender = "nam", birthday = new DateTime(2003, 1, 1), address = "123" },
                new Customer { username = "khoiminh", password = "1", fullname = "Khoi Minh", gender = "nam", birthday = new DateTime(2003, 1, 1), address = "123" }
            );
        }
    }
}
