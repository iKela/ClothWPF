using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class Supplier
    {
        [Key]
        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; }
        public string City { get; set; }
        public string AdressSupplier { get; set; }
        public string NumberSupplier { get; set; }
        public string Email { get; set; }
        public string Currency { get; set; }
        public double? Discount { get; set; }
        public string Region { get; set; }
        public string DiscountCardNumber { get; set; }
        public string Category { get; set; }
        public string FullName { get; set; }
        public string LegalAddress { get; set; }
        public double? MaxAmountOfDebt { get; set; }
        public string VATPlayerNumber { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? ContractDate { get; set; }
        public string IndividualTaxNumber { get; set; }
        public string KindOfResponsibility { get; set; }
        public double? TotalClientPurshaise { get; set; }
    }
}
