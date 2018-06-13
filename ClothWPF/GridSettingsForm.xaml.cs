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
        private bool changesExist { get; set; }
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
            try
            { 
            if (Properties.Settings.Default.DGNameVisibility != checkBox_Name.IsChecked.Value)                Properties.Settings.Default.DGNameVisibility = checkBox_Name.IsChecked.Value;                changesExist = true;
            if (Properties.Settings.Default.DGItemCodeVisibility != checkBox_ItemCode.IsChecked.Value)        Properties.Settings.Default.DGItemCodeVisibility = checkBox_ItemCode.IsChecked.Value;        changesExist = true;
            if (Properties.Settings.Default.DGCountVisibility != checkBox_Count.IsChecked.Value)              Properties.Settings.Default.DGCountVisibility = checkBox_Count.IsChecked.Value;              changesExist = true;
            if (Properties.Settings.Default.DGLenghtVisibility != checkBox_Lenght.IsChecked.Value)            Properties.Settings.Default.DGLenghtVisibility = checkBox_Lenght.IsChecked.Value;            changesExist = true;
            if (Properties.Settings.Default.DGRetailVisibility != checkBox_RetailPrice.IsChecked.Value)       Properties.Settings.Default.DGRetailVisibility = checkBox_RetailPrice.IsChecked.Value;       changesExist = true;
            if (Properties.Settings.Default.DGWholesaleVisibility != checkBox_WholesalePrice.IsChecked.Value) Properties.Settings.Default.DGWholesaleVisibility = checkBox_WholesalePrice.IsChecked.Value; changesExist = true;
            if (Properties.Settings.Default.DGPurchaseDolPrice != checkBox_PurchaseDolPrice.IsChecked.Value)  Properties.Settings.Default.DGPurchaseDolPrice = checkBox_PurchaseDolPrice.IsChecked.Value;  changesExist = true;
            if (Properties.Settings.Default.DGPurchaseUahPrice != checkBox_PurchaseUahPrice.IsChecked.Value)  Properties.Settings.Default.DGPurchaseUahPrice = checkBox_PurchaseUahPrice.IsChecked.Value;  changesExist = true;
            if (Properties.Settings.Default.DGCountryVisibility != checkBox_Country.IsChecked.Value)          Properties.Settings.Default.DGCountryVisibility = checkBox_Country.IsChecked.Value;          changesExist = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (changesExist == true)
                {
                    Properties.Settings.Default.Save();
                    if(MessageBox.Show("Для того щоб застосувати зміни, потрібно перезапустити програму.\n" +
                        "Якщо ви бажаєте перезапустити її пізніше, натисніть \"Ні\" \nПерезапустити програму? ", "Увага", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }
                    

                }
                    this.Close();
            }

        }
    }
}
