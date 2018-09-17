using ClothWPF.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothWPF.Authorization.Loading;

namespace ClothWPF.Helpes
{
    public class Load
    {
        public List<ProductModel> _ProductFullInfo { get; set; }
        public EfContext context;
        public Load()
        {
            context = new EfContext();
        }

        public void  loaded()
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
            ConstList.Init(_ProductFullInfo);
        }
       
    }
}
