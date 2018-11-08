using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model.Message
{
    public class ClassModelListMessagePromApi
    {
        public List<ClassModelMessagePromApi> modelListMessagePromApis;
    }
    public class ClassModelMessagePromApi
    {       
        public int id { get; set; }// идентификатор сообщения.
        public string date_created { get; set; } //Дата создания сообщения в формате ISO-8601. Пример - “2015-04-28T12:50:34.588791+00:00”
        public string client_full_name { get; set; }//ФИО клиента.
        public string phone { get; set; }//Телефон клиента.
        public string message { get; set; }//Текст сообщения.
        public string subject { get; set; }//Тема сообщения.
        public enum status { unread, read, deleted }//Статус сообщения.        
        public int? product_id { get; set; }//Уникальный идентификатор товара.
    }
}

