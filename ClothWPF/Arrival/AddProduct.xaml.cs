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
                    Country = p.Country,
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
            try
            {
                //реалізувати додавання в продукт
                context.ArrivalProducts.Add(new ArrivalProduct
                {
                    Count = count,
                    ManufactureDate = Convert.ToDateTime(txt_ManufactureDate),
                    PriceDollar = priceDollar,
                    PriceWholesale = wholesalePrice,
                    PriceRetail = retailerPrice,
                    //Idarrival = 
                    Idproduct = productModels[cmb_Name.SelectedIndex].Id
                });
                context.SaveChanges();
                MessageBox.Show("Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //NewArrival newArrival = new NewArrival();
            //newArrival.arrivalGrid.Items.Add(new ProductModel
            //{
            //    Name = cmb_Name.SelectedItem.ToString(),
            //    Code = txt_ProductCode.Text,
            //    Count = count,
            //    PriceRetail = retailerPrice,
            //    PriceWholesale = wholesalePrice,
            //    PriceDollar = priceDollar
            //});

            Close();
        }

        private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                var selected = (ProductModel)cmb_Name.SelectedItem;
                Product Productadding = new Product { IdProduct = selected.Id };
              //idArrival треба підгрузити
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
