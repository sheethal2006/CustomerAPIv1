using CustomerAPIv1.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPIv1.Data
{
    public class CustomerDbContext :DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=customer.db");
            }
        }
    }
}
