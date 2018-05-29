using ClothWPF.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Permissions;
using System.Threading;
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
//using ClothWPF.Authorization.Classes;
using System.Data;
using ClothWPF.Authorization;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    ///
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class Main : Window , IView
    {
        public List<Product> _ProductFullInfo;
        EfContext context = new EfContext();
        public Main()
        {  
            InitializeComponent();
        }
 
        #region IView Members
        public IViewModel ViewModel
        {
            get
            {
                return DataContext as IViewModel;
            }
            set
            {
                DataContext = value;
            }
        }
        #endregion
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_UserName.Text = Thread.CurrentPrincipal.Identity.Name;
            loaded();
        }
        public void loaded()
        {
            using (EfContext context = new EfContext())
            {
                clothesGrid.ItemsSource = null;
                clothesGrid.Items.Clear();
                _ProductFullInfo = new List<Product>();
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
        private void clothesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(clothesGrid.SelectedIndex.ToString());
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
        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
                if (Thread.CurrentPrincipal.IsInRole("Administrators"))
                {
                    Product obj = ((FrameworkElement)sender).DataContext as Product;
                    if (clothesGrid.SelectedItem != null)
                    {
                        try
                        {
                            using (EfContext context = new EfContext())
                            {
                                context.Products.Remove(context.Products.Find(obj.Id));
                                context.SaveChanges();
                            }
                            loaded();
                            MessageBox.Show("Видалено");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                MessageBox.Show("Ви не володієте правами для видалення");
                }
        }
        private void mi_AddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.ShowDialog();
            loaded();
        }
        private void mi_WarehouseCondition_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mi_Settings_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsForm gridSettingsForm = new GridSettingsForm(); ;
            gridSettingsForm.Show();         
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            if (clothesGrid.SelectedItem != null)
            {
                var selected = (Product)clothesGrid.SelectedItem;
                addItem.Title = "Редагувати";
                addItem.btn_Add.Content = "Зберегти";
                addItem.Productadding = new Product { Id = selected.Id };
                addItem.txt_Name.Text = _ProductFullInfo.FirstOrDefault(s => s.Id == selected.Id).Name;
                addItem.txt_ProductCode.Text = _ProductFullInfo.FirstOrDefault(s => s.Id == selected.Id).Code;
                addItem.txt_Count.Text = _ProductFullInfo.FirstOrDefault(s => s.Id == selected.Id).Count.ToString();
                addItem.txt_PriceDollar.Text = _ProductFullInfo.FirstOrDefault(s => s.Id == selected.Id).PriceDollar.ToString();
                addItem.txt_PriceUah.Text = _ProductFullInfo.FirstOrDefault(s => s.Id == selected.Id).PriceUah.ToString();
                addItem.txt_PriceRetail.Text = _ProductFullInfo.FirstOrDefault(s => s.Id == selected.Id).PriceRetail.ToString();
                addItem.txt_PriceWholesale.Text = _ProductFullInfo.FirstOrDefault(s => s.Id == selected.Id).PriceWholesale.ToString();
                addItem.cmb_Country.Text = selected.Country;
                clothesGrid.Items.Refresh();
            }
            addItem.ShowDialog();
            loaded();
        }

        private void mi_GridSettings_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsForm gridSettingsForm = new GridSettingsForm();
            gridSettingsForm.ShowDialog();
        }
    }
}
