﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Code { get; set; }
        public double? Count { get; set; }
        public double? PriceDollar { get; set; }
        public double? PriceUah { get; set; }
        public double? PriceRetail { get; set; }
        public double? PriceWholesale { get; set; }
        [MaxLength(59)]
        public string Country { get; set; }
        public virtual ICollection<Arrival> Arrivals { get; set; }
    }
}