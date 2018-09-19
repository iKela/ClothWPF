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
using ClothWPF.Entities;

namespace ClothWPF.General.Lists
{
    /// <summary>
    /// Interaction logic for WCounterparty.xaml
    /// </summary>
    public partial class WCounterparty : Window
    {
        bool hasBeenClicked = false;
        private List<Supplier> s;
        public WCounterparty()
        {
            InitializeComponent();
            s=new List<Supplier>();
            using (EfContext c= new EfContext())
            {
                foreach (var v in c.Suppliers)
                {
                    s.Add(new Supplier
                    {
                        NameSupplier = v.NameSupplier,
                        City = v.City,
                        AdressSupplier = v.AdressSupplier,
                        NumberSupplier = v.NumberSupplier,
                        Email = v.Email,
                        Currency = v.Currency,
                        Discount = v.Discount,
                        Region = v.Region,
                        DiscountCardNumber = v.DiscountCardNumber,
                        Category = v.Category,
                        FullName = v.FullName,
                        LegalAddress = v.LegalAddress,
                        MaxAmountOfDebt = v.MaxAmountOfDebt,
                        VATPlayerNumber = v.VATPlayerNumber,
                        ContractNumber = v.ContractNumber,
                        ContractDate = v.ContractDate,
                        IndividualTaxNumber = v.IndividualTaxNumber,
                        KindOfResponsibility = v.KindOfResponsibility
                    });
                }
            }

            GridCounterparty.ItemsSource = s;
        }

        private void TextBox_Focus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }
        private void txt_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (tb_SearchByName.Visibility == Visibility.Visible)
            {
                //var filtered = _ProductFullInfo.Where(product => product.Name.StartsWith(txt_Search.Text));
                // productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByCity.Visibility == Visibility.Visible)
            {
                //var filtered = _ProductFullInfo.Where(product => product.Code.StartsWith(txt_Search.Text));
                // productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByPhoneNumber.Visibility == Visibility.Visible)
            {
                // var filtered = _ProductFullInfo.Where(product => product.Country.StartsWith(txt_Search.Text));
                // productListGrid.ItemsSource = filtered;
            }
            if (tb_SearchByRegion.Visibility == Visibility.Visible)
            {
               
            }
            if (tb_SearchDicountCard.Visibility == Visibility.Visible)
            {

            }
            if (tb_SearchEmail.Visibility == Visibility.Visible)
            {

            }
        }

        private void btn_SearchByName_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Visible;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByCity_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Visible;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByRegion_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Visible;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchPhoneNumber(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Visible;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByEmail_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Visible;
        }

        private void btn_SearchByDiscountCard(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchByPhoneNumber.Visibility = Visibility.Hidden;
            tb_SearchByRegion.Visibility = Visibility.Hidden;
            tb_SearchDicountCard.Visibility = Visibility.Visible;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void BtnAddCounterparty_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
