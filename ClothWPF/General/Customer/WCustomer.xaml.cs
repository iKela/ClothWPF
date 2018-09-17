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

namespace ClothWPF.General.Customer
{
    /// <summary>
    /// Interaction logic for WCustomer.xaml
    /// </summary>
    public partial class WCustomer : Window
    {
        public WCustomer()
        {
            InitializeComponent();
        }

        private void Btn_CloseWindow_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                {
                    GridGeneralInfo.Visibility = Visibility.Visible;
                    GridAdditionInfo.Visibility = Visibility.Collapsed;
                    break;
                }
                case 1:
                {
                    GridGeneralInfo.Visibility = Visibility.Collapsed;
                    GridAdditionInfo.Visibility = Visibility.Visible;
                    break;
                }
                default:
                {
                    GridGeneralInfo.Visibility = Visibility.Visible;
                    GridAdditionInfo.Visibility = Visibility.Collapsed;
                    break;
                }
            }
        }

        private void Btn_Add_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
