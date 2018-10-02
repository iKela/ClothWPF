using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class RealizationProduct
    {
        [Key]
        public int IdRealizationProduct { get; set; }
        public double? Count { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        public double? NDS { get; set; }
        public  double? Profit { get; set; }
        public double? DiscountProduct { get; set; }
        public double? TotalProductSum { get; set; }
        [ForeignKey("GetRealization")]
        public int IdRealization { get; set; }

        public Realization GetRealization { get; set; }
        [ForeignKey("ProductOf")]
        public int Idproduct { get; set; }
        public Product ProductOf { get; set; }
    }
}
