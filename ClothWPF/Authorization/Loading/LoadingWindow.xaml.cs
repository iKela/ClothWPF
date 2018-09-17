using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClothWPF.General.Classes;
using ClothWPF.Helpes;
using ClothWPF.Models.Main;
using ThicknessConverter = Xceed.Wpf.DataGrid.Converters.ThicknessConverter;

namespace ClothWPF.Authorization.Loading
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class LoadingWindow : Window, IView
    {
       // public List<ProductModel> _ProductFullInfo { get; set; }
        public EfContext context;
        public LoadingWindow()
        {
            InitializeComponent();
        }

        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
                ? Application.Current.Windows.OfType<T>().Any()
                : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }
        public IViewModel ViewModel
        {
            get
            {
                return DataContext as IViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load cLoad = new Load();
            context = cLoad.context;
            cLoad.loaded();
            Main main = new Main();
            main.context = this.context;
            main.Show();
            if (!IsWindowOpen<Window>("Main"))
            {
                this.Hide();
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            
        }
    }

    static class ConstList
    {
        public static List<ProductModel> _FullInfo = new List<ProductModel>();
        public static ObservableCollection<ExcelItem> excelItems = new ObservableCollection<ExcelItem>();

        public static void Init(List<ProductModel> inList)
        {
            _FullInfo = inList;
        }
        public static List<ProductModel> GetList
        {
            get { return _FullInfo; }
        }
        public  static ObservableCollection<ExcelItem> GetExcelItems
        {
            get { return excelItems; }
        }
    }
}
