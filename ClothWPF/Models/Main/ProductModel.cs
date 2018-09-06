using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models.Main
{
    public class ProductModel
    {
        public int IdProduct { get; set; }
        public Int64 Uid { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string Code { get; set; }
        public double? Count { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        public string Country { get; set; }
        public string Namegroup { get; set; }
    }
}
