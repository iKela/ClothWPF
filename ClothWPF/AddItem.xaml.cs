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

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        bool field = false;
        public AddItem()
        {
            InitializeComponent();
        }

        private void txt_ProductCode_TextChanged(object sender, TextChangedEventArgs e)
        {

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

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

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
