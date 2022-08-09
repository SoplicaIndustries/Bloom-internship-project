using System.ComponentModel.DataAnnotations;

namespace DbAPI.Models
{
    public class Customers
    {

        public string Name { get; set; }
        [Key]
        public Guid GUID { get; set; }

    }
}
