using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models.ArrivalsList
{
    class ArrivalsModel
    {
        public int IdArrival { get; set; }
        public string Number { get; set; }
        public string ComesTo { get; set; }
        public DateTime Date { get; set; }
        public string SupplierInvoice { get; set; }
        public string PaymentType { get; set; }
        public string Currency { get; set; }
        public double TotalPurchase { get; set; }
        public string Comment { get; set; }
        public string nameSupplier { get; set; }
        public string nameEnterprise { get; set; }
    }
}
