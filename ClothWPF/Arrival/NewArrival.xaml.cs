using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for NewArrival.xaml
    /// </summary>
    public partial class NewArrival : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\iKela\Desktop\Firstdbadonet.mdf;Integrated Security=True;Connect Timeout=30");

        public NewArrival()
        {
            InitializeComponent();
            
        }
        public void UpdateProduct()
        {
            string query = "select * from Product";
            connection.Open();
        
            DataTable dt2 = new DataTable("Product");
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt2);
            }
           
           arrivalGrid.ItemsSource = dt2.DefaultView;
            connection.Close();
        }


        private void arrivalGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void btn_DeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void arrivalGrid_Loaded(object sender, RoutedEventArgs e)
        {
           // UpdateProduct();
        }
    }
}
