using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClothWPF.Models;
using ClothWPF.Entities;
using Xceed.Wpf.Toolkit;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public Product Productadding { get; set; }
        public List<ProductModel> productModels;
        EfContext context = new EfContext();
        public int _idproduct { get; set; }
        public string _name { get; set; }
        public string _code { get; set; }
        public double? _count { get; set; }
        public double? _priceRetail { get; set; }
        public double? _priceWholesale { get; set; }
        public double? _priceDollar { get; set; }
        public DateTime _manufactureDate { get; set; }
        public bool _closedWindow { get; set; }

        public AddProduct()
        {
            InitializeComponent();
        }
        public void loaded()
        {
            productModels = new List<ProductModel>();
            foreach (var p in context.Products)
            {
                productModels.Add(new ProductModel
                {
                    Id = p.IdProduct,
                    Code = p.Code,
                    Name = p.Name,
                    Article = p.Article,
                    Count = p.Count,
                    PriceDollar = p.PriceDollar,
                    PriceRetail = p.PriceRetail,
                    PriceUah = p.PriceUah,
                    PriceWholesale = p.PriceWholesale
                });
            }
            cmb_Name.ItemsSource = productModels;
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
            //try
            //{
            //    //реалізувати додавання в продукт
            //    context.ArrivalProducts.Add(new ArrivalProduct
            //    {
            //        Count = count,
            //        ManufactureDate = Convert.ToDateTime(txt_ManufactureDate),
            //        PriceDollar = priceDollar,
            //        PriceWholesale = wholesalePrice,
            //        PriceRetail = retailerPrice,
            //        //Idarrival = 
            //        Idproduct = productModels[cmb_Name.SelectedIndex].Id
            //    });
            //    context.SaveChanges();
            //    MessageBox.Show("Save");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            var dateAndTime = Convert.ToDateTime(txt_ManufactureDate.Text);
            var date = dateAndTime.Date;

            _name = cmb_Name.Text;
            _code = txt_ProductCode.Text;
            _count = count;
            _priceRetail = retailerPrice;
            _priceWholesale = wholesalePrice;
            _priceDollar = priceDollar;
            try
            {
                _manufactureDate = date;
            }
            catch
            {

            }
            _closedWindow = true;
            Close();
        }
       
        private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                var selected = (ProductModel)cmb_Name.SelectedItem;
                Product Productadding = new Product { IdProduct = selected.Id };
                _idproduct = productModels.FirstOrDefault(s => s.Id == selected.Id).Id;
                txt_ProductCode.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).Code;
              //txt_Count.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).Count.ToString();
                txt_SuppierPrice.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).PriceDollar.ToString();
              //txt_PriceUah.Text = productModels.FirstOrDefault(s => s.Id == selected.IdProduct).PriceUah.ToString();
                txt_PriceRetailer.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).PriceRetail.ToString();
                txt_PriceWholeSale.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).PriceWholesale.ToString();
        }

        private void cmb_Name_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }

        private void btn_NewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddItem newProduct = new AddItem();
            newProduct.ShowDialog();
        }

        
    }
}
