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

namespace ClothWPF.Arrival
{
    /// <summary>
    /// Interaction logic for ArrivalInfo.xaml
    /// </summary>
    public partial class ArrivalInfo : Window
    {
        public ArrivalInfo()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_NewSupplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier.SupplierInfo form = new Supplier.SupplierInfo();
            form.ShowDialog();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
