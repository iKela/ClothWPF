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

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\iKela\Desktop\Firstdbadonet.mdf;Integrated Security=True;Connect Timeout=30");

        public AddProduct()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
        //Need add on form xml (DateArrival)
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            //if (cmb_Name.SelectedItem != null)
            //{
            //    connection.Open();
            //    string qwery = $"INSERT into Arrival(DateArrival, ManufactureDate, PriceDollar, PriceRetail, PriceWholesale, Metric)" +
            //        $"VALUES('{DateArrival.Text}', '{txt_ManufactureDate.Text}', '{txt_SuppierPrice.Text}', '{txt_PriceRetailer.Text}','{txt_Count.Text}')";
            //    SqlCommand command = new SqlCommand(qwery, connection);
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //    MessageBox.Show("Додано!");
            //}
            //else
            //    MessageBox.Show("Не вибраний продукт!");
        }

        private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = $"SELECT * From Product where  Name = '{cmb_Name.SelectedItem}'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            
            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                txt_Count.Text = sqlReader["Metric"].ToString();
                // txt_Discont.Text = sqlReader["Date"].ToString();
                txt_ManufactureDate.Text = sqlReader["ManufactureDate"].ToString();
                txt_PriceRetailer.Text = sqlReader["PriceRetail"].ToString();
                txt_ProductCode.Text = sqlReader["KodProductu"].ToString();
                txt_SuppierPrice.Text = sqlReader["PriceDollar"].ToString();
            }
            sqlReader.Close();
            connection.Close();
        }

        private void cmb_Name_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_NewProduct_Click(object sender, RoutedEventArgs e)
        {
            NewProduct newProduct = new NewProduct();
            newProduct.Show();
        }
    }
}
