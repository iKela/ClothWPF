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
using ClothWPF.Models.ArrivalInfo;

namespace ClothWPF.Enterprise
{
    /// <summary>
    /// Interaction logic for EnterpriseWindow.xaml
    /// </summary>
    public partial class EnterpriseWindow : Window
    {
        public bool _enterpriseClose { get; set; }
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
            DataContext = new EnterpriseClass();
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
            Close(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index)
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
            using (EfContext context = new EfContext())
            {
                try
                {
                    context.Enterprises.Add(new Entities.Enterprise
                    {
                        Name = txt_Name.Text,
                        City = txt_City.Text,
                        Adress = txt_Address.Text,
                        KodEDRPOU = txt_Code.Text,
                        Ownership = cmb_OwnershipType.Text,    //За формою властності
                        CreatingWay = cmb_CreatingWay.Text,    //Залужно від способу утворення та формування статутного капіталу
                        LegalForm = cmb_LegalForm.Text,//Залежно від організаційно-правової форми 
                        Activity = cmb_Activity.Text,//Вид діяльності 
                        IdentificationCode = txt_IdentificationNumber.Text,
                        Director            = txt_Director.Text,
                        Email               = txt_Email.Text,
                        Fax                 = txt_Fax.Text
                    });
                    context.SaveChanges();
                    ConstList._Enterprise.Add(new EnterpriseModel
                    {
                        Name = txt_Name.Text,
                        City = txt_City.Text,
                        Adress = txt_Address.Text,
                        KodEDRPOU = txt_Code.Text,
                        Ownership = cmb_OwnershipType.Text,
                        CreatingWay = cmb_CreatingWay.Text,
                        LegalForm = cmb_LegalForm.Text,
                        Activity = cmb_Activity.Text,
                        IdentificationCode = txt_IdentificationNumber.Text,
                        Director = txt_Director.Text,
                        Email = txt_Email.Text,
                        Fax = txt_Fax.Text
                    });
                    _enterpriseClose = true;
                    MessageBox.Show("Зберeженно!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    public class HeaderedSeparator : Control
    {
        public static DependencyProperty HeaderProperty =
            DependencyProperty.Register(
                "Header",
                typeof(string),
                typeof(HeaderedSeparator));

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
    }
}
