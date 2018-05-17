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

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private void btn_CurrencyExhange_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void checkBox_Discount_Checked(object sender, RoutedEventArgs e)
        {
            grb_Price.Height = 200;
            txt_Discount.Visibility = Visibility.Visible;
        }

        private void checkBox_Discount_Unchecked(object sender, RoutedEventArgs e)
        {
            grb_Price.Height = 160;
            txt_Discount.Visibility = Visibility.Collapsed;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
