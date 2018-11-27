using System;
using ClothWPF.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClothWPF.Authorization.Loading;
using ClothWPF.Models;
using ClothWPF.Models.ArrivalInfo;

namespace ClothWPF.Arrival
{
    /// <summary>
    /// Interaction logic for ArrivalInfo.xaml
    /// </summary>
    public partial class ArrivalInfo : Window
    {
       public bool _formclosing { get; set; }
        public Entities.Supplier Supplieradding { get; set; }

        EfContext context = new EfContext();
        public int _idsupplier = 0;
        public int _identerprise = 0;
        public int Idarrival = 0;
        public double totalPurchaise { get; set; }
        public Arrivals ArrInfoAdding { get; set; }
        public ArrivalInfo()
        {
            InitializeComponent();
              int i  = context.Arrivals.Count()+1;
            txt_Number.Text = i.ToString();
            loaded();
        }
        public void loaded()
        {
            var var = DateTime.Today.ToShortDateString() ;
            txt_Date.Text = Convert.ToString(var);
            AutoNameConterparty.ItemsSource = null;
            AutoNameConterparty.ItemsSource = ConstList.GetSupplierList;
            AutoNameEnterprise.ItemsSource = null;
            AutoNameEnterprise.ItemsSource = ConstList.GetEnterpriseList;
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            var selected = (EnterpriseModel)AutoNameEnterprise.SelectedItem;
            int identerprise = selected.IdEnterprise;
                context.Arrivals.Add(new Arrivals
                {
                    Date = Convert.ToDateTime(txt_Date.Text),
                    Number = txt_Number.Text,
                    ComesTo = txt_ComesTo.Text,
                    IdSupplier = _idsupplier,
                    EnterpriseId = identerprise,
                    SupplierInvoice = txt_SupplierInvoice.Text,
                    PaymentType = cmb_PaymentType.Text,
                    Comment = txt_Comment.Text,
                    TotalPurchase = totalPurchaise
                });
                context.SaveChanges();
                Idarrival = context.Arrivals.Select(c => c.IdArrival).Max();
                _formclosing = true;
                MessageBox.Show("Зберeженно!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_NewSupplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier.SupplierInfo form = new Supplier.SupplierInfo();
            form._supplierClose = false;
            form.ShowDialog();
            if (form._supplierClose == true) { loaded(); }
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }

        private void btn_NewEnterprise_Click(object sender, RoutedEventArgs e)
        {
            Enterprise.EnterpriseWindow enterprise = new Enterprise.EnterpriseWindow();
            enterprise._enterpriseClose = false;
            enterprise.ShowDialog();
           if(enterprise._enterpriseClose == true) { loaded();}
        }
        private void AutoNameConterparty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (SupplierModel)AutoNameConterparty.SelectedItem;                
                    _idsupplier = ConstList._Supplier.FirstOrDefault
                            (s => s.IdSupplier == selected.IdSupplier)
                        .IdSupplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AutoNameEnterprise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (EnterpriseModel)AutoNameEnterprise.SelectedItem;         
                    _identerprise = ConstList._Enterprise.FirstOrDefault
                            (s => s.IdEnterprise == selected.IdEnterprise)
                        .IdEnterprise;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
