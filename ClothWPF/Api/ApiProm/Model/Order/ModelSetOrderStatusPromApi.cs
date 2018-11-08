using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListSetOrderStatusPromApi
    {
        public List<ClassModelSetOrderStatusPromApi> modelListSetOrderStatusPromApis;
    }
    public class ClassModelSetOrderStatusPromApi
    {
        public enum status { pending, received, delivered, canceled, draft, paid };
        //public Int64[] ids { get; set; }//—писок уникальных идентификаторов.//те саме не знаючи це массив
        public enum cancellation_reason { not_available, price_changed, buyers_request, not_enough_fields, duplicate, invalid_phone_number, less_than_minimal_price, another };//ѕричина отмены заказа (“олько дл€ статуса УcanceledФ).
        public string cancellation_text { get; set; }//—ообщение дл€ причины отмены заказа (“олько дл€ статуса УcanceledФ). ќб€зательно в случае, если Уcancellation_reasonФ имеет значение "price_changed", Уnot_enough_fieldsФ или УanotherФ
    }
}