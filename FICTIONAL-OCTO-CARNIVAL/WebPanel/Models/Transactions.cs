using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPanel.Models
{
    public class Transactions
    {
          [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Balance_After { get; set; }
        public DateTime Date { get; set; }
        public Guid Reference_Number { get; set; }
        [ForeignKey("Currency")]
        public int Currency_Id { get; set; }
        [ForeignKey("Customers")]
        public Guid Customer_Id { get; set; }
        public Guid Product_Id { get; set; }

        public string Product_Name { get; set; }

    }
}
