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
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Country = p.Country
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
                context.Arrivals.Add(new Arrival
                {
                    Count = count,
                    ManufactureDate = Convert.ToDateTime(txt_ManufactureDate),
                    PriceDollar = priceDollar,
                    PriceWholesale = wholesalePrice,
                    PriceRetail = retailerPrice,
                    IdProduct = productModels[cmb_Name.SelectedIndex].Id
                });
                context.SaveChanges();        
                MessageBox.Show("Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
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
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
        }

        
    }
}
