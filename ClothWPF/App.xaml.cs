using ClothWPF.Authorization;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            //Create a custom principal with an anonymous identity at startup
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("uk-Ua");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-Ua");
            //Show the login view
            AuthenticationViewModel viewModel = new AuthenticationViewModel(new AuthenticationService());
            IView loginWindow = new Login(viewModel);
            loginWindow.Show();

        }
    }   
}