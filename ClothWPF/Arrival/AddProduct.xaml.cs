using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClothWPF.Models.Main;
using ClothWPF.Entities;
using System.ComponentModel;
using System.Data.Entity.Core.Common.EntitySql;
using System.Windows.Input;
using System.Windows.Media;
using ClothWPF.Authorization.Loading;
using ClothWPF.Helpes;
using ClothWPF.Items.Group;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window // , INotifyPropertyChanged
    {

        #region
        public bool _close { get; set; }
        //public Product Productadding { get; set; }
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
       // public int? _sampleChoice { get; set; } // якщо ноль то не буде грузити
        #endregion
        //private string _window { get; set; }
        bool hasBeenClicked = false;

        public AddProduct(EfContext efContext)
        {
            InitializeComponent();
            productModels = ConstList.GetList;
            context = efContext;
            AutoName.ItemsSource = null; AutoName.SelectedItem = null; AutoName.ItemsSource = productModels; //AutoName.Items.Refresh();
        }
        public void loaded()
        {
            
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (txt_PriceRetailer.Text != String.Empty || txt_PriceWholeSale.Text != String.Empty)
            {
                #region Double Parse

                double count = 0;
                double wholesalePrice = 0;
                double retailerPrice = 0;
                Double.TryParse(txt_Count.Text, out count);
                Double.TryParse(txt_PriceWholeSale.Text, out wholesalePrice);
                Double.TryParse(txt_PriceRetailer.Text, out retailerPrice);
                double priceDollar = 0;
                Double.TryParse(txt_SuppierPrice.Text, out priceDollar);

                #endregion

                try
                {
                    _name = AutoName.Text;
                    _code = txt_ProductCode.Text;
                    _count = count;
                    _article = txt_Article.Text;
                    _priceRetail = retailerPrice;
                    _priceWholesale = wholesalePrice;
                    _priceDollar = priceDollar;
                    _manufactureDate = Convert.ToDateTime(txt_ManufactureDate.Text);
                    _close = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
       
        private void FunctionFeeling()
        {
            var selected = (ProductModel)AutoName.SelectedItem;
            //Product Productadding = new Product { IdProduct = selected.IdProduct };
            //try
            //{
                _idproduct = productModels.Find(s => s.IdProduct == selected.IdProduct).IdProduct;
                txt_ProductCode.Text = productModels.Find(s => s.IdProduct == selected.IdProduct).Code;
                txt_Article.Text = productModels.Find(s => s.IdProduct == selected.IdProduct).Article;
                txt_SuppierPrice.Text = productModels.Find(s => s.IdProduct == selected.IdProduct).PriceUah.ToString();
                TxtGroup.Text = productModels.Find(s => s.IdProduct == selected.IdProduct).Namegroup;
                txt_PriceRetailer.Text = context.ArrivalProducts.Where(p => p.Idproduct == selected.IdProduct).OrderByDescending(a => a.IdArrivalProduct).Take(3).Select(a => a.PriceRetail).Average().ToString();
                txt_PriceWholeSale.Text = context.ArrivalProducts.Where(p => p.Idproduct == selected.IdProduct).OrderByDescending(a => a.IdArrivalProduct).Take(3).Select(a => a.PriceWholesale).Average().ToString();
            //сууукааааа наканецто 5.30 15.08.2018
            //}
            //catch
            //{
            //    _idproduct = productModels.FirstOrDefault(s => s.IdProduct == selected.IdProduct).IdProduct;
            //    txt_ProductCode.Text = productModels.FirstOrDefault(s => s.IdProduct == selected.IdProduct)?.Code;
            //    txt_Article.Text = productModels.FirstOrDefault(s => s.IdProduct == selected.IdProduct)?.Article;
            //    txt_SuppierPrice.Text = productModels.FirstOrDefault(s => s.IdProduct == selected.IdProduct)?.PriceDollar.ToString();
            //    txt_PriceRetailer.Text = productModels.FirstOrDefault(s => s.IdProduct == selected.IdProduct)?.PriceRetail.ToString();
            //    txt_PriceWholeSale.Text = productModels.FirstOrDefault(s => s.IdProduct == selected.IdProduct)?.PriceWholesale.ToString();
            //}
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
            WNewGroup group = new WNewGroup();
            group.ShowDialog();
        }

        private void AutoName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FunctionFeeling();
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

        private void ChBox_Discount_OnChecked(object sender, RoutedEventArgs e)
        {
            txt_Discont.Visibility = Visibility.Visible;
        }

        private void ChBox_Discount_OnUnchecked(object sender, RoutedEventArgs e)
        {
            txt_Discont.Visibility = Visibility.Collapsed;
        }
    }
}
