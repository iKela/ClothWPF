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

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for NewArrival.xaml
    /// </summary>
    public partial class NewArrival : Window
    {
        EfContext context = new EfContext();
        
        
        public List<ProductModel> productModels;
        public NewArrival()
        {
            InitializeComponent();
            productModels = new List<ProductModel>();
           
        }
        public void loaded()
        {
            arrivalGrid.ItemsSource = productModels.ToList();

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
        private void Writhing()
        {

        }
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
            loaded();
          
          
        }
      

            private void btn_DeleteProduct_Click(object sender, RoutedEventArgs e)
        {

            //if (Thread.CurrentPrincipal.IsInRole("Administrators"))
            //{
            //    Product objP = ((FrameworkElement)sender).DataContext as Product;
            //    Arrival objA = ((FrameworkElement)sender).DataContext as Arrival;
            //    if (arrivalGrid.SelectedItem != null)
            //    {
            //        try
            //        {
            //            using (EfContext context = new EfContext())
            //            {
            //                context.Arrivals.Remove(context.Arrivals.Find(objA.Id));
            //                context.Products.Remove(context.Products.Find(objP.Id));
            //                context.SaveChanges();
            //            }
            //            loaded();
            //            MessageBox.Show("Видалено");
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ви не володієте правами для видалення");
            //}
        }

        private void arrivalGrid_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_AddFilledArrival_Click(object sender, RoutedEventArgs e)
        {
            Arrival.ArrivalInfo info = new Arrival.ArrivalInfo();
            info.ShowDialog();
        }
    }
}
