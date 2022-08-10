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

#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Discounts” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Invoices” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Transactions” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Currency” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „UnitsOfUsage” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Products” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Customers” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Customers” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Products” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „UnitsOfUsage” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Currency” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Transactions” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Invoices” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Discounts” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
    }
}
