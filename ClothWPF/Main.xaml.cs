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
    /// Interaction logic for Main.xaml
    /// </summary>
    ///
    public partial class Main : Window
    {
        int KodProductu;
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\iKela\Desktop\Firstdbadonet.mdf;Integrated Security=True;Connect Timeout=30");
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            FillDataGrid();
        }
        public void FillDataGrid()
        {
            List<Classes.Clothes> clothesList = new List<Classes.Clothes>()
            {
                // Місце для додавання
                new Classes.Clothes{Name="Рожа", ProductCode="87563", Price= 65, Lenght=400, Country="Ukraine"},
                new Classes.Clothes{Name="Авсвав", ProductCode="234", Price= 80, Lenght=600, Country="Ukraine"}
            };
            clothesGrid.ItemsSource = clothesList;
        }
        public void RefreshDataGrid()
        {
            CollectionViewSource.GetDefaultView(clothesGrid.ItemsSource).Refresh();
        }
        private void mi_NewArrival_Click(object sender, RoutedEventArgs e)
        {
            NewArrival newArrival = new NewArrival();
            newArrival.Show();
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_ShowHamburger_Click(object sender, RoutedEventArgs e)
        {
            btn_ShowHamburger.Visibility = Visibility.Collapsed;
            btn_HideHamburger.Visibility = Visibility.Visible;
        }

        private void btn_HideHamburger_Click(object sender, RoutedEventArgs e)
        {
            btn_ShowHamburger.Visibility = Visibility.Visible;
            btn_HideHamburger.Visibility = Visibility.Collapsed;
        }
       // public void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
           // KodProductu = Convert.ToInt32(DataGrid.SelectedRows[0].Cells[0].Value);
        //}
        private void clothesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void mi_NewItem_Click(object sender, RoutedEventArgs e)
        {
            NewProduct addProduct = new NewProduct();
            addProduct.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mi_AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.Show();
        }

        private void mi_WarehouseCondition_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mi_Settings_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsForm gridSettingsForm = new GridSettingsForm();
            gridSettingsForm.Show();
        }
    }
}
