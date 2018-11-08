using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListImportProductStatusPromApi
    {
        public List<ClassModelImportProductStatusPromApi> modelListImportProductStatusPromApis;
    }
    public class ClassModelImportProductStatusPromApi
    {
        public enum status { SUCCESS, PARTIAL, FATAL };
        public int not_changed { get; set; }//Количество позиций, оставшихся без изменения
        public int updated { get; set; }//Количество обновленных позиций
        public int not_in_fle { get; set; }//Количество позиций, которых нет в файле импорта
        public int imported { get; set; }//Количество импортрованных позиций
        public int created { get; set; }//Количество созданных позиций
        public int actualized { get; set; }//Количество актуализированных позиций
        public int created_active { get; set; }//Создано активных позиций
        public int created_hidden { get; set; }//Создано скрытых позиций
        public int total { get; set; }//Всего загружено позиций
        public int with_errors_count { get; set; }//Всего позиций с ошибками
        //errors
    }
}