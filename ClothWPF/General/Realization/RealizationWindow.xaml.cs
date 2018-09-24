using ClothWPF.Models.Main;
using ClothWPF.Models.RealizationWindow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClothWPF.Arrival.Supplier;
using ClothWPF.Entities;

namespace ClothWPF.General.Realization
{
    /// <summary>
    /// Interaction logic for RealizationWindow.xaml
    /// </summary>
    public partial class RealizationWindow : Window
    {
        
        public List<RealizationProductModel> _ListProduct;
        private string value { get; set; }
        private int idClient { get; set; }
        private int rowIndex { get; set; }
        private double sum { get; set; }
        private double profit { get; set; }
        public  List<int> IdList { get; set; }
        private List<Supplier> supplier;
        private int getid;
        private EfContext context;
        public RealizationWindow()
        {
            InitializeComponent();
            _ListProduct = new List<RealizationProductModel>();
            supplier = new List<Supplier>();
            context = new EfContext();
            foreach (var c in context.Suppliers)
            {
                supplier.Add(new Supplier
                {
                    IdSupplier = c.IdSupplier,
                    NameSupplier = c.NameSupplier,
                    Discount = c.Discount
                });
            }
            int i = context.Realizations.Count() + 1;
            txt_Number.Text = i.ToString();
          AutoName.ItemsSource = supplier;
            IdList= new List<int>();
            IdList.Add(0);
            realizationGrid.CellEditEnding += realizationGrid_CellEditEnding;
            TxtRealizationDate.Text = DateTime.Today.Date.ToShortDateString().Replace(".", null);
            AutoName.ItemsSource = null; AutoName.SelectedItem = null; AutoName.ItemsSource = supplier; //AutoName.Items.Refresh();
        }

        #region Витяг та призначення значення після його зміни в комірці

        private void realizationGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            SaveGridChanges(sender, e);           
        }

