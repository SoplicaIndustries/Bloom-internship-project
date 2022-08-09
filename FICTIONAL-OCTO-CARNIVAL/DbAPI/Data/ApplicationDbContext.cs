using DbAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DbAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Currency> Currency { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Discounts> Discounts { get; set; }

        public DbSet<Invoices> Invoices { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Transactions> Transactions { get; set; }

        public DbSet<UnitsOfUsage> UnitsOfUsage { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
