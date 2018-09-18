﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothWPF.Entities
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }
        public string NameClient { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public double? Discount { get; set; }
        public  string DiscountCardNumber { get; set; }
        public string Currency { get; set; }
        public  string Category { get; set; }
        public string FullName { get; set; }
        public string Legaladress { get; set; }
        public double? MaxAmountOfDebt { get; set; }
        public string VATPlayerNumber { get; set; }
        public string ContractNumber { get; set; }
        public  DateTime? ContractDate { get; set; }
        public string IndividualTaxNumber { get; set; }
        public string KindOfResponsibility { get; set; }        
    }
}
