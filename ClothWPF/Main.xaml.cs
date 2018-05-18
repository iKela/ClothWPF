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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            List<Classes.Clothes> clothesList = new List<Classes.Clothes>()
            {
                // Місце для додавання
                new Classes.Clothes{Name="Рожа", ProductCode="87563", Price= 65, Lenght=400, Country="Ukraine"},
                new Classes.Clothes{Name="Авсвав", ProductCode="234", Price= 80, Lenght=600, Country="Ukraine"}

            };
            clothesGrid.ItemsSource = clothesList;

           
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

        private void clothesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mi_NewItem_Click(object sender, RoutedEventArgs e)
        {
            NewProduct addProduct = new NewProduct();
            addProduct.Show();
        }
    }
}
