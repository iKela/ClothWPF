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

namespace ClothWPF.Authorization.Users
{
    /// <summary>
    /// Interaction logic for WAccount.xaml
    /// </summary>
    public partial class WAccount : Window
    {
        public WAccount()
        {
            InitializeComponent();
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

        private void GeneralSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void SecuritySettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void UsersAndRolsSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Summary_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Btn_CloseWindow_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
