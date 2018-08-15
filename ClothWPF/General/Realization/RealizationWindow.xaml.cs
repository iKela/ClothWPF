using System;
using System.Collections.Generic;
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
        public RealizationWindow()
        {
            InitializeComponent();
        }

        private void btn_Calculation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct(this);
            addProduct.ShowDialog();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
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
            else
            {
                MessageBox.Show("Ви не володієте правами для видалення", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
