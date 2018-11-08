using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model.PaymentOption
{
    public class ClassModelListPaymentOptionPromApi
    {
        public List<ClassModelPaymentOptionPromApi> modelListPaymentOptionPromApis;
    }
    public class ClassModelPaymentOptionPromApi
    {
        public int id { get; set; }//Уникальный идентификатор способа оплаты.
        public string name { get; set; }//Название способа оплаты.
        public string description { get; set; }//Описание способа оплаты.
    }
}
