using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model.Group
{
    public class ClassModelListGroupPromApi
    {
        public List<ClassModelGroupPromApi> modelListGroupPromApis;
    }
    public class ClassModelGroupPromApi
    {
        public int id { get; set; }//Уникальный идентификатор группы.
        public string name { get; set; }//Название группы.
        public string description { get; set; }//Описание группы.
        public string image { get; set; }//Ссылка на изображение группы.
        public int? parent_group_id { get; set; }//Идентификатор родительской группы.
    }
}
