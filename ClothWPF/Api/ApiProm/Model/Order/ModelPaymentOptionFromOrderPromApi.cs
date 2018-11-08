using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClothWPF.Api.ApiProm.Model.Order
{
    public class ModelPaymentOptionFromOrderPromApi
    {
        public int id { get; set; }// никальный идентификатор способа оплати.
        public string name { get; set; }//Название способа опланти.
    }
}
