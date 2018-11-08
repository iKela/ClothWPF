using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListImportProductWithFilePromApi
    {
        public List<ClassModelImportProductWithFilePromApi> modelListImportProductWithFilePromApis;
    }
    public class ClassModelImportProductWithFilePromApi
    {
        public string file { get; set; }//excel документ
        //data nada
    }
}