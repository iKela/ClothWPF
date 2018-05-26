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
    /// Interaction logic for GridSettingsForm.xaml
    /// </summary>
    public partial class GridSettingsForm : Window
    {
        MainWindowViewModel mainViewModel;
        public GridSettingsForm()
        {
            InitializeComponent();
            mainViewModel = new MainWindowViewModel();
            checkBox_ItemCode.IsChecked =         mainViewModel.ItemCodeVisibility;
            checkBox_Name.IsChecked =             mainViewModel.NameVisibility;
            checkBox_Count.IsChecked =               mainViewModel.CountVisibility;
            checkBox_Lenght.IsChecked =           mainViewModel.LenghtVisibility;
            checkBox_RetailPrice.IsChecked =       mainViewModel.RetailVisibility;
            checkBox_WholesalePrice.IsChecked =      mainViewModel.WholeSaleVisibility;
            checkBox_PurchaseDolPrice.IsChecked = mainViewModel.PurchaseDolPrice;
            checkBox_PurchaseUahPrice.IsChecked = mainViewModel.PurchaseUahPrice;
            checkBox_Country.IsChecked =          mainViewModel.CountryVisibility;         
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.ItemCodeVisibility = checkBox_ItemCode.IsChecked.Value;
            mainViewModel.NameVisibility = checkBox_Name.IsChecked.Value;
            mainViewModel.CountVisibility = checkBox_Count.IsChecked.Value;
            mainViewModel.LenghtVisibility=  checkBox_Lenght.IsChecked.Value;
            mainViewModel.RetailVisibility=  checkBox_RetailPrice.IsChecked.Value;
            mainViewModel.WholeSaleVisibility = checkBox_WholesalePrice.IsChecked.Value;
            mainViewModel.PurchaseDolPrice =  checkBox_PurchaseDolPrice.IsChecked.Value;
            mainViewModel.PurchaseUahPrice =   checkBox_PurchaseUahPrice.IsChecked.Value;
            mainViewModel.CountryVisibility = checkBox_Country.IsChecked.Value;
                 
        }
    }
}
