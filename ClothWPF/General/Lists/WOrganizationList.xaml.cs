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
using ClothWPF.Enterprise;

namespace ClothWPF.General.Lists
{
    /// <summary>
    /// Interaction logic for WOrganizationList.xaml
    /// </summary>
    public partial class WOrganizationList : Window
    {
        bool hasBeenClicked = false;
        private List<Entities.Enterprise> e;
        public WOrganizationList()
        {
            InitializeComponent();
            e = new List<Entities.Enterprise>();
            using (EfContext c = new EfContext())
            {
                foreach (var v in c.Enterprises)
                {
                    e.Add(new Entities.Enterprise
                    {
                        Name = v.Name,
                        City = v.City,
                        Adress = v.Adress,
                        KodEDRPOU = v.KodEDRPOU,
                        Ownership = v.Ownership,
                        CreatingWay = v.CreatingWay,
                        LegalForm = v.LegalForm,
                        Activity = v.Activity,
                        IdentificationCode = v.IdentificationCode,
                        Director = v.Director,
                        Email = v.Email,
                        Fax = v.Fax,
                        Number = v.Number
                    });
                }
            }
            GridOrganizations.ItemsSource = e;
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
            if (tb_SearchEmail.Visibility == Visibility.Visible)
            {

            }
        }

        private void btn_SearchByName_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Visible;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByCity_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Visible;
            tb_SearchEmail.Visibility = Visibility.Hidden;
        }
        private void btn_SearchByEmail_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByCity.Visibility = Visibility.Hidden;
            tb_SearchEmail.Visibility = Visibility.Visible;
        }
        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAddOrganization_Click(object sender, RoutedEventArgs e)
        {
            EnterpriseWindow enterprise = new EnterpriseWindow();
            enterprise.ShowDialog();
        }
    }
}
