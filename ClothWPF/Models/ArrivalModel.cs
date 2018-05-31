using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models
{
    public class ArrivalModel
    {
        public int Id { get; set; }
        public double? Count { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        public DateTime ManufactureDate { get; set; }

    }
}
