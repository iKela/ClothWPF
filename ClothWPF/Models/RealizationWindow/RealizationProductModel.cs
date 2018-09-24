using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models.RealizationWindow
{
    public class RealizationProductModel
    {
        public int IdRealizationProduct { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Count { get; set; }
        public double? CountSale { get; set; }
        public double? CountReserved { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        public double? NDS { get; set; }
        public double? Discount { get; set; }
        public double? Sum { get; set; }   
        public  double? Profit { get; set; }
        public int IdRealization { get; set; }   
        public int Idproduct { get; set; }

        public Color BackgroundColor
        {
            get
            {
                if (Profit < 0)
                {
                    return Color.LightCoral;
                }
                else
                {
                    return Color.Red;
                }
            }
        }
    }
}
