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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

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
            TxtPersonLogin.Text = Thread.CurrentPrincipal.Identity.Name;
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

        private void GeneralInfo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GridSecuritySettings.Visibility = Visibility.Collapsed;
            GridGeneralInfo.Visibility = Visibility.Visible;
        }

        private void SecuritySettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GridSecuritySettings.Visibility = Visibility.Visible;
            GridGeneralInfo.Visibility = Visibility.Collapsed;
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

        private void BtnEditLogin_OnClick(object sender, RoutedEventArgs e)
        {
            TxtPersonLogin.IsReadOnly = false;
            TxtPersonLogin.Focus();
            TxtPersonLogin.SelectAll();
        }

        private void TxtPersonLogin_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //Save new login here
                GridSecuritySettings.Focus();               
                TxtPersonLogin.IsReadOnly = true;
            }
        }

        private void BtnChangePassword_OnClick(object sender, RoutedEventArgs e)
        {
            PnlNewPassword.Visibility = Visibility.Visible;
            BtnChangePassword.Visibility = Visibility.Collapsed;
        }

        private void BtnSaveNewPassword_OnClick(object sender, RoutedEventArgs e)
        {
            //Save new password here
            BtnChangePassword.Visibility = Visibility.Visible;
            PnlNewPassword.Visibility = Visibility.Collapsed;
        }

        private void BtnCancelChangingPassword_OnClick(object sender, RoutedEventArgs e)
        {
            TxtCurrentPassword.Text = String.Empty;
            TxtNewPassword.Text = String.Empty;  
            TxtPasswordCheck.Text = String.Empty;
            BtnChangePassword.Visibility = Visibility.Visible;
            PnlNewPassword.Visibility = Visibility.Collapsed;
        }
    }
}
