using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class Supplier
    {
        [Key]
        public int IdSupplier { get; set; }
        [MaxLength(50)]
        public string NameSupplier { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(69)]
        public string AdressSupplier { get; set; }
        [MaxLength(60)]
        public string NumberSupplier { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Region { get; set; }
        public string Currency { get; set; }
    }
}
