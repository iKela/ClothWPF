﻿using ClothWPF.Entities;
using ClothWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
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
        public List<NewArrivalModel> ArrproductModels;
        public List<Product> _products;
        public NewArrival()
        {
            InitializeComponent();
            ArrproductModels = new List<NewArrivalModel>();    
        }
        public void loaded()
        {
            //arrivalGrid.ItemsSource = productModels;

            ////  arrivalGrid.ItemsSource = null;
            //    arrivalGrid.Items.Clear();
            //var arrival = context.Arrivals.Join(context.Products, // другий набір
            //    a => a.IdProduct, // свойство-селектор объекта із першого набора
            //    p => p.Id, // свойство-селектор объекта із другого набора
            //(a, p) => new NewArrivalModel// результат
            //{
            //    IdProduct = p.Id, Name = p.Name, Code = p.Code,
            //    Country = p.Country, IdArrival = a.Id, CountArrival = a.Count,
            //    PriceDollarArrival = a.PriceDollar, PriceUahArrival = a.PriceUah,
            //    PriceRetailArrival = a.PriceRetail, PriceWholesaleArrival = a.PriceWholesale,
            //    ManufactureDateArrival = a.ManufactureDate
            //});
            //arrivalGrid.ItemsSource = arrival.ToList();



            //var arrivalquery = context.Products
            //    //.Include(p=>p.Arrivals)
            //    .Select(p => new ProductModel
            //    {
            //        Id = p.Id,
            //        Country = p.Country,
            //        Code = p.Code,
            //        Name = p.Name,
            //        arrivalModelslist = p.Arrivals.Select(a => new ArrivalModel
            //        {
            //            Id = a.Id,
            //            Count = a.Count,
            //            PriceDollar = a.PriceDollar,
            //            PriceRetail = a.PriceRetail,
            //            PriceUah = a.PriceUah,
            //            PriceWholesale = a.PriceWholesale,
            //            ManufactureDate = a.ManufactureDate
            //        }).ToList()
            //    });
        }

        private void arrivalGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e) 
        {
            bool allow = false;
            do
            {
               
                AddProduct addProduct = new AddProduct();
                addProduct.ShowDialog();
                var data = new NewArrivalModel
                {
                    IdProduct = addProduct._idproduct,
                    Name = addProduct._name,
                    Code = addProduct._code,
                    CountArrival = addProduct._count,
                    PriceRetailArrival = addProduct._priceRetail,
                    PriceWholesaleArrival = addProduct._priceWholesale,
                    PriceDollarArrival = addProduct._priceDollar,
                    ManufactureDateArrival = addProduct._manufactureDate
                };
                ArrproductModels.Add(data);
                arrivalGrid.Items.Add(data);
                allow = addProduct._closedWindow;
            } while (/*allow == true*/false);
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
                MessageBox.Show("Ви не володієте правами для видалення");
            }
        }

        private void arrivalGrid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {    
        }

        private void btn_AddFilledArrival_Click(object sender, RoutedEventArgs e)
        {
            Arrival.ArrivalInfo info = new Arrival.ArrivalInfo();
            info.ShowDialog();
            idarrival = info.Idarrival;          
        }
       
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var product in ArrproductModels)
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
                        context.SaveChanges();
                        var std = context.Products.Where(c => c.IdProduct == product.IdProduct).FirstOrDefault();
                        std.PriceDollar = product.PriceRetailArrival;                       
                        std.PriceRetail = product.PriceRetailArrival;
                        std.PriceWholesale = product.PriceWholesaleArrival;
                        std.Count = std.Count + product.CountArrival;
                        context.SaveChanges();
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
