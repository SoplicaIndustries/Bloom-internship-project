using System.ComponentModel.DataAnnotations;

namespace WebPanel.Models
{
    public class Currency
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }


    }
}
