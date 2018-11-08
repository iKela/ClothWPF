using ClothWPF.Api.ApiProm.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListOrderPromApi
    {
        public List<ClassModelOrderPromApi> modelListOrdrPromApis;
    }
    public class ClassModelOrderPromApi
    {
        public int id { get; set; }//Уникальный идентификатор заказа.
        public string date_created { get; set; }//Дата создания заказа в формате ISO-8601. Пример - “2015-04-28T12:50:34.588791+00:00”
        public string client_first_name { get; set; }//Имя клиента.
        public string client_last_name { get; set; }//Фамилия клиента.
        public string client_notes { get; set; }//Добавленный пользователем комментарий.
        public ModelProductsFromOrderPromApi products { get; set; }
        public string phone { get; set; }//Телефон клиента.
        public string email { get; set; }//Email клиента.
        public string price { get; set; }//Сумма заказа.
        public ModelDeliveryOptionFromOrderPromApi delivery_option { get; set; }
        public string delivery_address { get; set; }//Адрес доставки.
        public ModelPaymentOptionFromOrderPromApi payment_option { get; set; }
        public enum status { pending, received, delivered, canceled, draft, paid };//Статус заказа.
        public enum source { portal, company_site, company_cabinet, mobile_app, bigl };//Источник заказа


    }
}
