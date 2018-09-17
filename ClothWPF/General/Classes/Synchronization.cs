using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothWPF.Authorization.Loading;
using ClothWPF.Entities;
using ClothWPF.Models.Main;

namespace ClothWPF.General.Classes
{
    public class Synchronization
    {
        public List<ExcelItem> TodayList;
        public List<ExcelItem> YesterdayList;
        public List<ProductModel> _ProductSynchronization= new List<ProductModel>();
        private EfContext context;
        public Synchronization()
        {
            foreach (var one in TodayList)
            {
                foreach (var two in YesterdayList)
                {
                    
                      //  _ProductSynchronization.Where(a=>a.Uid==two.UId).Select(a=>a.Count=two.)
                  
                }
            }
        }
    }
}
