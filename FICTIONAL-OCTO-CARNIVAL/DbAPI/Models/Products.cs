﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAPI.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("UnitsOfUsage")]
        public int UnitOfUsageId { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Currency")]
        public int Currency_Id { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set; }








    }
}
