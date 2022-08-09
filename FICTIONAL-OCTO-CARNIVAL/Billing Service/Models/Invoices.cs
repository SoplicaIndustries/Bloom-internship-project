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
        public string Document_Path { get; set; }
        [ForeignKey("Customers")]
        public Guid Customer_Id { get; set; }
        public string InvoiceNo { get; set; }





    }
}
