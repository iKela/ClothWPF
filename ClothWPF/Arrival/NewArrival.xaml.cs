using ClothWPF.Entities;
using ClothWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Transactions;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for NewArrival.xaml
    /// </summary>
    public partial class NewArrival : Window
    {
        EfContext context = new EfContext();
        int idarrival;
        public double TotalPurchase { get; set; }
        public List<NewArrivalModel> ArrproductModels;
        public List<Product> _products;
        public NewArrival()
        {
            InitializeComponent();
            ArrproductModels = new List<NewArrivalModel>();    
        }
        
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e) 
        {
            AddProduct addProduct = new AddProduct(this);
            addProduct._close = false;
            addProduct.ShowDialog();
            if (addProduct._close == true)
            {
                var data = new NewArrivalModel
                {
                    IdProduct = addProduct._idproduct,

                    Name = addProduct._name,
                    Code = addProduct._code,
                    Article = addProduct._article,
                    CountArrival = addProduct._count,
                    PriceRetailArrival = addProduct._priceRetail,
                    PriceWholesaleArrival = addProduct._priceWholesale,
                    PriceDollarArrival = addProduct._priceDollar,
                    ManufactureDateArrival = addProduct._manufactureDate
                };
                    TotalPurchase += (addProduct._priceDollar * addProduct._count);
                ArrproductModels.Add(data);
                arrivalGrid.Items.Add(data);
            }
        }
      
        private void btn_DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentPrincipal.IsInRole("Administrators"))
            {
                var selectedItem = arrivalGrid.SelectedItem;
                if (selectedItem != null)
                {
                    arrivalGrid.Items.Remove(selectedItem);
                }
            }
            else
            {
                MessageBox.Show("Ви не володієте правами для видалення", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btn_AddFilledArrival_Click(object sender, RoutedEventArgs e)
        {
            Arrival.ArrivalInfo info = new Arrival.ArrivalInfo();
            info._formclosing = false;
                info.totalPurchaise = TotalPurchase;
            info.ShowDialog();
            if(info._formclosing==true)
            {
            idarrival = info.Idarrival;
                Add();
            }
        }
       
        private void Add()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var product in ArrproductModels)   //переробити
                    {
                        context.ArrivalProducts.Add(new ArrivalProduct
                        {
                            Count = product.CountArrival,
                            PriceDollar = product.PriceDollarArrival,
                            PriceUah = product.PriceUahArrival,
                            PriceRetail = product.PriceRetailArrival,
                            PriceWholesale = product.PriceWholesaleArrival,
                            ManufactureDate = product.ManufactureDateArrival,
                            Idarrival = idarrival,
                            Idproduct = product.IdProduct
                        });
                        var std = context.Products.Where(c => c.IdProduct == product.IdProduct).FirstOrDefault();
                        std.PriceDollar = product.PriceDollarArrival;
                        std.PriceRetail = product.PriceRetailArrival;
                        std.PriceWholesale = product.PriceWholesaleArrival;
                        double? sum = std.Count == null ? product.CountArrival : std.Count + product.CountArrival;
                        std.Count = sum;
                    }
                    context.SaveChanges();
                    scope.Complete();
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
