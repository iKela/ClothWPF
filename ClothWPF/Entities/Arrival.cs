using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class Arrivals
    {
        [Key]
        public int IdArrival { get; set; }
        public string Number { get; set; }
        [MaxLength(50)]
        public string ComesTo { get; set; }
        public DateTime Date {get; set;}
        public string SupplierInvoice { get; set; }
        public string PaymentType { get; set; }
        public string Currency { get; set; }
        public double TotalPurchase { get; set; }
        public string Comment { get; set; }
        [ForeignKey("SupplierOf")]
        public int? IdSupplier { get; set; }
        public Supplier SupplierOf { get; set; }
        [ForeignKey("EnterpriseOf")]
        public int? EnterpriseId { get; set; }
        public Enterprise EnterpriseOf { get; set; }

        public virtual ICollection<ArrivalProduct> ArrivalProducts { get; set; }
    }
}
