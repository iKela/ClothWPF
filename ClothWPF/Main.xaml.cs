using ClothWPF.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Main.xaml
    /// </summary>
    ///
    public partial class Main : Window
    {
        public List<Product> _ProductFullInfo;
        EfContext context = new EfContext();
        public Main()
        {
            InitializeComponent();
            _ProductFullInfo = new List<Product>();
            //try
            //{
            //        if (!context.Products.Any())
            //        {
            //            for (int i = 0; i < 50; i++)
            //            {
            //                Person person = new Person("uk");
            //                context.Students.Add(new Student
            //                {
            //                    FirstNameUkr = person.FirstName,
            //                    FirstNameEng = Translator.Translit(person.FirstName),
            //                    LastNameUkr = person.LastName,
            //                    LastNameEng = Translator.Translit(person.LastName),
            //                    Email = person.Email
            //                });
            //            }
            //            context.SaveChanges();
            //        }
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }
        public void loaded()
        {
            foreach (var product in context.Products)
            {
                _ProductFullInfo.Add(new Product
                {
                    Id = product.Id,
                    Code = product.Code,
                    Name = product.Name,
                    Count = product.Count,
                    PriceDollar = product.PriceDollar,
                    PriceUah = product.PriceUah,
                    PriceRetail = product.PriceRetail,
                    PriceWholesale = product.PriceWholesale,
                    Country = product.Country
                });
            }
            clothesGrid.ItemsSource = _ProductFullInfo;
        }
        private void mi_NewArrival_Click(object sender, RoutedEventArgs e)
        {
            NewArrival newArrival = new NewArrival();
            newArrival.Show();
        }
        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btn_ShowHamburger_Click(object sender, RoutedEventArgs e)
        {
            btn_ShowHamburger.Visibility = Visibility.Collapsed;
            btn_HideHamburger.Visibility = Visibility.Visible;
        }
        private void btn_HideHamburger_Click(object sender, RoutedEventArgs e)
        {
            btn_ShowHamburger.Visibility = Visibility.Visible;
            btn_HideHamburger.Visibility = Visibility.Collapsed;
        }
        private void mi_NewItem_Click(object sender, RoutedEventArgs e)
        {
            //NewProduct addProduct = new NewProduct();
            //addProduct.ProductAdded += Dlg_ProductAdded;
            //addProduct.ShowDialog();              
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void mi_AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.ShowDialog();
            clothesGrid.ItemsSource = null;
            clothesGrid.Items.Clear();
            loaded();
        }
        private void mi_WarehouseCondition_Click(object sender, RoutedEventArgs e)
        {

        }
        private void mi_Settings_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsForm gridSettingsForm = new GridSettingsForm();
            gridSettingsForm.Show();
        }
    }
}
