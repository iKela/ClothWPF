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
using ClothWPF.Authorization.Loading;
using ClothWPF.Models.ArrivalInfo;
using Microsoft.EntityFrameworkCore.Internal;

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

        public int _idsupplier = 0;
        public int _identerprise = 0;
        public ArrivalsList(object mi)
        {
            InitializeComponent();
            txt_DateFrom.Text = DateTime.Today.ToShortDateString();
            txt_DateTo.Text = DateTime.Today.ToShortDateString();
            SetUpComesVizualization();
        }
        private void grid_Arrivals_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
            loadedRealization();
            AutoNameConterparty.ItemsSource = null;
            AutoNameConterparty.ItemsSource = ConstList.GetSupplierList;
            AutoNameEnterprise.ItemsSource = null;
            AutoNameEnterprise.ItemsSource = ConstList.GetEnterpriseList;
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
                        NameProduct = ap.ProductOf.Name,
                       Article = ap.ProductOf.Article,
                       TotalPurshaise = ap.TotalPurshaise
                    }).ToList();
                grid_ArrivalInfo.ItemsSource = arrId;
                grid_ArrivalInfo.Items.Refresh();
            }
        }

        public void loaded()
        {
            try
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
                                //ComesTo = a.ComesTo,
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Close();
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
                        .Include(s => s.GetSupplier)                        
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
                            DateRealization = a.DateRealization,
                            ClientName = a.GetSupplier.NameSupplier,  
                            Profit = a.Profit
                        }).ToList();
                    GridRealization.ItemsSource = realiz;
                    TxtTotalProfitSum.Text = realiz.Select(a => a.Profit).Sum().ToString();
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
        }
        private void btn_HideHamburger_Click(object sender, RoutedEventArgs e)
        {
            btn_ShowHamburger.Visibility = Visibility.Visible;
            btn_HideHamburger.Visibility = Visibility.Collapsed;
        }
        private void SetUpComesVizualization()
        {
            grid_Arrivals.Visibility = Visibility.Visible;
            grid_ArrivalInfo.Visibility = Visibility.Visible;
            GridRealization.Visibility = Visibility.Collapsed;
            GridRealizationItems.Visibility = Visibility.Collapsed;
            TxtTotalProfitSum.Visibility = Visibility.Collapsed;
            TabStatus.Visibility = Visibility.Collapsed;
            GridRealization.Margin = new Thickness(0);
        }
        private void SetUpRealizationVizualization()
        {
            grid_Arrivals.Visibility = Visibility.Collapsed;
            grid_ArrivalInfo.Visibility = Visibility.Collapsed;
            GridRealization.Visibility = Visibility.Visible;
            GridRealizationItems.Visibility = Visibility.Visible;
            TxtTotalProfitSum.Visibility = Visibility.Visible;
            TabStatus.Visibility = Visibility.Visible;
            GridRealization.Margin = new Thickness(0,20,0,0);
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
       
        }

        private void GridRealization_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadedGridRealizationInfo();
        }

        private void AutoNameConterparty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (SupplierModel)AutoNameConterparty.SelectedItem;
                _idsupplier = ConstList._Supplier.FirstOrDefault
                        (s => s.IdSupplier == selected.IdSupplier)
                    .IdSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AutoNameEnterprise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (EnterpriseModel)AutoNameEnterprise.SelectedItem;
                _identerprise = ConstList._Enterprise.FirstOrDefault
                        (s => s.IdEnterprise == selected.IdEnterprise)
                    .IdEnterprise;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
