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

namespace ClothWPF.General.Lists
{
    /// <summary>
    /// Interaction logic for WCounterparty.xaml
    /// </summary>
    public partial class WCounterparty : Window
    {
        bool hasBeenClicked = false;

        public WCounterparty()
        {
            InitializeComponent();
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
        private void txt_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (tb_SearchByName.Visibility == Visibility.Visible)
            {
                //var filtered = _ProductFullInfo.Where(product => product.Name.StartsWith(txt_Search.Text));
                // productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByCity.Visibility == Visibility.Visible)
            {
                //var filtered = _ProductFullInfo.Where(product => product.Code.StartsWith(txt_Search.Text));
                // productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByPhoneNumber.Visibility == Visibility.Visible)
            {
                // var filtered = _ProductFullInfo.Where(product => product.Country.StartsWith(txt_Search.Text));
                // productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByRegion.Visibility == Visibility.Visible)
            {
               
            }
            if (tb_SearchDicountCard.Visibility == Visibility.Visible)
            {

            }
            if (tb_SearchEmail.Visibility == Visibility.Visible)
            {

            }
        }

        private void btn_SearchByName_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Visible;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByCity_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Visible;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByRegion_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Visible;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchPhoneNumber(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Visible;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByEmail_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Visible;
        }

        private void btn_SearchByDiscountCard(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Visible;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void BtnAddCounterparty_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
