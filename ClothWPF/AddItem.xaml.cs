using ClothWPF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ClothWPF.Authorization.Loading;
using ClothWPF.Items.Group;
using ClothWPF.Models.ArrivalInfo;
using ClothWPF.Models.Main;
using ClothWPF.Models.Group;

namespace ClothWPF
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
     
      
        public Product Productadding { get; set; }
        public bool _additemClose { get; set; }
        public List<GroupModel> groupModel;
        bool field = false;
        public int _idgroup=0;
        public AddItem()
        {
            InitializeComponent();
            txt_DolCurrency.Text = Properties.Settings.Default.CurrencyExchangeDol.ToString();
            groupModel = null;
            groupModel = new List<GroupModel>();
            using (EfContext ect = new EfContext())
            {
                
            foreach (var e in ect.GroupProducts)
            {
                groupModel.Add(new GroupModel
                {
                    IdGroup = e.IdGroup,
                    NameGroup = e.NameGroup
                });
            }
            }

            AutoGroup.ItemsSource = groupModel;
        }
        
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_Name.Text))
            {
                #region Double Parse
                double wholesalePrice = 0;
                double retailerPrice = 0;
                double priceDollar = 0;
                double priceUah = 0;
                Double.TryParse(txt_PriceWholesale.Text, out wholesalePrice);
                Double.TryParse(txt_PriceRetail.Text, out retailerPrice);
                Double.TryParse(txt_PriceDollar.Text, out priceDollar);
                Double.TryParse(txt_PriceUah.Text, out priceUah);
                #endregion
                using (EfContext context = new EfContext())
                {
                    try
                    {
                        if (_idgroup ==0)
                        {
                            _idgroup = 1;
                        }
                        if (Productadding != null)
                        {
                            var product = context.Products.Where(c => c.IdProduct == Productadding.IdProduct).FirstOrDefault();
                            product.Name = txt_Name.Text;
                            product.Article = txt_Article.Text;
                            product.Code = txt_ProductCode.Text;
                            product.PriceDollar = priceDollar;
                            product.PriceUah = priceUah;
                            product.PriceRetail = retailerPrice;
                            product.PriceWholesale = wholesalePrice;
                            product.Country = cmb_Country.Text;
                            Productadding = product;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Products.Add(new Product
                            {
                                Name = txt_Name.Text,
                                Article = txt_Article.Text,
                                Code = txt_ProductCode.Text,
                                PriceDollar = priceDollar,
                                PriceUah = priceUah,
                                PriceRetail = retailerPrice,
                                PriceWholesale = wholesalePrice,
                                Country = cmb_Country.Text,                              
                                Idgroup = _idgroup
                            });
                            context.SaveChanges();
                            ConstList._FullInfo.Add(new ProductModel
                            {
                                Name = txt_Name.Text,
                                Article = txt_Article.Text,
                                Code = txt_ProductCode.Text,
                                PriceDollar = priceDollar,
                                PriceUah = priceUah,
                                PriceRetail = retailerPrice,
                                PriceWholesale = wholesalePrice,
                                Country = cmb_Country.Text                                
                            });
                        }
                        MessageBox.Show("Зберeженно!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                        _additemClose = true;
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Обов`язкові поля мають бути заповненні!", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        private void txt_PriceDollar_TextChanged(object sender, TextChangedEventArgs e)
        {
            double num;

            double.TryParse(txt_PriceDollar.Text.ToString(), out num);
            num = num * Properties.Settings.Default.CurrencyExchangeDol;
            txt_PriceUah.Text = num.ToString();
            field = false;
        }

        private void txt_DolCurrency_Click(object sender, RoutedEventArgs e)
        {
            txt_DolCurrency.IsReadOnly = false;
        }

        private void txt_DolCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(MessageBox.Show("Бажаєте змінити курс долара з " + Properties.Settings.Default.CurrencyExchangeDol.ToString() + " на " + txt_DolCurrency.Text + "?", "Увага!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    double dol;
                    double.TryParse(txt_DolCurrency.Text, out dol);
                    Properties.Settings.Default.CurrencyExchangeDol = dol;
                    Properties.Settings.Default.Save();
                    txt_DolCurrency.IsReadOnly = true;
                }
            }
        }

        private void txt_DolCurrency_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == ","))
            {
                e.Handled = true;
            }
        }

        private void CheckBox_Discount_OnChecked(object sender, RoutedEventArgs e)
        {
            txt_Discount.Visibility = Visibility.Visible;
        }

        private void CheckBox_Discount_OnUnchecked(object sender, RoutedEventArgs e)
        {
            txt_Discount.Visibility = Visibility.Collapsed;
        }

        private void AutoGroup_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = (GroupModel)AutoGroup.SelectedItem;
            _idgroup = groupModel.FirstOrDefault(s => s.IdGroup== selected.IdGroup).IdGroup;
        }

        private void btn_NewGroup_Click(object sender, RoutedEventArgs e)
        {
            WNewGroup newGroup = new WNewGroup();
            newGroup.ShowDialog();
        }
    }
}
