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
        private bool changesExist { get; set; }
        public GridSettingsForm()
        {
                   
        }
        private int win { get; set; }
        public GridSettingsForm(int window)
        {
            switch(window)
            {
                case 1:
                    {
                        InitializeComponent();
                        cmb_Window.SelectedIndex = 0;
                        win = window;
                        break;
                    }
                case 2:
                    {
                        InitializeComponent();
                        cmb_Window.SelectedIndex = 1;
                        win = window;
                        break;
                    }
            }
            checkBox_ItemCode.IsChecked         = Properties.Settings.Default.DGItemCodeVisibility;
            checkBox_Name.IsChecked             = Properties.Settings.Default.DGNameVisibility;
            checkBox_Count.IsChecked            = Properties.Settings.Default.DGCountVisibility;
            checkBox_Lenght.IsChecked           = Properties.Settings.Default.DGLenghtVisibility;
            checkBox_RetailPrice.IsChecked      = Properties.Settings.Default.DGRetailVisibility;
            checkBox_WholesalePrice.IsChecked   = Properties.Settings.Default.DGWholesaleVisibility;
            checkBox_PurchaseDolPrice.IsChecked = Properties.Settings.Default.DGPurchaseDolPrice;
            checkBox_PurchaseUahPrice.IsChecked = Properties.Settings.Default.DGPurchaseUahPrice;
            checkBox_Country.IsChecked          = Properties.Settings.Default.DGCountryVisibility;
            checkBox_Number.IsChecked           = Properties.Settings.Default.DGArrivals_Number;
            checkBox_Date.IsChecked             = Properties.Settings.Default.DGArrivals_Date;
            checkBox_PurchaseTotal.IsChecked    = Properties.Settings.Default.DGArrivals_PurchaseTotal;
            checkBox_Supplier.IsChecked         = Properties.Settings.Default.DGArrivals_Supplier;
            checkBox_Receiver.IsChecked         = Properties.Settings.Default.DGArrivals_Receiver;
            checkBox_WholeSale.IsChecked        = Properties.Settings.Default.DGArrivals_Wholesale;
            checkBox_Enterprise.IsChecked       = Properties.Settings.Default.DGArrivals_Enterprise;
            checkBox_User.IsChecked             = Properties.Settings.Default.DGArrivals_User;

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.DGNameVisibility         != checkBox_Name.IsChecked.Value)             Properties.Settings.Default.DGNameVisibility         = checkBox_Name.IsChecked.Value;             changesExist = true;
                if (Properties.Settings.Default.DGItemCodeVisibility     != checkBox_ItemCode.IsChecked.Value)         Properties.Settings.Default.DGItemCodeVisibility     = checkBox_ItemCode.IsChecked.Value;         changesExist = true;
                if (Properties.Settings.Default.DGCountVisibility        != checkBox_Count.IsChecked.Value)            Properties.Settings.Default.DGCountVisibility        = checkBox_Count.IsChecked.Value;            changesExist = true;
                if (Properties.Settings.Default.DGLenghtVisibility       != checkBox_Lenght.IsChecked.Value)           Properties.Settings.Default.DGLenghtVisibility       = checkBox_Lenght.IsChecked.Value;           changesExist = true;
                if (Properties.Settings.Default.DGRetailVisibility       != checkBox_RetailPrice.IsChecked.Value)      Properties.Settings.Default.DGRetailVisibility       = checkBox_RetailPrice.IsChecked.Value;      changesExist = true;
                if (Properties.Settings.Default.DGWholesaleVisibility    != checkBox_WholesalePrice.IsChecked.Value)   Properties.Settings.Default.DGWholesaleVisibility    = checkBox_WholesalePrice.IsChecked.Value;   changesExist = true;
                if (Properties.Settings.Default.DGPurchaseDolPrice       != checkBox_PurchaseDolPrice.IsChecked.Value) Properties.Settings.Default.DGPurchaseDolPrice       = checkBox_PurchaseDolPrice.IsChecked.Value; changesExist = true;
                if (Properties.Settings.Default.DGPurchaseUahPrice       != checkBox_PurchaseUahPrice.IsChecked.Value) Properties.Settings.Default.DGPurchaseUahPrice       = checkBox_PurchaseUahPrice.IsChecked.Value; changesExist = true;
                if (Properties.Settings.Default.DGCountryVisibility      != checkBox_Country.IsChecked.Value)          Properties.Settings.Default.DGCountryVisibility      = checkBox_Country.IsChecked.Value;          changesExist = true;
                if (Properties.Settings.Default.DGArrivals_Number        != checkBox_Name.IsChecked.Value)             Properties.Settings.Default.DGArrivals_Number        = checkBox_Number.IsChecked.Value;           changesExist = true;
                if (Properties.Settings.Default.DGArrivals_Date          != checkBox_ItemCode.IsChecked.Value)         Properties.Settings.Default.DGArrivals_Date          = checkBox_Date.IsChecked.Value;             changesExist = true;
                if (Properties.Settings.Default.DGArrivals_PurchaseTotal != checkBox_Count.IsChecked.Value)            Properties.Settings.Default.DGArrivals_PurchaseTotal = checkBox_PurchaseTotal.IsChecked.Value;    changesExist = true;
                if (Properties.Settings.Default.DGArrivals_Supplier      != checkBox_Lenght.IsChecked.Value)           Properties.Settings.Default.DGArrivals_Supplier      = checkBox_Supplier.IsChecked.Value;         changesExist = true;
                if (Properties.Settings.Default.DGArrivals_Receiver      != checkBox_RetailPrice.IsChecked.Value)      Properties.Settings.Default.DGArrivals_Receiver      = checkBox_Receiver.IsChecked.Value;         changesExist = true;
                if (Properties.Settings.Default.DGArrivals_Wholesale     != checkBox_WholesalePrice.IsChecked.Value)   Properties.Settings.Default.DGArrivals_Wholesale     = checkBox_WholeSale.IsChecked.Value;        changesExist = true;
                if (Properties.Settings.Default.DGArrivals_Enterprise    != checkBox_PurchaseDolPrice.IsChecked.Value) Properties.Settings.Default.DGArrivals_Enterprise    = checkBox_Enterprise.IsChecked.Value;       changesExist = true;
                if (Properties.Settings.Default.DGArrivals_User          != checkBox_PurchaseUahPrice.IsChecked.Value) Properties.Settings.Default.DGArrivals_User          = checkBox_User.IsChecked.Value;             changesExist = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            { 
                if (changesExist == true)
                {
                    Properties.Settings.Default.Save();
                    if (MessageBox.Show("Для того щоб застосувати зміни, потрібно перезапустити програму.\n" +
                        "Якщо ви бажаєте перезапустити її пізніше, натисніть \"Ні\" \nПерезапустити програму? ", "Увага", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        Application.Current.Shutdown();
                    }


                }
                this.Close();
            }

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((ComboBoxItem)e.Source).Uid);

            switch (index)
            {
                case 0:
                    {
                        listBox_MainWindowVisibility.Visibility = Visibility.Visible;
                        listBox_CheckBoxesOfMainWindowVisibility.Visibility = Visibility.Visible;
                        listBox_ArraysListVisibility.Visibility = Visibility.Collapsed;
                        listBox_CheckBoxesOfArraysListVisibilit.Visibility = Visibility.Collapsed;
                        break;
                    }
                case 1:
                    {
                        listBox_MainWindowVisibility.Visibility = Visibility.Collapsed;
                        listBox_CheckBoxesOfMainWindowVisibility.Visibility = Visibility.Collapsed;
                        listBox_ArraysListVisibility.Visibility = Visibility.Visible;
                        listBox_CheckBoxesOfArraysListVisibilit.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }
    }
}
