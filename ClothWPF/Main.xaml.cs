using ClothWPF.Authorization;
using ClothWPF.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using ClothWPF.Models.Main;
using ClothWPF.Helpes;
using ClothWPF.General.Classes;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    ///
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class Main : Window, IView
    {
        private List<ProductModel> _ProductFullInfo;
        private EfContext context;
        General.Classes.DataAccess objDs;
        public Main()
        {
            LoadedProvaider conn = new LoadedProvaider();
            _ProductFullInfo = conn._ProductFullInfo;
            //ConnectionProvider _connectionProvider = new ConnectionProvider();
            //_connectionProvider.Conected += _connectionProvider_Conected;
            //_connectionProvider.ConnectRun();
            InitializeComponent();
           
            context = conn.context;
            //context = new EfContext();
        }
        private void _connectionProvider_Conected(EfContext eFContext)
        {
            //context = eFContext;

            Dispatcher.BeginInvoke(new Action(() => 
            {
                Lbl_load.Content = "Підключення виконано успішно";
               
            }));
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
            try
            {
                //LoadExcelInfo();
               loaded();
            }
            catch
            {
                MessageBox.Show("Немає з'єднання з базою даних.", "Увага!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void loaded()
        {
           
            Dispatcher.BeginInvoke(new Action(() =>
            {
                clothesGrid.ItemsSource = null;
                clothesGrid.Items.Clear();
            }));
            // _ProductFullInfo = new List<Product>();
            
            Dispatcher.BeginInvoke(new Action(() =>
            {
                clothesGrid.ItemsSource =_ProductFullInfo;
            }));
    }
        private void LoadExcelInfo()
        {
            objDs = new General.Classes.DataAccess(this.context);
            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    excelInfoGrid.ItemsSource = null;
                    excelInfoGrid.ItemsSource = objDs.GetDataFormExcelAsync().Result;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void mi_NewArrival_Click(object sender, RoutedEventArgs e)
        {
            NewArrival newArrival = new NewArrival(this.context);
            newArrival.ShowDialog();
            loaded();
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentPrincipal.IsInRole("Administrators"))
            {
                var obj = ((FrameworkElement)sender).DataContext as ProductModel;
                if (clothesGrid.SelectedItem != null)
                {
                    try
                    {
                        using (var context = new EfContext())
                        {
                            context.Products.Remove(context.Products.Find(obj.IdProduct));
                            context.SaveChanges();
                        }
                        loaded();
                        MessageBox.Show("Видалено!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ви не володієте правами для видалення", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            GridSettingsForm gridSettingsForm = new GridSettingsForm(TabIndex); ;
            gridSettingsForm.Show();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            try
            {
                if (clothesGrid.SelectedItem != null)
                {
                    var selected = (ProductModel)clothesGrid.SelectedItem;
                    addItem.Title = "Редагувати";
                    addItem.btn_Add.Content = "Зберегти";
                    addItem.Productadding = new Product { IdProduct = selected.IdProduct };
                    addItem.txt_Name.Text = _ProductFullInfo.FirstOrDefault(s => s.IdProduct == selected.IdProduct).Name;
                    addItem.txt_ProductCode.Text = _ProductFullInfo.FirstOrDefault(s => s.IdProduct == selected.IdProduct).Code;
                    addItem.txt_PriceDollar.Text = _ProductFullInfo.FirstOrDefault(s => s.IdProduct == selected.IdProduct).PriceDollar.ToString();
                    addItem.txt_PriceUah.Text = _ProductFullInfo.FirstOrDefault(s => s.IdProduct == selected.IdProduct).PriceUah.ToString();
                    addItem.txt_PriceRetail.Text = _ProductFullInfo.FirstOrDefault(s => s.IdProduct == selected.IdProduct).PriceRetail.ToString();
                    addItem.txt_PriceWholesale.Text = _ProductFullInfo.FirstOrDefault(s => s.IdProduct == selected.IdProduct).PriceWholesale.ToString();
                    addItem.cmb_Country.Text = selected.Country;
                    clothesGrid.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            addItem.ShowDialog();
            loaded();
        }

        private void mi_GridSettings_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsForm gridSettingsForm = new GridSettingsForm();
            gridSettingsForm.ShowDialog();
        }

        private void txt_Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (tb_SearchByName.Visibility == Visibility.Visible)
            {
                var filtered = _ProductFullInfo.Where(product => product.Name.StartsWith(txt_Search.Text));
                clothesGrid.ItemsSource = filtered;
            }
            if (tb_SearchByProductCode.Visibility == Visibility.Visible)
            {
                var filtered = _ProductFullInfo.Where(product => product.Code.StartsWith(txt_Search.Text));
                clothesGrid.ItemsSource = filtered;
            }
            if (tb_SearchByCountry.Visibility == Visibility.Visible)
            {
                var filtered = _ProductFullInfo.Where(product => product.Country.StartsWith(txt_Search.Text));
                clothesGrid.ItemsSource = filtered;
            }
        }

        private void btn_SearchByName_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Visible;
            tb_SearchByProductCode.Visibility = Visibility.Hidden;
            tb_SearchByCountry.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByProductCode_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByProductCode.Visibility = Visibility.Visible;
            tb_SearchByCountry.Visibility = Visibility.Hidden;
        }

        private void btn_SearchByCountry_Click(object sender, RoutedEventArgs e)
        {
            tb_SearchByName.Visibility = Visibility.Hidden;
            tb_SearchByProductCode.Visibility = Visibility.Hidden;
            tb_SearchByCountry.Visibility = Visibility.Visible;
        }

        private void mi_ArrivalsList_Click(object sender, RoutedEventArgs e)
        {
            Arrival.ArrivalsList arrivalsList = new Arrival.ArrivalsList();
            arrivalsList.Show();
        }

        private void btn_Subtraction_Click(object sender, RoutedEventArgs e)
        {
            MainFolder.ProductSubtraction productSubtraction = new MainFolder.ProductSubtraction();
            try
            {
                if (clothesGrid.SelectedItem != null)
                {
                    var selected = (ProductModel)clothesGrid.SelectedItem;
                    productSubtraction.Title = "Відняти";
                    productSubtraction.subtraction = new Product { IdProduct = selected.IdProduct };
                    productSubtraction._nowcount = _ProductFullInfo.FirstOrDefault(s => s.IdProduct == selected.IdProduct).Count;
                    clothesGrid.Items.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            productSubtraction.ShowDialog();
            loaded();
        }

        private void mi_OpenTeamViewer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TeamViewer 13");
                Process.Start(filepath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void mi_AddRealization_Click(object sender, RoutedEventArgs e)
        {
            General.Realization.RealizationWindow realization = new General.Realization.RealizationWindow();
            realization.Show();
        }
    }
}

