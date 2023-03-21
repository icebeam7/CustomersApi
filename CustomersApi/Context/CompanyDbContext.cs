using Microsoft.EntityFrameworkCore;
using CustomersApi.Models;

namespace CustomersApi.Context
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext()
        {

        }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;

    }
}
