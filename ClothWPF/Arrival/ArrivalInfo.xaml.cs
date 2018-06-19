using System;
using ClothWPF.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClothWPF.Models;

namespace ClothWPF.Arrival
{
    /// <summary>
    /// Interaction logic for ArrivalInfo.xaml
    /// </summary>
    public partial class ArrivalInfo : Window
    {
        public Entities.Supplier Supplieradding { get; set; }
        public List<SupplierModel> supplierModels;
        EfContext context = new EfContext();
        public int _idsupplier = 0;
        public int Idarrival = 0;
        public Arrivals ArrInfoAdding { get; set; }
        public ArrivalInfo()
        {
            InitializeComponent();
        }
        public void loaded()
        {
            supplierModels = new List<SupplierModel>();
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
            cmb_Supplier.ItemsSource = supplierModels;
        }
        private void cmb_SelectSupplier(object sender, SelectionChangedEventArgs e)
        {
            var selected = (SupplierModel)cmb_Supplier.SelectedItem;
            _idsupplier = supplierModels.FirstOrDefault(s => s.IdSupplier == selected.IdSupplier).IdSupplier;
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
                        arrInfo.IdSupplier = cmb_Supplier.SelectedIndex;//дописати
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
                            Comment = txt_Comment.Text
                        });
                        context.SaveChanges();
                        Idarrival = context.Arrivals.Select(c => c.IdArrival).Max();  
                    }
                    MessageBox.Show("Save");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Close();
            }
        }

        private void btn_NewSupplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier.SupplierInfo form = new Supplier.SupplierInfo();
            form.ShowDialog();
            loaded();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }
    }
}
