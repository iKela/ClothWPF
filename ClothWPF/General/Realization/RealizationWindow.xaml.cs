using ClothWPF.Models.Main;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClothWPF.General.Realization
{
    /// <summary>
    /// Interaction logic for RealizationWindow.xaml
    /// </summary>
    public partial class RealizationWindow : Window
    {
        EfContext context = new EfContext();
        public RealizationWindow()
        {
            InitializeComponent();
        }


        private void CountPrice()
        {
            DataRowView dataRow;
            //int index = realizationGrid.Columns[5].;
            

            for (int i = 0; i < realizationGrid.Items.Count;i++)
            {
                dataRow = (DataRowView)realizationGrid.Items[i];
                string cellValue = dataRow.Row.ItemArray[5].ToString();
                MessageBox.Show(cellValue);
            }
        }
        private void btn_Calculation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Enterprise.ProductList addProduct = new Enterprise.ProductList();
            addProduct.ShowDialog();
            realizationGrid.Items.Add( addProduct.item);

        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e) {
            if (Thread.CurrentPrincipal.IsInRole("Administrators"))
            {
                //Product obj = ((FrameworkElement)sender).DataContext as Product;
                if (realizationGrid.SelectedItem != null)
                {
                    try
                    {
                        using (EfContext context = new EfContext())
                        {
                            //context.Products.Remove(context.Products.Find(obj.IdProduct));
                            //context.SaveChanges();
                        }
                        //loaded();
                        MessageBox.Show("Видалено!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else{
                MessageBox.Show("Ви не володієте правами для видалення", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        void Add()
        {
            //foreach (var product in )   //переробити
            //{
            //    context.RealizationProducts.Add(new Entities.RealizationProduct
            //    {
            //        Count = product.CountArrival,
            //        PriceDollar = product.PriceDollarArrival,
            //        PriceUah = product.PriceUahArrival,
            //        PriceRetail = product.PriceRetailArrival,
            //        PriceWholesale = product.PriceWholesaleArrival,
        
            //        Idproduct = product.IdProduct
            //    });
            //    var std = context.Products.Where(c => c.IdProduct == product.IdProduct).FirstOrDefault();
            //    std.PriceDollar = product.PriceDollarArrival;
            //    std.PriceRetail = product.PriceRetailArrival;
            //    std.PriceWholesale = product.PriceWholesaleArrival;
            //    double? sum = std.Count == null ? product.CountArrival : std.Count + product.CountArrival;
            //    std.Count = sum;
            //}
            //context.SaveChanges();
        }
    }
}
