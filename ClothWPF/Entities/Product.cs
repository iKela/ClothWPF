using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Article { get; set; }
        public string Code { get; set; }
        public double? Count { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        [MaxLength(59)]
        public string Country { get; set; }
        [ForeignKey("GetGroupProduct")]
        public int? Idgroup { get; set; }
        public GroupProduct GetGroupProduct { get; set; }
    }
}
