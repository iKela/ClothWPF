using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model.Client
{
    public class ClassModelListClientPromApi
    {
        public List<ClassModelClientPromApi> modelListClientPromApis;
    }
    public class ClassModelClientPromApi
    {
        public int id { get; set; }//Уникальный идентификатор клиента.
        public string client_full_name { get; set; }//ФИО клиента.
        public string[] phones { get; set; }//Список телефонов клиента.
        public string[] emails { get; set; }// Список email-ов клиента.
        public string comment { get; set; }//Примечание о клиенте.
        public string skype { get; set; }//Skype клиента.
        public int? orders_count { get; set; }
        public string total_payout { get; set; }//Сумма всех заказов клиента.
    }
}
