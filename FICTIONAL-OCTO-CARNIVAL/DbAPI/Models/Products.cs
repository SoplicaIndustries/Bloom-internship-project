using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAPI.Models
{
    public class Products
    {
        [Key]
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Name” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string Name { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Name” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Description” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string Description { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Description” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        [ForeignKey("UnitsOfUsage")]
        public int UnitOfUsageId { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Currency")]
        public int Currency_Id { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set; }








    }
}
