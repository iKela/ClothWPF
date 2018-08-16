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

namespace ClothWPF.Enterprise
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        public List<Entities.Product> _ProductFullInfo;
        bool hasBeenClicked = false;

        public ProductList()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void TextBox_Focus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_NewGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_NewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddItem newProduct = new AddItem();
            newProduct._additemClose = false;
            newProduct.ShowDialog();
        }

        private void LoadProducts()
        {
            productListGrid.ItemsSource = null;
            productListGrid.Items.Clear();
            _ProductFullInfo = new List<Entities.Product>();
            using (EfContext context = new EfContext())
            {
                foreach (var product in context.Products)
                {
                    _ProductFullInfo.Add(new Entities.Product
                    {
                        IdProduct = product.IdProduct,
                        Code = product.Code,
                        Name = product.Name,
                        Count = product.Count,
                        PriceDollar = product.PriceDollar,
                        PriceUah = product.PriceUah,
                        PriceRetail = product.PriceRetail,
                        PriceWholesale = product.PriceWholesale,
                        Country = product.Country
                    });
                }
                productListGrid.ItemsSource = _ProductFullInfo;
            }
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txt_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (tb_SearchByName.Visibility == Visibility.Visible)
            {
                var filtered = _ProductFullInfo.Where(product => product.Name.StartsWith(txt_Search.Text));
                productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByProductCode.Visibility == Visibility.Visible)
            {
                var filtered = _ProductFullInfo.Where(product => product.Code.StartsWith(txt_Search.Text));
                productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByCountry.Visibility == Visibility.Visible)
            {
                var filtered = _ProductFullInfo.Where(product => product.Country.StartsWith(txt_Search.Text));
                productListGrid.ItemsSource = filtered;
            }
        }

        private void btn_SearchByName_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Visible;
            tb_SearchByProductCode.Visibility = Visibility.Hidden;
            tb_SearchByCountry.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByProductCode_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByProductCode.Visibility = Visibility.Visible;
            tb_SearchByCountry.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByCountry_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByProductCode.Visibility = Visibility.Hidden;
            tb_SearchByCountry.Visibility = Visibility.Visible;
        }
    }
}
