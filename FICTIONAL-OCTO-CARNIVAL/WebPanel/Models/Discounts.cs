using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAPI.Models
{
    public class Discounts
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("UnitOfUsage")]
        public int UnitOfUsageId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount_Percentage { get; set; }
        public decimal Customer_Price { get; set; }
        [ForeignKey("Customers")]
        public Guid Customer_Id { get; set; }




    }
}
