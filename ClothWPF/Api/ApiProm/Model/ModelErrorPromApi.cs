using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListErrorPromApi
    {
        public List<ClassModelErrorPromApi> modelListErrorPromApis;
    }
    public class ClassModelErrorPromApi
    {
        public string error { get; set; }//Ошибка при выполнении запроса.
    }
}