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
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Yuriy\Desktop\Firstdbadonet.mdf;Integrated Security=True;Connect Timeout=30");


        public ObservableCollection<string> list = new ObservableCollection<string>();
        public AddProduct()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_Name.SelectedItem != null)
            {
                string query =
                     "update Product " + $"set PriceDollar = '{txt_SuppierPrice.Text}', " + $"Metric = '{txt_Count.Text}', " + $"PriceRetail = '{txt_PriceRetailer.Text}', " + $"PriceWholesale = '{txt_PriceWholeSale.Text}', " + $"where Name = {cmb_Name.SelectionBoxItem}";//KodProductu = {txt_ProductCode}";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
                MessageBox.Show("Не вибраний продукт!");
        }

        private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = $"SELECT * From Product where  Name = '{cmb_Name.Text}'";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            
            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                txt_Count.Text = sqlReader["Metric"].ToString();
                // txt_Discont.Text = sqlReader["Date"].ToString();
                // txt_ManufactureDate.Text = sqlReader["info"].ToString();
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
            connection.Open();
            string qwery = $"SELECT Name FROM Product";
            SqlCommand command = new SqlCommand(qwery, connection);
            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                list.Add(sqlReader["Name"].ToString());
                //cmb_Name.Text = sqlReader["Name"].ToString();
            }
            connection.Close();
            sqlReader.Close();
            cmb_Name.SelectedItem = true;
            this.cmb_Name.ItemsSource = list;
        }
    }
}
