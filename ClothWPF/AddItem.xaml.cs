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
            InitializeComponent();
            txt_DolCurrency.Text = Properties.Settings.Default.CurrencyExchangeDol.ToString();
        }

        private void checkBox_Discount_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            #region Double Parse
            double wholesalePrice = 0;
            double retailerPrice = 0;
            double priceDollar = 0;
            double priceUah = 0;
            Double.TryParse(txt_PriceWholesale.Text, out wholesalePrice);
            Double.TryParse(txt_PriceRetail.Text, out retailerPrice);
            Double.TryParse(txt_PriceDollar.Text, out priceDollar);
            Double.TryParse(txt_PriceUah.Text, out priceUah);
            #endregion
            using (EfContext context = new EfContext())
            {
                try
                {
                    if (Productadding != null)
                    {
                        var product = context.Products.Where(c => c.IdProduct == Productadding.IdProduct).FirstOrDefault();
                        //var product = context.Products.Find(Productadding.Id);
                        product.Name = txt_Name.Text;
                        product.Code = txt_ProductCode.Text;
                        product.PriceDollar = priceDollar;
                        product.PriceUah = priceUah;
                        product.PriceRetail = retailerPrice;
                        product.PriceWholesale = wholesalePrice;
                        product.Country = cmb_Country.Text;
                        Productadding = product;
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Products.Add(new Product
                        {
                            Name = txt_Name.Text,
                            Code = txt_ProductCode.Text,
                            PriceDollar = priceDollar,
                            PriceUah = priceUah,
                            PriceRetail = retailerPrice,
                            PriceWholesale = wholesalePrice,
                            Country = cmb_Country.Text
                        });
                        context.SaveChanges();
                    }
                    MessageBox.Show("Save");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void btn_CurrencyExhange_Click(object sender, RoutedEventArgs e)
        {
            double num;
            if (field == true)
            {
                double.TryParse(txt_PriceUah.Text.ToString(), out num);
                num = num / Properties.Settings.Default.CurrencyExchangeDol;
                txt_PriceDollar.Text = num.ToString();
                field = true;
            }
            else
            {
                double.TryParse(txt_PriceDollar.Text.ToString(), out num);
                num = num * Properties.Settings.Default.CurrencyExchangeDol;
                txt_PriceUah.Text = num.ToString();
                field = false;
            }
        }

        private void txt_DolCurrency_Click(object sender, RoutedEventArgs e)
        {
            txt_DolCurrency.IsReadOnly = false;
        }

        private void txt_DolCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(MessageBox.Show("Бажаєте змінити курс долара з " + Properties.Settings.Default.CurrencyExchangeDol.ToString() + " на " + txt_DolCurrency.Text + "?", "Увага!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    double dol;
                    double.TryParse(txt_DolCurrency.Text, out dol);
                    Properties.Settings.Default.CurrencyExchangeDol = dol;
                    Properties.Settings.Default.Save();
                    txt_DolCurrency.IsReadOnly = true;
                }
            }
        }

        private void txt_DolCurrency_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == ","))
            {
                e.Handled = true;
            }
        }
    }
}
