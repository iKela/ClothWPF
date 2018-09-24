using System;
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
using ClothWPF.Authorization.Loading;
using ClothWPF.Entities;
using ClothWPF.Items.Group;

namespace ClothWPF.General.Lists
{
    /// <summary>
    /// Interaction logic for WItemList.xaml
    /// </summary>
    public partial class WItemList : Window
    {
        bool hasBeenClicked = false;
        public WItemList()
        {
            InitializeComponent();
            productListGrid.ItemsSource = ConstList.GetList;
         
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
                var filtered = ConstList._FullInfo.Where(product => product.Name.StartsWith(txt_Search.Text));
                productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByProductCode.Visibility == Visibility.Visible)
            {
                var filtered = ConstList._FullInfo.Where(product => product.Code.StartsWith(txt_Search.Text));
                productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByCountry.Visibility == Visibility.Visible)
            {
                 var filtered = ConstList._FullInfo.Where(product => product.Country.StartsWith(txt_Search.Text));
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

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddItem newItem = new AddItem();
            newItem.ShowDialog();
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            WNewGroup addGroup = new WNewGroup();
            addGroup.ShowDialog();
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
