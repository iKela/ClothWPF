using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClothWPF.Models;
using ClothWPF.Entities;
using System.ComponentModel;
using System.Windows.Media;
using ClothWPF.Helpes;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window // , INotifyPropertyChanged
    {

        #region
        public bool _close { get; set; }
        public Product Productadding { get; set; }
        public List<ProductModel> productModels;
        private EfContext context;
        public int _idproduct { get; set; }
        public string _name { get; set; }
        public string _code { get; set; }
        public double _count { get; set; }
        public double? _priceRetail { get; set; }
        public double? _priceWholesale { get; set; }
        public double _priceDollar { get; set; }
        public DateTime? _manufactureDate { get; set; }
        public string _article { get; set; }
        public int? _sampleChoice { get; set; } // якщо ноль то не буде грузити
        #endregion
        private string _window { get; set; }
        bool hasBeenClicked = false;

        public AddProduct()
        {
            InitializeComponent();

          
           
            AutoName.ItemsSource = null; AutoName.SelectedItem = null; AutoName.ItemsSource = productModels; //AutoName.Items.Refresh();

        }
        public void loaded()
        {
            
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {          
            #region Double Parse
            double count = 0;
            double wholesalePrice = 0;
            double retailerPrice = 0;
            double priceDollar = 0;
            Double.TryParse(txt_Count.Text, out count);
            Double.TryParse(txt_PriceWholeSale.Text, out wholesalePrice);
            Double.TryParse(txt_PriceRetailer.Text, out retailerPrice);
            Double.TryParse(txt_SuppierPrice.Text, out priceDollar);
            #endregion
            try
            {
                _name = AutoName.Text; _code = txt_ProductCode.Text; _count = count;
                _article = txt_Article.Text; _priceRetail = retailerPrice; _priceWholesale = wholesalePrice;
                _priceDollar = priceDollar; _manufactureDate = Convert.ToDateTime(txt_ManufactureDate.Text);
                _close = true; Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void SingleSample()
        {
            var selected = (ProductModel)AutoName.SelectedItem;
            Product Productadding = new Product { IdProduct = selected.Id };
            _idproduct = productModels.FirstOrDefault(s => s.Id == selected.Id).Id;
            txt_ProductCode.Text = productModels.FirstOrDefault(s => s.Id == selected.Id)?.Code ?? throw new InvalidOperationException();
            txt_Article.Text = productModels.FirstOrDefault(s => s.Id == selected.Id)?.Article ?? throw new InvalidOperationException();
            txt_SuppierPrice.Text = productModels.FirstOrDefault(s => s.Id == selected.Id)?.PriceDollar.ToString() ?? throw new InvalidOperationException();
            txt_PriceRetailer.Text = productModels.FirstOrDefault(s => s.Id == selected.Id)?.PriceRetail.ToString() ?? throw new InvalidOperationException();
            txt_PriceWholeSale.Text = productModels.FirstOrDefault(s => s.Id == selected.Id)?.PriceWholesale.ToString() ?? throw new InvalidOperationException();
        }
        private void TripleSample()
        {
            var selected = (ProductModel)AutoName.SelectedItem;
            //Product Productadding = new Product { IdProduct = selected.Id };
            _idproduct = productModels.Find(s => s.Id == selected.Id).Id;
            txt_ProductCode.Text = productModels.Find(s => s.Id == selected.Id).Code;
            txt_Article.Text = productModels.Find(s => s.Id == selected.Id).Article;
            txt_SuppierPrice.Text = productModels.Find(s => s.Id == selected.Id).PriceDollar.ToString();
            txt_PriceRetailer.Text = context.ArrivalProducts.Where(p => p.Idproduct == selected.Id).OrderByDescending(a => a.IdArrivalProduct).Take(3).Select(a => a.PriceRetail).Average().ToString();
            txt_PriceWholeSale.Text = context.ArrivalProducts.Where(p => p.Idproduct == selected.Id).OrderByDescending(a => a.IdArrivalProduct).Take(3).Select(a => a.PriceWholesale).Average().ToString();
            //сууукааааа наканецто 5.30 15.08.2018
        }
        //private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    _sampleChoice = 2;//видалити при доробленні настройки
        //    switch (_sampleChoice)
        //    {
        //        case null :
        //            {
        //                MessageBox.Show("Не вибрано налаштування виведення цін!", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
        //                break;
        //            }
        //        case 1 :
        //            {
        //                SingleSample();
        //                break;
        //            }
        //        case 2 :
        //            {
        //                TripleSample();
        //                break;
        //            }    
        //    }
        //}
        
       private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           loaded();
        }

        private void btn_NewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddItem newProduct = new AddItem();
            newProduct._additemClose = false;
            newProduct.ShowDialog();
            //if (newProduct._additemClose == true) loaded();
        }

        private void btn_NewGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutoName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TripleSample();
        }

        private void AutoGroup_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                AutoCompleteBox box = sender as AutoCompleteBox;
                box.Text = String.Empty;
                box.Foreground = new SolidColorBrush(Colors.Black);
                hasBeenClicked = true;
            }
            hasBeenClicked = false;
        }
    }
}
