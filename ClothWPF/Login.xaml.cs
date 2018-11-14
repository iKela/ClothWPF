using ClothWPF.Authorization;
using System.Windows;
using System.Windows.Input;

namespace ClothWPF
{
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }

        void Show();
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window, IView
    {
        public Login(AuthenticationViewModel viewModel)
        {
            //EfContext efContext = new EfContext();
            //efContext.
            ViewModel = viewModel;
            InitializeComponent();
            //TxtEmail.Focus();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Application.Current.Shutdown();
        }
        #region IView Members
        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }
        
        #endregion    
    }
}
