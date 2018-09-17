using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models.RealizationWindow
{
    public class RealizationModel
    {
        public int IdRealization { get; set; }
        public string Number { get; set; }
        public DateTime DateRealization { get; set; }
        public string PaymentType { get; set; }
        public string Currency { get; set; }
        public string Comment { get; set; }
        public double? PercentageDiscount { get; set; }
        public double? SumDiscount { get; set; }
        public double? Prepayment { get; set; }
        public double TotalPurshaise { get; set; }
        public double? PaymentSum { get; set; }
        public string ClientName { get; set; }
    }
}

