﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class ArrivalProduct
    {
        [Key]
        public int IdArrivalProduct { get; set; }
        public double? Count { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        public double TotalPurshaise { get; set; }
        public DateTime? ManufactureDate { get; set; }
        [ForeignKey("ArrivalOf")]
        public int Idarrival { get; set; }
        public Arrivals ArrivalOf { get; set; }
        [ForeignKey("ProductOf")]
        public int Idproduct { get; set; }
        public Product ProductOf { get; set; }

        public virtual Arrivals Arrivals { get; set; }
    }
}
