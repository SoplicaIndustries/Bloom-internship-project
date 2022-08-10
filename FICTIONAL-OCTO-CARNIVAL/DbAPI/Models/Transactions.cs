using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAPI.Models
{
    public class Transactions
    {
        [Key]
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Description” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string Description { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Description” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public decimal Price { get; set; }
        public decimal Balance_After { get; set; }
        public DateTime Date { get; set; }
        public Guid Reference_Number { get; set; }
        [ForeignKey("Currency")]
        public int Currency_Id { get; set; }
        [ForeignKey("Customers")]
        public Guid Customer_Id { get; set; }
        public Guid Product_Id { get; set; }





    }
}
