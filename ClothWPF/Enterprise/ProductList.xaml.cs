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
using ClothWPF.General.Realization;
using ClothWPF.Models.Group;
using ClothWPF.Models.Main;

namespace ClothWPF.Enterprise
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
      
        //public object item { get; set; }
        public int _idproduct { get; set; }
        public double? _count { get; set; }
        public string _nameProduct { get; set; }
        public double? _supplierPrice { get; set; }
        public double? _priceWholesale { get; set; }
        public double? _priceRetail { get; set; }
        public string _codeProduct { get; set; }
        bool hasBeenClicked = false;
        public bool _allow { get; set; }


        public ProductList()
        {
            InitializeComponent();

            tb_SearchByName.Visibility = Visibility.Visible;
            tb_SearchByProductCode.Visibility = Visibility.Hidden;
            tb_SearchByCountry.Visibility = Visibility.Hidden;
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
            var GetId = new RealizationWindow();
            var selected = (ProductModel)productListGrid.SelectedItem;

            _allow = GetId._ListProduct.Exists(a =>  a.Idproduct == ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).IdProduct);
            if (!_allow)
            {
                                    //===РЕАЛІЗУВАТИ ЦЕЙ МЕТОД LINQ ===//
                //ConstList._FullInfo.Where(s => s.IdProduct == selected.IdProduct).Select(a => new 
                //{
                //    _idproduct = a.IdProduct,  _nameProduct = a.Name,   _count = a.Count,
                //    _codeProduct=a.Code, _priceWholesale =a.PriceWholesale,
                //    _supplierPrice=a.PriceUah,  _priceRetail=a.PriceRetail
                //});
                
                _idproduct = ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).IdProduct;
                _nameProduct = ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).Name;
                _count = ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).Count;
                _codeProduct = ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).Code;
                _priceWholesale = ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).PriceWholesale;
                _supplierPrice = ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).PriceUah;
                _priceRetail = ConstList._FullInfo.Find(s => s.IdProduct == selected.IdProduct).PriceRetail;
            }
            //item = (ProductModel)productListGrid.SelectedItem;
            Close();            
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
                productListGrid.ItemsSource = ConstList._FullInfo;
            listBoxGroups.ItemsSource = ConstList.GetGroupList;
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void listBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var d = (GroupModel)listBoxGroups.SelectedItem;
            if (listBoxGroups.SelectedItem != null)
            {
                if (d.IdGroup != 1)
                {
                    productListGrid.ItemsSource = null;
                    productListGrid.ItemsSource =
                        ConstList._FullInfo.Where(item => item.idGroup == d.IdGroup);
                }
                else
                {
                    productListGrid.ItemsSource = null;
                    productListGrid.ItemsSource = ConstList._FullInfo;
                }
            }
        }
    }
}
