using ClothWPF.Entities;
using ClothWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Data.Entity;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for NewArrival.xaml
    /// </summary>
    public partial class NewArrival : Window
    {
        EfContext context = new EfContext();
        
        public List<NewArrivalModel> _Arrivals;
        public NewArrival()
        {
            InitializeComponent();
            
        }
        public void loaded()
        {
            arrivalGrid.ItemsSource = null;
                arrivalGrid.Items.Clear();
                _Arrivals = new List<NewArrivalModel>();
            var arrival = context.Arrivals.Join(context.Products, // другий набір
        a => a.IdProduct, // свойство-селектор объекта із першого набора
        p => p.Id, // свойство-селектор объекта із другого набора
        (a, p) => new NewArrivalModel// результат
        {
            IdProduct = p.Id, Name = p.Name, Code = p.Code,
            Country = p.Country, IdArrival = a.Id, CountArrival = a.Count,
            PriceDollarArrival = a.PriceDollar, PriceUahArrival = a.PriceUah,
            PriceRetailArrival = a.PriceRetail, PriceWholesaleArrival = a.PriceWholesale,
            ManufactureDateArrival = a.ManufactureDate
        });
            //var arrivalquery = context.Products
            //    //.Include(p=>p.Arrivals)
            //    .Select(p => new ProductModel
            //    {
            //        Id = p.Id,
            //        Country = p.Country,
            //        Code = p.Code,
            //        Name = p.Name,
            //        arrivalModelslist = p.Arrivals.Select(a => new ArrivalModel
            //        {
            //            Id = a.Id,
            //            Count = a.Count,
            //            PriceDollar = a.PriceDollar,
            //            PriceRetail = a.PriceRetail,
            //            PriceUah = a.PriceUah,
            //            PriceWholesale = a.PriceWholesale,
            //            ManufactureDate = a.ManufactureDate
            //        }).ToList()
            //    });
            arrivalGrid.ItemsSource = arrival.ToList();
        }

        private void arrivalGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void btn_DeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void arrivalGrid_Loaded(object sender, RoutedEventArgs e)
        {
            loaded();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
