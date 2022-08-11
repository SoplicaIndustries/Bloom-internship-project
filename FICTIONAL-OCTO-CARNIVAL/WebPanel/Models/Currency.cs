using System.ComponentModel.DataAnnotations;

namespace WebPanel.Models
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
