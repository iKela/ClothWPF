using ClothWPF.Entities;
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

namespace ClothWPF.MainFolder
{
    /// <summary>
    /// Interaction logic for ProductSubtraction.xaml
    /// </summary>
    public partial class ProductSubtraction : Window
    {
        public double? _nowcount { get; set; }
        public Product subtraction { get; set; }
        public ProductSubtraction()
        {
            InitializeComponent();
            txt_Count.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double count = 0;            
            Double.TryParse(txt_Count.Text, out count);
            if (_nowcount >= count)
            {
                using (EfContext context = new EfContext())
                {
                    try
                    {
                        var product = context.Products.Where(c => c.IdProduct == subtraction.IdProduct).FirstOrDefault();
                        product.Count = product.Count - count;

                        context.SaveChanges();
                        MessageBox.Show("Зберeженно!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }else
                MessageBox.Show("Від`ємне число більше, ніж кількість товару на складі!","Віднімання неможливе!", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void txt_Count_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if (e.Key != Key.Back)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
