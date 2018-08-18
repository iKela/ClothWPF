using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClothWPF.Models;
using ClothWPF.Entities;
using System.ComponentModel;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window // , INotifyPropertyChanged
    {
        #region Пошукова система по ТекстБоксу
        //private string _searchText;

        //public string SearchText
        //{
        //    get { return _searchText; }
        //    set
        //    {
        //        _searchText = value;

        //        OnPropertyChanged("SearchText");
        //        OnPropertyChanged("MyFilteredItems");
        //    }
        //}

        //public IEnumerable<ProductModel> MyFilteredItems
        //{
        //    get
        //    {
        //        if (SearchText == null) return productModels;

        //        return context.Products.Where(x => x.ToUpper().StartsWith(SearchText.ToUpper()));
        //    }
        //}


        //public AddProduct()
        //{
        //    InitializeComponent();

        //    productModels = new List<ProductModel>();
        //    var p = context.Products.Select(ap => new ProductModel     // ар =>-- придумана лямбда
        //    {
        //        Id = ap.IdProduct,
        //        Code = ap.Code,
        //        Name = ap.Name,
        //        Article = ap.Article,
        //        Count = ap.Count,
        //        PriceDollar = ap.PriceDollar,
        //        PriceRetail = ap.PriceRetail,
        //        PriceUah = ap.PriceUah,
        //        PriceWholesale = ap.PriceWholesale
        //    }).ToList();

        //    this.DataContext = this;
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //void OnPropertyChanged(string name)
        //{
        //    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        //}
        #endregion

        #region
        public bool _close { get; set; }
        public Product Productadding { get; set; }
        public List<ProductModel> productModels;
        EfContext context = new EfContext();
        public int _idproduct { get; set; }
        public string _name { get; set; }
        public string _code { get; set; }
        public double _count { get; set; }
        public double? _priceRetail { get; set; }
        public double? _priceWholesale { get; set; }
        public double _priceDollar { get; set; }
        public DateTime? _manufactureDate { get; set; }
        public string _article { get; set; }
        public int? _sampleChoice { get; set; } // якщо ноль то не буде грузити
        #endregion
        private string _window { get; set; }
        public AddProduct()
        {
            InitializeComponent();
        }
         public void loaded()
        {
            productModels = new List<ProductModel>();
            var p = context.Products.Select(ap => new ProductModel     // ар =>-- придумана лямбда
            {
                Id = ap.IdProduct,
                Code = ap.Code,
                Name = ap.Name,
                Article = ap.Article,
                Count = ap.Count,
                PriceDollar = ap.PriceDollar,
                PriceRetail = ap.PriceRetail,
                PriceUah = ap.PriceUah,
                PriceWholesale = ap.PriceWholesale
            }).ToList();
            productModels = p;   
            cmb_Name.ItemsSource = null; cmb_Name.SelectedItem = null; cmb_Name.ItemsSource = p;  cmb_Name.Items.Refresh();
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {          
            #region Double Parse
            double count = 0;
            double wholesalePrice = 0;
            double retailerPrice = 0;
            double priceDollar = 0;
            Double.TryParse(txt_Count.Text, out count);
            Double.TryParse(txt_PriceWholeSale.Text, out wholesalePrice);
            Double.TryParse(txt_PriceRetailer.Text, out retailerPrice);
            Double.TryParse(txt_SuppierPrice.Text, out priceDollar);
            #endregion
            try
            {
                _name = cmb_Name.Text; _code = txt_ProductCode.Text; _count = count;
                _article = txt_Article.Text; _priceRetail = retailerPrice; _priceWholesale = wholesalePrice;
                _priceDollar = priceDollar; _manufactureDate = Convert.ToDateTime(txt_ManufactureDate.Text);
                _close = true; Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void SingleSample()
        {
            var selected = (ProductModel)cmb_Name.SelectedItem;
            Product Productadding = new Product { IdProduct = selected.Id };
            _idproduct = productModels.FirstOrDefault(s => s.Id == selected.Id).Id;
            txt_ProductCode.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).Code;
            txt_Article.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).Article;
            txt_SuppierPrice.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).PriceDollar.ToString();
            txt_PriceRetailer.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).PriceRetail.ToString();
            txt_PriceWholeSale.Text = productModels.FirstOrDefault(s => s.Id == selected.Id).PriceWholesale.ToString();
        }
        private void TripleSample()
        {
            var selected = (ProductModel)cmb_Name.SelectedItem;
            Product Productadding = new Product { IdProduct = selected.Id };
            _idproduct = productModels.Find(s => s.Id == selected.Id).Id;
            txt_ProductCode.Text = productModels.Find(s => s.Id == selected.Id).Code;
            txt_Article.Text = productModels.Find(s => s.Id == selected.Id).Article;
            txt_SuppierPrice.Text = productModels.Find(s => s.Id == selected.Id).PriceDollar.ToString();
            txt_PriceRetailer.Text = context.ArrivalProducts.Where(p => p.Idproduct == selected.Id).OrderByDescending(a=>a.IdArrivalProduct).Take(3).Select(a=>a.PriceRetail).Average().ToString();
            txt_PriceWholeSale.Text = context.ArrivalProducts.Where(p => p.Idproduct == selected.Id).OrderByDescending(a => a.IdArrivalProduct).Take(3).Select(a => a.PriceWholesale).Average().ToString();
            //сууукааааа наканецто 5.30 15.08.2018 
        }
        private void cmb_Name_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _sampleChoice = 2;//видалити при доробленні настройки
            switch (_sampleChoice)
            {
                case null :
                    {
                        MessageBox.Show("Не вибрано налаштування виведення цін!", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                    }
                case 1 :
                    {
                        SingleSample();
                        break;
                    }
                case 2 :
                    {
                        TripleSample();
                        break;
                    }    
            }
        }
        
       private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           loaded();
        }

        private void btn_NewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddItem newProduct = new AddItem();
            newProduct._additemClose = false;
            newProduct.ShowDialog();
            //if (newProduct._additemClose == true) loaded();
        }
    }
}
