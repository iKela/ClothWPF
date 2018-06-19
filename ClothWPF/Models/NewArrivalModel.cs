using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models
{
    public class NewArrivalModel
    {
        public int IdArrivalProduct { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? CountArrival { get; set; }
        public double? PriceDollarArrival { get; set; }
        public double? PriceUahArrival { get; set; }
        public double? PriceRetailArrival { get; set; }
        public double? PriceWholesaleArrival { get; set; }
        public DateTime? ManufactureDateArrival { get; set; }
        public int IdProduct { get; set; }
        public string Country { get; set; }
    }
}
