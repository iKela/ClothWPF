using ClothWPF.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Helpes
{
    public class LoadedProvaider
    {
        public List<ProductModel> _ProductFullInfo { get; set; }
        public EfContext context;

        public Task ConnecTask()
        {
            return Task.Run(() =>
            {
                EfContext context = new EfContext();
            });
        }

        public void loaded()
        {
            _ProductFullInfo = context.Products
                // .Include(b => b.GetGroupProduct)
                .Select(a => new ProductModel
                {
                    IdProduct = a.IdProduct,
                    Code = a.Code,
                    Name = a.Name,
                    Count = a.Count,
                    PriceDollar = a.PriceDollar,
                    PriceUah = a.PriceUah,
                    PriceRetail = a.PriceRetail,
                    PriceWholesale = a.PriceWholesale,
                    Country = a.Country,
                    // Namegroup = a.GetGroupProduct.NameGroup
                }).ToList();
        }
    }
}
