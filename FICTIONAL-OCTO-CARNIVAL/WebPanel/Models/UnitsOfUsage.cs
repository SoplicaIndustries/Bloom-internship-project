using System.ComponentModel.DataAnnotations;

namespace DbAPI.Models
{
    public class UnitsOfUsage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }



    }
}
