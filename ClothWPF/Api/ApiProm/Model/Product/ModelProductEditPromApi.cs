using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelProductEditPromApi
    {
        public int64 id { get; set; }//Уникальный идентификатор товара.
        public enum presence { available, not_available, order };//Наличие товара.
        public double? price { get; set; }//Цена товара.
        public enum status { on_display, draft, deleted, not_on_display };//Статус сообщения.
        // public /*назвакласса*/ prices{get;set;}//Сетка оптовых цен.
        // public /*назвакласса*/ discount{get;set;}
        public string name { get; set; }//Название товара.
        public string keywords { get; set; }//Строка ключевых слов (разделитель запятая пробел ', ').
        public string description { get; set; }//Описание товара (может содержать html теги).
    }
}