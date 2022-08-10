using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAPI.Models
{
    public class Discounts
    {
        [Key]
        public int Id { get; set; }
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Name” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string Name { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Name” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Description” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string Description { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Description” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        [ForeignKey("UnitOfUsage")]
        public int UnitOfUsageId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount_Percentage { get; set; }
        public decimal Customer_Price { get; set; }
        [ForeignKey("Customers")]
        public Guid Customer_Id { get; set; }




    }
}
