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

namespace ClothWPF.Arrival
{
    /// <summary>
    /// Interaction logic for ArrivalsList.xaml
    /// </summary>
    public partial class ArrivalsList : Window
    {
        List<Arrivals> FullArrival;
        List<ArrivalProduct> arrivalProducts;
        DateTime dateArrival;
        public ArrivalsList()
        {
           InitializeComponent();
           txt_DateFrom.Text = DateTime.Today.ToShortDateString();
            dateArrival = Convert.ToDateTime(txt_DateFrom.Text);
           txt_DateTo.Text = DateTime.Today.ToShortDateString();
        }
        private void grid_Arrivals_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }

        private void grid_Arrivals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid_ArrivalInfo.ItemsSource = null;
            grid_ArrivalInfo.Items.Clear();
            arrivalProducts = new List<ArrivalProduct>();
            using (EfContext context = new EfContext())
            {
                var arrId = context.ArrivalProducts.Where(ap => ap.Idarrival == 13);
                foreach (ArrivalProduct ap in arrId)
                {
                    arrivalProducts.Add(new ArrivalProduct
                    {
                        IdArrivalProduct = ap.IdArrivalProduct,
                        Count = ap.Count,
                        PriceDollar = ap.PriceDollar,
                        PriceUah = ap.PriceUah,
                        PriceRetail = ap.PriceRetail,
                        PriceWholesale = ap.PriceWholesale,
                        ManufactureDate = ap.ManufactureDate,
                        Idarrival = ap.Idarrival,
                        Idproduct = ap.Idproduct
                    });
                }
                grid_ArrivalInfo.ItemsSource = arrivalProducts;
            }
        }

        public void loaded()
        {
            grid_Arrivals.ItemsSource = null;
            grid_Arrivals.Items.Clear();
            FullArrival = new List<Arrivals>();
            using (EfContext context = new EfContext())
            {
                var arrival = context.Arrivals.Where(a => a.Date == dateArrival);
                foreach (Arrivals a in arrival )
                {
                    FullArrival.Add(new Arrivals
                    {
                        IdArrival = a.IdArrival,
                        Number = a.Number,
                        ComesTo = a.ComesTo,
                        Date = a.Date,
                        //SupplierInvoice = a.SupplierInvoice,
                        PaymentType = a.PaymentType,
                        Currency = a.Currency,
                        TotalPurchase = a.TotalPurchase,
                        Comment = a.Comment,
                        //IdSupplier= a.IdSupplier,
                        //SupplierOf=a.SupplierOf,
                        //EnterpriseId=a.EnterpriseId,
                       // EnterpriseOf=a.EnterpriseOf
                    });
                }
                grid_Arrivals.ItemsSource = FullArrival;
            }
        }
        private void grid_ArrivalInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            GridSettingsForm gridSettingsForm = new GridSettingsForm(TabIndex); ;
            gridSettingsForm.Show();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmb_Supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_Enterprise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
