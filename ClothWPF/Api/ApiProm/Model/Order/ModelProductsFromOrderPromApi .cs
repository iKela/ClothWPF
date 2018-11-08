using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClothWPF.Api.ApiProm.Model.Order
{
    public class ModelProductsFromOrderPromApi
    {
        public int id { get; set; }//Уникальный идентификатор товара.
        public string external_id { get; set; }//Уникальный идентификатор (внешней системы) товара.
        public string image { get; set; }//Ссылка на изображение.
        public double? quantity { get; set; }//Количество единиц товара в заказе.
        public string price { get; set; }//Цена товара за единицу.
        public string url { get; set; }//Ссылка на товар на сайте компании.
        public string name { get; set; }//Название товара.
        public string total_price { get; set; }//Сумма заказа.
        public string measure_unit { get; set; }//Единица измерения.
        public string sku { get; set; }//Код (артикул) товара.
    }
}
