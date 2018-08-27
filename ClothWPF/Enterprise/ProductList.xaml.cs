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
using ClothWPF.Models.Main;

namespace ClothWPF.Enterprise
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        public List<ProductModel> _ProductFullInfo;
        //public object item { get; set; }
        public int _idproduct { get; set; }
        public double? _count { get; set; }
        public string _nameProduct { get; set; }
        public double? _priceWholesale { get; set; }
        public string _codeProduct { get; set; }
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
            var selected = (ProductModel)productListGrid.SelectedItem;            
            _idproduct = _ProductFullInfo.Find(s => s.IdProduct == selected.IdProduct).IdProduct;
            _nameProduct = _ProductFullInfo.Find(s => s.IdProduct == selected.IdProduct).Name;
            _count = _ProductFullInfo.Find(s => s.IdProduct == selected.IdProduct).Count;
            _codeProduct = _ProductFullInfo.Find(s => s.IdProduct == selected.IdProduct).Code;
            _priceWholesale = _ProductFullInfo.Find(s => s.IdProduct == selected.IdProduct).PriceWholesale;
            
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
            using (EfContext context = new EfContext())
              {
                _ProductFullInfo = context.Products
             // .Include(b => b.GetGroupProduct)
                 .Select(a => new ProductModel
                 {
                     IdProduct = a.IdProduct,
                     Code = a.Code,
                     Name = a.Name,
                     Count = a.Count,
                     PriceDollar = a.PriceDollar,
                     PriceUah = a.PriceUah,
                     PriceRetail = a.PriceRetail,
                     PriceWholesale = a.PriceWholesale,
                     Country = a.Country,
                     //Namegroup = a.GetGroupProduct.NameGroup
                 }).ToList();
                
                productListGrid.ItemsSource = _ProductFullInfo;
                listBoxGroups.ItemsSource = _ProductFullInfo.Select(a => a.Namegroup);
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

        private void listBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxGroups.SelectedItem != null)
            {
                if (listBoxGroups.SelectedItem.ToString() != "Всі")
                {
                    productListGrid.ItemsSource = null;
                    productListGrid.ItemsSource = _ProductFullInfo.Where(v => v.Namegroup == listBoxGroups.SelectedItem.ToString());
                }
                else
                    listBoxGroups.ItemsSource = _ProductFullInfo.Select(a => a.Namegroup);
            }
        }
    }
}
