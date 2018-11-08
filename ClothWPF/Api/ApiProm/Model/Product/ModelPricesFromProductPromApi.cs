using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ModelPricesFromProductPromApi
    {
        public double? price {get;set;}   //Цена за товар при покупке свыше указанного количества.
        public double? minimum_order_quantity { get; set; }  // Минимальное количество единиц товара для указанной цены.
    }
}
