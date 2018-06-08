using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class Arrival
    {
        [Key]
        public int IdArrival { get; set; }
        public int Number { get; set; }
        public double TotalPurchase { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public double? WholeSale { get; set; }
        public string Enterprice { get; set; }
        public string Comment { get; set; }
    }
}
