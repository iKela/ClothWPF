using ClothWPF.Entities;
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
using ClothWPF.Authorization.Loading;
using ClothWPF.Models;

namespace ClothWPF.Arrival.Supplier
{
    /// <summary>
    /// Interaction logic for SupplierInfo.xaml
    /// </summary>
    public partial class SupplierInfo : Window
    {
        public bool _supplierClose { get; set; }
        public SupplierInfo()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch(index)
            {
                case 0:
                    {
                        GridGeneralInfo.Visibility = Visibility.Visible;
                        GridAdditionInfo.Visibility = Visibility.Collapsed;
                        break;
                    }
                case 1:
                    {
                        GridGeneralInfo.Visibility = Visibility.Collapsed;
                        GridAdditionInfo.Visibility = Visibility.Visible;
                        break;
                    }
                default:
                    {
                        GridGeneralInfo.Visibility = Visibility.Visible;
                        GridAdditionInfo.Visibility = Visibility.Collapsed;
                        break;
                    }
            }
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            double maxamountofdebt = 0;
            Double.TryParse(txt_MaxAmountOfDebt.Text, out maxamountofdebt);
            using (EfContext context = new EfContext())
            {
                try
                {
                    context.Suppliers.Add(new Entities.Supplier
                    {
                        NameSupplier = txt_Name.Text,
                        City = txt_City.Text,
                        AdressSupplier = txt_Address.Text,
                        NumberSupplier = txt_PhoneNumber.Text,
                        Email = txt_Email.Text, Region = txt_Region.Text,
                        Currency = cmb_Currency.Text,
                        Discount = Convert.ToDouble(TxtDiscount.Text),
                        Category = cmb_Category.Text,
                        FullName = TxtFullName.Text,
                        LegalAddress = TxtLegalAddress.Text,
                        MaxAmountOfDebt= maxamountofdebt,
                        VATPlayerNumber = txt_VATPlayerNumber.Text,
                        ContractNumber = txt_ContractNumber.Text,
                        ContractDate = Convert.ToDateTime(txt_ContractDate.Text),
                        KindOfResponsibility = cmb_KindOfResponsibility.Text                     
                    });
                    context.SaveChanges();
                    ConstList._Supplier.Add( new SupplierModel
                    {
                        NameSupplier = txt_Name.Text,
                        City = txt_City.Text,
                        AdressSupplier = txt_Address.Text,
                        NumberSupplier = txt_PhoneNumber.Text,
                        Email = txt_Email.Text,
                        Region = txt_Region.Text,
                        Currency = cmb_Currency.Text,
                        Discount = Convert.ToDouble(TxtDiscount.Text),
                        Category = cmb_Category.Text,
                        FullName = TxtFullName.Text,
                        LegalAddress = TxtLegalAddress.Text,
                        MaxAmountOfDebt = maxamountofdebt,
                        VATPlayerNumber = txt_VATPlayerNumber.Text,
                        ContractNumber = txt_ContractNumber.Text,
                        ContractDate = Convert.ToDateTime(txt_ContractDate.Text),
                        KindOfResponsibility = cmb_KindOfResponsibility.Text
                    });
                    _supplierClose = true;
                    MessageBox.Show("Зберeженно!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Txt_MaxAmountOfDebt_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)))
            {
                e.Handled = true;
            }
        }
    }
}
