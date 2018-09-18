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

namespace ClothWPF.General.Realization
{
    /// <summary>
    /// Interaction logic for RealizationInfo.xaml
    /// </summary>
    public partial class RealizationInfo : Window
    {
        public RealizationInfo()
        {
            InitializeComponent();

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TxtRealizationDate.Text = DateTime.Today.Date.ToShortDateString().Replace(".", null);
            TxtDeliveryDate.Text = DateTime.Today.Date.ToShortDateString().Replace(".", null);
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Cmb_Customer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Cmb_Organization_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_NewOrganization_OnClick(object sender, RoutedEventArgs e)
        {
            
        }


        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
