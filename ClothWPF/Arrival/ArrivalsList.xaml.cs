﻿using System;
using System.Collections.Generic;
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
using ClothWPF.Entities;
using System.Data.Entity;
using ClothWPF.Models;
using ClothWPF.Models.ArrivalsList;
using ClothWPF.Models.RealizationWindow;

namespace ClothWPF.Arrival
{
    /// <summary>
    /// Interaction logic for ArrivalsList.xaml
    /// </summary>
    public partial class ArrivalsList : Window
    {
        DateTime dateArrivalfrom;
        DateTime dateArrivalTo;
        EfContext context = new EfContext();
        public ArrivalsList()
        {
           InitializeComponent();
            txt_DateFrom.Text = DateTime.Today.ToShortDateString();
            txt_DateTo.Text = DateTime.Today.ToShortDateString();
        }
        private void grid_Arrivals_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }
        private void grid_Arrivals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadedGridArrivalInfo();
        }
        private void loadedGridArrivalInfo()
        {
            var selected = (ArrivalsModel)grid_Arrivals.SelectedItem;
            if (selected != null)
            {
               var arrId = context.ArrivalProducts
                    .Include(p => p.ProductOf)
                    .Where(ap => ap.Idarrival == selected.IdArrival)
                    .Select(ap => new ArrivalsProductModel
                    {
                        IdArrivalProduct = ap.IdArrivalProduct,
                        Count = ap.Count,
                        PriceDollar = ap.PriceDollar,
                        PriceUah = ap.PriceUah,
                        PriceRetail = ap.PriceRetail,
                        PriceWholesale = ap.PriceWholesale,
                        ManufactureDate = ap.ManufactureDate,
                        Idarrival = ap.Idarrival,
                        NameProduct = ap.ProductOf.Name
                    }).ToList();
                grid_ArrivalInfo.ItemsSource = arrId;
                grid_ArrivalInfo.Items.Refresh();
            }
        }

        public void loaded()
        {
            if (DateTime.TryParse(txt_DateFrom.Text, out dateArrivalfrom))
            {
                if (DateTime.TryParse(txt_DateTo.Text, out dateArrivalTo))
                {
                    dateArrivalfrom = Convert.ToDateTime(txt_DateFrom.Text);
                    dateArrivalTo = Convert.ToDateTime(txt_DateTo.Text);
                    grid_ArrivalInfo.ItemsSource = null;
                    var arrival = context.Arrivals
                        .Include(s => s.SupplierOf)
                        .Include(e => e.EnterpriseOf)
                        .Where(a => a.Date >= dateArrivalfrom && a.Date <= dateArrivalTo)
                        .Select(a => new ArrivalsModel
                        {
                            IdArrival = a.IdArrival,
                            Number = a.Number,
                            ComesTo = a.ComesTo,
                            Date = a.Date,
                            SupplierInvoice = a.SupplierInvoice,
                         //PaymentType = a.PaymentType,
                            Currency = a.Currency,
                            TotalPurchase = a.TotalPurchase,
                         //Comment = a.Comment,
                            nameSupplier = a.SupplierOf.NameSupplier,
                            nameEnterprise = a.EnterpriseOf.Name
                        }).ToList();

                    grid_Arrivals.ItemsSource = arrival;
                }
            }
            else
            {
                MessageBox.Show("Введіть правильно Дату!", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        public void loadedRealization()
        {
            if (DateTime.TryParse(txt_DateFrom.Text, out dateArrivalfrom))
            {
                if (DateTime.TryParse(txt_DateTo.Text, out dateArrivalTo))
                {
                    dateArrivalfrom = Convert.ToDateTime(txt_DateFrom.Text);
                    dateArrivalTo = Convert.ToDateTime(txt_DateTo.Text);
                    GridRealization.ItemsSource = null;
                    var realiz = context.Realizations
                        //.Include(s => s.GetClient)                        
                        .Where(a => a.DateRealization >= dateArrivalfrom && a.DateRealization <= dateArrivalTo)
                        .Select(a => new RealizationModel
                        {
                            IdRealization = a.IdRealization,
                            Number = a.Number,
                            Comment = a.Comment,
                            Currency = a.Currency,
                            PaymentSum = a.PaymentSum,
                            PaymentType = a.PaymentType,                           
                            TotalPurshaise = a.TotalPurshaise,                            
                           // ClientName = a.GetClient.NameClient,                           
                        }).ToList();

                    GridRealization.ItemsSource = realiz;
                }
            }
            else
            {
                MessageBox.Show("Введіть правильно Дату!", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void loadedGridRealizationInfo()
        {
            var selected = (RealizationModel)GridRealization.SelectedItem;
            if (selected != null)
            {
                var arrId = context.RealizationProducts
                    .Include(p => p.ProductOf)
                    .Where(ap => ap.IdRealization == selected.IdRealization)
                    .Select(ap => new RealizationProductModel
                    {
                        IdRealizationProduct = ap.IdRealizationProduct,
                        Name = ap.ProductOf.Name,
                        Code = ap.ProductOf.Code,
                        CountSale = ap.Count,
                        NDS = ap.NDS,
                        Discount = ap.DiscountProduct,
                        Sum = ap.TotalProductSum,
                        PriceDollar = ap.PriceDollar,
                        PriceUah = ap.PriceUah,
                        PriceRetail = ap.PriceRetail,
                        PriceWholesale = ap.PriceWholesale,
                        IdRealization = ap.IdRealization,                        
                    }).ToList();
                GridRealizationItems.ItemsSource = arrId;
                GridRealizationItems.Items.Refresh();
            }
        }
        private void grid_ArrivalInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsForm gridSettingsForm = new GridSettingsForm(TabIndex); ;
            gridSettingsForm.Show();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmb_Supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_Enterprise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txt_Date_LostFocus(object sender, RoutedEventArgs e)
        {
            grid_Arrivals.SelectedItem = null;
            loaded();
        }

        private void txt_DateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txt_DateTo.Focus();
            }
        }

        private void txt_DateTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                grid_Arrivals.Focus();
            }
        }
        private void btn_ShowHamburger_Click(object sender, RoutedEventArgs e)
        {
            btn_ShowHamburger.Visibility = Visibility.Collapsed;
            btn_HideHamburger.Visibility = Visibility.Visible;
            //FirstColumn.Width = new GridLength(200);
        }
        private void btn_HideHamburger_Click(object sender, RoutedEventArgs e)
        {
            btn_ShowHamburger.Visibility = Visibility.Visible;
            btn_HideHamburger.Visibility = Visibility.Collapsed;
            //FirstColumn.Width = new GridLength(50);
        }
        private void SetUpComesVizualization()
        {
            grid_Arrivals.Visibility = Visibility.Visible;
            grid_ArrivalInfo.Visibility = Visibility.Visible;
            GridRealization.Visibility = Visibility.Collapsed;
            GridRealizationItems.Visibility = Visibility.Collapsed;
        }
        private void SetUpRealizationVizualization()
        {
            grid_Arrivals.Visibility = Visibility.Collapsed;
            grid_ArrivalInfo.Visibility = Visibility.Collapsed;
            GridRealization.Visibility = Visibility.Visible;
            GridRealizationItems.Visibility = Visibility.Visible;
        }
        private void HamgurgerComes_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            SetUpComesVizualization();
        }

        private void HamburgerRealizations_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            SetUpRealizationVizualization();
        }

        private void GridRealizationItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadedGridRealizationInfo();
        }

        private void GridRealization_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadedRealization();
        }
    }
}
