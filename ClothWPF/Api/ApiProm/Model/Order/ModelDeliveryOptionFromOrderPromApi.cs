using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model.Order
{
    public class ModelDeliveryOptionFromOrderPromApi
    {
        public int id { get; set; }// никальный идентификатор способа доставки.
        public string name { get; set; }//Название способа доставки.
    }
}
