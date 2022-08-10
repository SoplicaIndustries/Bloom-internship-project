using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAPI.Models
{
    public class Invoices
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Currency")]
        public int Currency_Id { get; set; }
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Document_Path” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string Document_Path { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Document_Path” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        [ForeignKey("Customers")]
        public Guid Customer_Id { get; set; }
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „InvoiceNo” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string InvoiceNo { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „InvoiceNo” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.





    }
}