        private void SaveGridChanges(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var bindingPath = (column.Binding as Binding)?.Path.Path;
                    if (bindingPath == "PriceWholesale")
                    {
                        rowIndex = e.Row.GetIndex();

                        if (e.EditingElement is TextBox el && Math.Abs(Convert.ToDouble(GetSingleCellValue(rowIndex, 2))) > 0)
                        {
                            value = el.Text;
                            // rowIndex has the row index
                            // bindingPath has the column's binding
                            // el.Text has the new, user-entered value
                            
                            try
                            {
                                sum = (Convert.ToDouble(el.Text.Replace(".", ",")) * Convert.ToDouble(
                                                           (Convert.ToDouble(GetSingleCellValue(rowIndex, 2).Replace(".", ",")) > 0)
                                                           ? Convert.ToDouble(GetSingleCellValue(rowIndex, 2).Replace(".", ","))
                                                           : 1)) - ((Convert.ToDouble(el.Text.Replace(".", ",")) * Convert.ToDouble(
                                                           (Convert.ToDouble(GetSingleCellValue(rowIndex, 2).Replace(".", ",")) > 0)
                                                            ? Convert.ToDouble(GetSingleCellValue(rowIndex, 2).Replace(".", ","))
                                                            : 1)) * (Convert.ToDouble(GetSingleCellValue(rowIndex, 7).Replace(".", ","))) / 100);
                                GetCell(realizationGrid, rowIndex, 8).Content = sum;
                                _ListProduct.Find(a => a.Idproduct == getid).Sum = sum;

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                throw;
                            }
                            GetColumnValue();
                            CountValues();
                           
                        }

                       

                       
                    }
                    else if (bindingPath == "CountSale")
                    {
                        rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;

                        value = el.Text;
                        // rowIndex has the row index
                        // bindingPath has the column's binding
                        // el.Text has the new, user-entered value
                        if ((Convert.ToDouble(el.Text.Replace(".", ",")) <= Convert.ToDouble(GetSingleCellValue(rowIndex, 3).Replace(".", ","))))
                        { 
                            sum = (Convert.ToDouble(el.Text.Replace(".", ",")) * Convert.ToDouble(GetSingleCellValue(rowIndex, 5).Replace(".",","))) - (Convert.ToDouble(el.Text.Replace(".",",")) * Convert.ToDouble(GetSingleCellValue(rowIndex, 5).Replace(".",",")) * Convert.ToDouble(GetSingleCellValue(rowIndex, 7).Replace(".",",")) / 100);
                            GetCell(realizationGrid, rowIndex, 8).Content = sum;
                            _ListProduct.Find(a => a.Idproduct == getid).Sum = sum;

                            GetColumnValue();
                            CountValues();
                        }
                        else
                        {
                            MessageBox.Show("Вписана кількість перевищує наявну кількість !", "Увага!",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                            realizationGrid.CancelEdit();
                        }
                    }
                    else if (bindingPath == "Discount")
                    {
                        rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;

                        value = el.Text;

                            sum = (Convert.ToDouble(GetSingleCellValue(rowIndex, 2).Replace(".",",")) * Convert.ToDouble(GetSingleCellValue(rowIndex, 5).Replace(".",","))) -(Convert.ToDouble(GetSingleCellValue(rowIndex, 2).Replace(".",",")) * Convert.ToDouble(GetSingleCellValue(rowIndex, 5).Replace(".",",")) * Convert.ToDouble(el.Text.Replace(".",",")) / 100);
                            GetCell(realizationGrid, rowIndex, 8).Content = sum;
                            _ListProduct.Find(a => a.Idproduct == getid).Sum = sum;

                        GetColumnValue();
                        CountValues();
                    }
                }
            }
        }

        DataGridCell GetCell(DataGrid realizationGrid, int rowIndex, int columnIndex)
        {
            try
            {
                var dr = realizationGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
                var dc = realizationGrid.Columns[columnIndex].GetCellContent(dr);
                return dc.Parent as DataGridCell;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        #endregion

        #region Отримати значення колонкі з усіх рядків

        private string GetSingleCellValue(int roww, int column)
        {
            var dataGrid = realizationGrid as DataGrid;
            if (realizationGrid.Items.Count != 0)
            {
                var row = (DataGridRow) dataGrid.ItemContainerGenerator.ContainerFromItem(realizationGrid.Items[roww]);
                if (row != null)
                {
                    var presenter = GetVisualChild<DataGridCellsPresenter>(row);

                    if (presenter.ItemContainerGenerator.ContainerFromIndex(column) is DataGridCell cell)
                    {
                        return ((TextBlock) cell.Content).Text;
                    }
                }


            }

            return null;
        }

        private void GetColumnValue()
        { 
             txt_FullPrice.Text = _ListProduct.Sum(a=>a.Sum).ToString();
        }

        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual) VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null) child = GetVisualChild<T>(v);
                if (child != null) break;
            }

            return child;
        }

        #endregion

        private void CalculateProfit()
        {
            //foreach (DataGridRow row in realizationGrid.Items)
            //{
            //    Convert.ToDouble(GetSingleCellValue(rowIndex, 5).Replace(".", ","))) - 
            //}
        }
        private void btn_Calculation_Click(object sender, RoutedEventArgs e)
        {
            double fullprice = 0;
            double discount = 0;
            double prepayment = 0;
            Double.TryParse(txt_FullPrice.Text, out fullprice);
            Double.TryParse(txt_Discount.Text, out discount);
            Double.TryParse(txt_Prepayment.Text, out prepayment);
            double totalsum = 0;
            Double.TryParse(txt_TotalSum.Text, out totalsum);
            using (EfContext context = new EfContext())
            {

                context.Realizations.Add(new Entities.Realization
                {
                    Number = txt_Number.Text,
                    DateRealization = Convert.ToDateTime(TxtRealizationDate.Text),
                    PercentageDiscount = discount,
                    TotalPurshaise = fullprice,
                    PaymentSum = prepayment,
                    TotalSum = totalsum,
                    IdClient = idClient
                });
                context.SaveChanges();
                int Idrealiz = context.Realizations.Select(c => c.IdRealization).Max();

                foreach (var product in _ListProduct)   //переробити
                {
                    context.RealizationProducts.Add(new Entities.RealizationProduct
                    {
                        Count = product.CountSale,
                        PriceDollar = product.PriceDollar,
                        PriceUah = product.PriceUah,
                        PriceRetail = product.PriceRetail,
                        PriceWholesale = product.PriceWholesale,
                        NDS = product.NDS,
                        DiscountProduct = product.Discount,
                        TotalProductSum = product.Sum,
                        IdRealization = Idrealiz,
                        Idproduct = product.Idproduct
                    });
                    var std = context.Products.Where(c => c.IdProduct == product.Idproduct).FirstOrDefault();
                    double? sum = std.Count - product.CountSale;
                    std.Count = sum;
                }
               
                context.SaveChanges();
            }
        }

        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Enterprise.ProductList addProduct = new Enterprise.ProductList();
            addProduct.ShowDialog();
            //if (!addProduct._allow)
            try
            {
                
                    var data = new RealizationProductModel
                    {
                        Idproduct = addProduct._idproduct,
                        Name = addProduct._nameProduct,
                        Code = addProduct._codeProduct,
                        //Article = addProduct._article,
                        PriceUah = addProduct._supplierPrice,
                        CountSale = 0,
                        CountReserved = 0,
                        Discount = 0,
                        NDS = 0,
                        Sum = 0,
                        Count = addProduct._count,
                        PriceWholesale = addProduct._priceWholesale,
                    };
               // if (!_ListProduct.Where(a => a.Idproduct == data.Idproduct).)
                if (!IdList.Contains(data.Idproduct))
                {
                    _ListProduct.Add(data);
                    IdList.Add(addProduct._idproduct);

                    realizationGrid.ItemsSource = _ListProduct;
                    realizationGrid.Items.Refresh();
                }
            }
            catch (Exception exception)
            {
            }    
            // realizationGrid.Items.Add(addProduct.item);
            // CalculateAddedItem();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {


        }

        

        private string oldTextDiscount { get; set; }

        private void txt_ClientDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_Discount.Text = txt_ClientDiscount.Text;
            CountValues();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            oldTextDiscount = box.Text;
            box.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text == "")
            {
                box.Text = oldTextDiscount;
            }
            else
            {
                if (Equals(sender, txt_Discount))
                {
                    CountDiscount();
                }

                if (Equals(sender, txt_ClientDiscount) && txt_FullPrice.Text != "")
                {
                    txt_ClientDiscount.Text = txt_ClientDiscount.Text;
                    CountDiscount();
                }
                CountValues();
            }
        }

        private void txt_Discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountValues();
        }

        private void CountValues()
        {
           if(txt_FullPrice.Text != "")
           txt_TotalSum.Text  = ((Convert.ToDouble(txt_FullPrice.Text) - (((txt_DiscountSum.Text) != "")? Convert.ToDouble(txt_DiscountSum.Text) : 0 ) - ((txt_Prepayment.Text != "")? Convert.ToDouble(txt_Prepayment.Text) : 0))).ToString("C");
        }

        private void txt_FullPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountDiscount();
            CountValues();
        }

        private void CountDiscount()
        {
            if (txt_Discount.Text == "")
            {
                txt_DiscountSum.Text = 0.ToString();

            }
            else
            {
                txt_DiscountSum.Text = ((Convert.ToDouble(txt_FullPrice.Text) * Convert.ToDouble(txt_Discount.Text)) / 100).ToString();
            }
        }
        private void txt_Prepayment_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               realizationGrid.Focus();
            }
        }

        private void realizationGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            realizationGrid.Items.Refresh();
        }

        private void RealizationGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            var selected = (RealizationProductModel)realizationGrid.SelectedItem;
            getid = _ListProduct.Find(s => s.Idproduct == selected.Idproduct).Idproduct;
            }
            catch (Exception exception)
            {
                getid = 0;
            }
        }

        private void AutoName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = (Supplier)AutoName.SelectedItem;
                idClient = selected.IdSupplier;
                txt_ClientDiscount.Text = supplier.Find(s => s.IdSupplier == selected.IdSupplier).Discount.ToString();

            }
            catch(Exception ex)
            {
            }
        }

        private void btn_NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            SupplierInfo customer = new SupplierInfo();
            customer.ShowDialog();
        }

        private void Cmb_Organization_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Btn_NewOrganization_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

