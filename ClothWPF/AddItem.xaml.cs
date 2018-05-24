using ClothWPF.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        EfContext context = new EfContext();
      
        public Product Productadding { get; set; }
        bool field = false;
        public AddItem()
        {
            addItem();
        }
        public void addItem()
        {
            InitializeComponent();
        }

        private void btn_CurrencyExhange_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int num;
            if (field == true)
            {
                Int32.TryParse(txt_PriceUah.Text.ToString(), out num);
                num = num / 27;
                txt_PriceDollar.Text = num.ToString();
                field = true;
            }
            else
            {
                Int32.TryParse(txt_PriceDollar.Text.ToString(), out num);
                num = num * 27;
                txt_PriceUah.Text = num.ToString();
                field = false;
            }
            
        }

        private void checkBox_Discount_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        // FUNCTION FOR UPDATE

        //private void Update()
        //{
        //    if (Product != null)
        //    {
        //        var product = context.Products.Find(Product.Id);
        //        product.Name = txt_Name.Text;
        //        product.Code = txt_ProductCode.Text;
        //        product.Count = count;
        //        product.PriceDollar = priceDollar;
        //        product.PriceUah = priceUah;
        //        product.PriceRetail = retailerPrice;
        //        product.PriceWholesale = wholesalePrice;
        //        product.Country = cmb_Country.Text;

        //        context.SaveChanges();

        //        Product = product;
        //        ProductUpdated(this, new EventArgs());
        //    }
        //    else MessageBox.Show("ERROR");
        //}
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            #region Double Parse
            double count = 0;
            double wholesalePrice = 0;
            double retailerPrice = 0;
            double priceDollar = 0;
            double priceUah = 0;
            Double.TryParse(txt_Count.Text, out count);
            Double.TryParse(txt_PriceWholesale.Text, out wholesalePrice);
            Double.TryParse(txt_PriceRetail.Text, out retailerPrice);
            Double.TryParse(txt_PriceDollar.Text, out priceDollar);
            Double.TryParse(txt_PriceUah.Text, out priceUah);
            #endregion 
           

            try
            {
                Productadding = context.Products.Add(new Product
                {
                    Name = txt_Name.Text,
                    Code = txt_ProductCode.Text,
                    Count = count,
                    PriceDollar = priceDollar,
                    PriceUah = priceUah,
                    PriceRetail = retailerPrice,
                    PriceWholesale = wholesalePrice,
                    Country = cmb_Country.Text
                });
                context.SaveChanges();
                MessageBox.Show("Save");
            }  
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void txt_PriceDollar_TextChanged(object sender, TextChangedEventArgs e)
        {
            field = false;
        }

        private void txt_PriceUah_TextChanged(object sender, TextChangedEventArgs e)
        {
            field = true;
        }

        private void checkBox_Discount_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
