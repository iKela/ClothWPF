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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Hello");
        }
    }
}
