using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models
{
    class ArrivalsProductModel
    {
        public int IdArrivalProduct { get; set; }
        public string NameProduct { get; set; }
        public string Article { get; set; }
        public double? Count { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public int Idarrival { get; set; }
        public int Idproduct { get; set; }
    }
}
