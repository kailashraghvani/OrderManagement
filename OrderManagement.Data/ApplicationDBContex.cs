using Microsoft.EntityFrameworkCore;
using OrderManagement.Data.Model;

namespace OrderManagement.Data
{
    public class ApplicationDBContex : DbContext
    {
        public ApplicationDBContex(DbContextOptions options) : base(options)
        {           
        }
        public DbSet<Customer> Customer {  get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
