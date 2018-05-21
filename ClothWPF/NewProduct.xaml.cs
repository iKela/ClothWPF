using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\iKela\Desktop\Firstdbadonet.mdf;Integrated Security=True;Connect Timeout=30");
        public NewProduct()
        {
            InitializeComponent();
        }

        private void btn_CurrencyExhange_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void checkBox_Discount_Checked(object sender, RoutedEventArgs e)
        {
            grb_Price.Height = 200;
            txt_Discount.Visibility = Visibility.Visible;
        }

        private void checkBox_Discount_Unchecked(object sender, RoutedEventArgs e)
        {
            grb_Price.Height = 160;
            txt_Discount.Visibility = Visibility.Collapsed;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_ProductCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_Name.Text.Length ==0  || txt_ProductCode.Text.Length == 0 || cmb_Country.SelectedItem ==null || txt_PriceDollar.Text.Length == 0) throw new Exception("Не всі поля заповнені!") ;
                else
                {
                    connection.Open();
                    string qwery = $"INSERT into Product(KodProductu, Name, PriceDollar, PriceRetail, PriceWholesale, Country)" +
                        $"VALUES('{txt_ProductCode.Text}', '{txt_Name.Text}', '{txt_PriceDollar.Text}', '{txt_PriceRetail.Text}', '{txt_PriceWholesale.Text}', '{cmb_Country.SelectedItem.ToString()}')";
                    SqlCommand command = new SqlCommand(qwery, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Додано!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
                connection.Close();
            }
        }
    }
}
