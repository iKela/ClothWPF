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

namespace ClothWPF.Enterprise
{
    /// <summary>
    /// Interaction logic for EnterpriseWindow.xaml
    /// </summary>
    public partial class EnterpriseWindow : Window
    {
       
        public EnterpriseWindow()
        {
            InitializeComponent();
            //cmb_Activity.ItemsSource = null;
            //cmb_Category.ItemsSource = null;
            cmb_LegalForm.ItemsSource = null;
            //cmb_OwnershipType.ItemsSource = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {   
            DataContext = new Entities.Enterprise();
        }

        private void cmb_OwnershipType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_CreatingWay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_EconomicPartnership_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_AssociationOfEnterprises_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_Activity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmb_LegalForm_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
