using System.ComponentModel.DataAnnotations;

namespace DbAPI.Models
{
    public class Customers
    {

#pragma warning disable CS8618 // Niedopuszczający wartości null element właściwość „Name” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        public string Name { get; set; }
#pragma warning restore CS8618 // Niedopuszczający wartości null element właściwość „Name” musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie elementu właściwość jako dopuszczającego wartość null.
        [Key]
        public Guid Id { get; set; }



    }
}
