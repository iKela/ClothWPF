using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using ClothWPF.Authorization.Loading;
using ClothWPF.Models;
using ClothWPF.Models.ArrivalInfo;
using ClothWPF.Models.Group;
using ProductModel = ClothWPF.Models.Main.ProductModel;

namespace ClothWPF.Helpes
{
    public class Load
    {
        public List<GroupModel> _GroupList { get; set; }
        public List<ProductModel> _ProductFullInfo { get; set; }
        public List<EnterpriseModel> _EnterpriseModels { get; set; }
        public List<SupplierModel> _SupplierModels { get; set; }
        public EfContext context;
        public Load()
        {
            context = new EfContext();
        }

        public void loadedGroup()
        {
            _GroupList = context.GroupProducts.Select(a => new GroupModel
            {
                IdGroup = a.IdGroup,
                NameGroup = a.NameGroup,
                DescriptionGroup = a.DescriptionGroup,
                CodeGroup = a.CodeGroup,
                Nds = a.Nds,
                IdSubGrop = a.IdSubGrop
            }).ToList();
            ConstList.InitGroup(_GroupList);
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
                    Namegroup = a.GetGroupProduct.NameGroup,
                    idGroup =a.Idgroup
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
            _EnterpriseModels = context.Enterprises.Select(a => new EnterpriseModel
            {
                IdEnterprise = a.IdEnterprise,
                Name = a.Name,
                City = a.City,
                Adress = a.Adress,
                KodEDRPOU = a.KodEDRPOU,
                Ownership = a.Ownership,
                CreatingWay = a.CreatingWay,
                LegalForm = a.LegalForm,
                Activity = a.Activity,
                IdentificationCode = a.IdentificationCode,
                Director = a.Director,
                Email = a.Email,
                Fax = a.Fax,
                Number = a.Number
            }).ToList();
            ConstList.InitEnterprise(_EnterpriseModels);
        }
    }
}
