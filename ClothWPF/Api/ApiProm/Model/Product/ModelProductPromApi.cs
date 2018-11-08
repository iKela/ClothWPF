using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListProductPromApi
    {
        public List<ClassModelProductPromApi> modelListProductPromApis;
    }
    public class ClassModelProductPromApi
    {
        public int id { get; set; }
        public string external_id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public enum selling_type { retail, wholesale, universal, service }//Тип товара.
        public enum presence { available, not_available, order, service }//Наличие товара.
        public double? price { get; set; }
        public ModelDiscountFromProductPromApi discount { get; set; }
        public string currency { get; set; } 
        public ModelGroupFromProductPromApi group { get; set; } 
        public ModelCategoryFromProductPromApi category { get; set; } 
        public ModelPricesFromProductPromApi prices {get;set;}
        public string main_image { get; set; }
        public enum status { on_display, draft, deleted, not_on_display, editing_required, approval_pending, deleted_by_moderator };
        public string[] images { get; set; }       
    }
}
