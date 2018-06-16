using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models
{
    public class SupplierModel
    {
        public int    IdSupplier { get; set; }
       
        public string NameSupplier { get; set; }
       
        public string City { get; set; }
       
        public string AdressSupplier { get; set; }
      
        public string NumberSupplier { get; set; }
       
        public string Email { get; set; }

        public string Region { get; set; }
        public string Currency { get; set; }
        public string Category { get; set; }
        public string KindOfPartnership { get; set; }
        public string KindOfResponsibility { get; set; }
        public string IdentificationCode { get; set; }
        public double? MaxAmountOfDebt { get; set; }
        public string VATPlayerNumber { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? ContractDate { get; set; }
        public string IndividualTaxNumber { get; set; }
    }
}
