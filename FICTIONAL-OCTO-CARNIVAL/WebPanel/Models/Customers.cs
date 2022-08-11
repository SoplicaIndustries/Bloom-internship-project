using System.ComponentModel.DataAnnotations;

namespace WebPanel.Models
{
    public class Customers
    {

        public string Name { get; set; }
        [Key]
        public Guid Id { get; set; }
    
        public decimal Balance { get; set; }

        public string Currency { get; set; }
        public decimal Deposit { get; set; }

    }
}
