using System;
using ClothWPF.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        public List<SupplierModel> supplierModels;
        public List<EnterpriseModel> enterpriseModels;
        EfContext context = new EfContext();
        public int _idsupplier = 0;
        public int _identerprise = 0;
        public int Idarrival = 0;
        public double totalPurchaise { get; set; }
        public Arrivals ArrInfoAdding { get; set; }
        public ArrivalInfo()
        {
            InitializeComponent();
        }
        public void loaded()
        {
            supplierModels = null;
            supplierModels = new List<SupplierModel>();
            enterpriseModels = new List<EnterpriseModel>();

            foreach (var e in context.Enterprises)
            {
                enterpriseModels.Add(new EnterpriseModel
                {
                    IdEnterprise = e.IdEnterprise,
                    Name = e.Name
                });
            }
            foreach (var p in context.Suppliers)
            {
                supplierModels.Add(new SupplierModel
                {
                    IdSupplier   =p.IdSupplier,
                    NameSupplier =p.NameSupplier                                       
                });
            }
            var var = DateTime.Today.ToShortDateString() ;
            txt_Date.Text = Convert.ToString(var);
            
            cmb_Supplier.ItemsSource = null;
            cmb_Supplier.ItemsSource = supplierModels;
            cmb_Supplier.Items.Refresh();
            cmb_Enterprise.ItemsSource = enterpriseModels;
            cmb_Enterprise.Items.Refresh();
        }
        private void cmb_SelectSupplier(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (SupplierModel)cmb_Supplier.SelectedItem;
                _idsupplier = supplierModels.FirstOrDefault(s => s.IdSupplier == selected.IdSupplier).IdSupplier;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            using (EfContext context = new EfContext())
            {
                try
                {
                    if (ArrInfoAdding != null)
                    {
                        var arrInfo = context.Arrivals.Where(c => c.IdArrival == ArrInfoAdding.IdArrival).FirstOrDefault();
                        //var product = context.Products.Find(Productadding.Id);
                        arrInfo.Date = Convert.ToDateTime(txt_Date.Text);
                        arrInfo.Number = txt_Number.Text;
                        arrInfo.ComesTo = txt_ComesTo.Text;
                        //arrInfo.IdSupplier = cmb_Supplier.SelectedIndex;//дописати
                        //arrInfo.EnterpriseId = cmb_Enterprise.SelectedIndex;
                        arrInfo.SupplierInvoice = txt_SupplierInvoice.Text;
                        arrInfo.PaymentType = cmb_PaymentType.Text;
                        arrInfo.Currency = cmb_Currency.Text;
                        arrInfo.Comment = txt_Comment.Text;
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Arrivals.Add(new Arrivals
                        {
                            Date = Convert.ToDateTime(txt_Date.Text),
                            Number = txt_Number.Text,
                            ComesTo = txt_ComesTo.Text,
                            IdSupplier = _idsupplier,
                            //EnterpriseId = cmb_Enterprise.SelectedIndex;
                            SupplierInvoice = txt_SupplierInvoice.Text,
                            PaymentType = cmb_PaymentType.Text,
                            Currency = cmb_Currency.Text,
                            Comment = txt_Comment.Text,
                            TotalPurchase = totalPurchaise                            
                        });
                        context.SaveChanges();
                        Idarrival = context.Arrivals.Select(c => c.IdArrival).Max();
                        _formclosing = true;
                    }
                    MessageBox.Show("Зберeженно!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
            enterprise.ShowDialog();
        }

        private void Cmb_Enterprise_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (EnterpriseModel)cmb_Enterprise.SelectedItem;
                _identerprise = enterpriseModels.FirstOrDefault(s => s.IdEnterprise == selected.IdEnterprise).IdEnterprise;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Помилка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
