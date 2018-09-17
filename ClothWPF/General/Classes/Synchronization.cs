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
        public List<ProductModel> _ProductSynchronization= new List<ProductModel>();
        private EfContext context;
        public Synchronization()
        {
            foreach (var one in ConstList._FullInfo)
            {
                var id = ConstList.excelItems.SingleOrDefault(a => a.UId == one.Uid);
                context.ExcelTables.Add(new ExcelTable
                {

                });
            }
        }
    }
}
