using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model.Product
{
    public class ModelDiscountFromProductPromApi
    {
        public int? value { get; set; }//Установленное значение скидки
        public enum type { amount, percent } //Тип скидки (абсолютное значение/процент)
        public string date_start { get; set; }//Дата начала периода скидок ДД.ММ.ГГГГ
        public string date_end { get;set; }//Дата окончания периода скидок ДД.ММ.ГГГГ
    }
}
