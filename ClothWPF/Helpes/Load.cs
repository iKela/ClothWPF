using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothWPF.Authorization.Loading;
using ClothWPF.Models;
using ClothWPF.Models.ArrivalInfo;
using ProductModel = ClothWPF.Models.Main.ProductModel;

namespace ClothWPF.Helpes
{
    public class Load
    {
        public List<ProductModel> _ProductFullInfo { get; set; }
        public List<EnterpriseModel> _EnterpriseModels { get; set; }
        public List<SupplierModel> _SupplierModels { get; set; }
        public EfContext context;
        public Load()
        {
            context = new EfContext();
        }

        public void  loaded()
        {
            _ProductFullInfo = context.Products
                 
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
                    Uid = a.Uid,
                    Namegroup = a.GetGroupProduct.NameGroup
                }).ToList();
            ConstList.Init(_ProductFullInfo);
        }

        public void loadedSuplier()
        {
            _SupplierModels = context.Suppliers.Select(a => new SupplierModel
            {
                IdSupplier = a.IdSupplier,
                NameSupplier = a.NameSupplier,
                City = a.City,
                AdressSupplier = a.AdressSupplier,
                NumberSupplier = a.NumberSupplier,
                Email = a.Email,
                Currency = a.Currency,
                Discount = a.Discount,
                Region = a.Region,
                DiscountCardNumber = a.DiscountCardNumber,
                Category = a.Category,
                FullName = a.FullName,
                LegalAddress = a.LegalAddress,
                MaxAmountOfDebt = a.MaxAmountOfDebt,
                VATPlayerNumber = a.VATPlayerNumber,
                ContractNumber = a.ContractNumber,
                ContractDate = a.ContractDate,
                IndividualTaxNumber = a.IndividualTaxNumber,
                KindOfResponsibility = a.KindOfResponsibility
            }).ToList();
            ConstList.InitSupplier(_SupplierModels);
        }

        public void loadedEnterprise()
        {
           // _EnterpriseModels= context.
        }
    }
}
