﻿using ClothWPF.Models.Main;
using ClothWPF.Models.RealizationWindow;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ClothWPF.General.Realization
{
    /// <summary>
    /// Interaction logic for RealizationWindow.xaml
    /// </summary>
    public partial class RealizationWindow : Window
    {
        EfContext context = new EfContext();
        public List<RealizationProductModel> _ListProduct;
        private string value { get; set; }
        private int rowIndex { get; set; }
        Enterprise.ProductList addProduct = new Enterprise.ProductList();
        public RealizationWindow()
        {
            InitializeComponent();
            _ListProduct = new List<RealizationProductModel>();
            realizationGrid.CellEditEnding += realizationGrid_CellEditEnding;
        }

        #region Витяг та призначення значення після його зміни в комірці
        void realizationGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var column = e.Column as DataGridBoundColumn;
                if (column != null)
                {
                    var bindingPath = (column.Binding as Binding).Path.Path;
                    if (bindingPath == "PriceWholesale")
                    {
                        rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;

                        value = el.Text;
                        // rowIndex has the row index
                        // bindingPath has the column's binding
                        // el.Text has the new, user-entered value
                        GetCell(realizationGrid, rowIndex, 8).Content = (Convert.ToDouble(el.Text) * Convert.ToDouble((Convert.ToDouble(GetSingleCellValue(rowIndex, 2)) > 0)? Convert.ToDouble(GetSingleCellValue(rowIndex, 2)): 1)).ToString();
                    }
                    else if (bindingPath == "CountSale")
                    {
                        rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;

                        value = el.Text;
                        // rowIndex has the row index
                        // bindingPath has the column's binding
                        // el.Text has the new, user-entered value
                        if (Convert.ToDouble(el.Text) <= Convert.ToDouble(GetSingleCellValue(rowIndex, 3)))
                        {
                            GetCell(realizationGrid, rowIndex, 8).Content = (Convert.ToDouble(el.Text) * Convert.ToDouble(GetSingleCellValue(rowIndex, 5))).ToString();/*- Convert.ToDouble(GetCell(realizationGrid, rowIndex, 7).Content.ToString()));*/ // Пробую відняти Знижку від Ціни і записати в Суму
                        }
                        else
                        {
                            MessageBox.Show("Вписана кількість перевищує наявну кількість !", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
                            GetCell(realizationGrid, rowIndex, 2).Content = 0;
                        }
                    }
                }
            }
        }

        DataGridCell GetCell(DataGrid realizationGrid, int rowIndex, int columnIndex)
        {
            var dr = realizationGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            var dc = realizationGrid.Columns[columnIndex].GetCellContent(dr);
            return dc.Parent as DataGridCell;
        }
        #endregion

        #region Отримати значення колонкі з усіх рядків
        private string GetSingleCellValue(int roww, int column)
        {
            var dataGrid = realizationGrid as DataGrid;
            if (realizationGrid.Items != null && realizationGrid.Items.Count > 0)
            { 
                var row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(realizationGrid.Items[roww]);
                if (row != null)
                {
                    var presenter = GetVisualChild<DataGridCellsPresenter>(row);

                    if (presenter.ItemContainerGenerator.ContainerFromIndex(column) is DataGridCell cell)
                    {
                        return ((TextBlock)cell.Content).Text;
                    }
                }
                

            }
            return null;
        }
        private void GetColumnValue()
        {
            var dataGrid = realizationGrid as DataGrid;
            if (realizationGrid.Items != null && realizationGrid.Items.Count > 0)
            {

                for (int i = 0; i < realizationGrid.Items.Count; i++)
                {
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(i);
                    if (row != null)
                    {
                        int index = 0;
                        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

                        foreach (DataGridColumn Sum in realizationGrid.Columns)
                        {
                            if (Sum.DisplayIndex == 5)
                            {
                                index = Sum.DisplayIndex;
                            }
                        }
                        DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(index) as DataGridCell;
                        if (cell != null)
                        {
                            MessageBox.Show(((TextBlock)cell.Content).Text);
                            if (txt_FullPrice.Text != "")
                            {
                                txt_FullPrice.Text = (Convert.ToDouble(txt_FullPrice.Text) + Convert.ToDouble(((TextBlock)cell.Content).Text)).ToString();
                            }
                            else
                            {
                                txt_FullPrice.Text += ((TextBlock)cell.Content).Text;
                            }
                        } 
                    }
                }

            }
        }
        static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null) child = GetVisualChild<T>(v);
                if (child != null) break;
            }
            return child;
        }
        #endregion

        private void btn_Calculation_Click(object sender, RoutedEventArgs e)
        {
            GetColumnValue();
        }
        
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            addProduct.ShowDialog();
            var data = new RealizationProductModel
            {
                Idproduct = addProduct._idproduct,
                Name = addProduct._nameProduct,
                Code = addProduct._codeProduct,
                //Article = addProduct._article,
                CountSale=0,
                CountReserved=0,
                Discount=0,
                NDS=0,
                Sum=0,
                Count = addProduct._count,
                PriceWholesale = addProduct._priceWholesale,
            };
            _ListProduct.Add(data);
            realizationGrid.ItemsSource = _ListProduct;
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
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var edit = _ListProduct.Where(a=>a.==realizationGrid.SelectedItem).
        }
        void Add()
        {
            //foreach (var product in )   //переробити
            //{
            //    context.RealizationProducts.Add(new Entities.RealizationProduct
            //    {
            //        Count = product.CountArrival,
            //        PriceDollar = product.PriceDollarArrival,
            //        PriceUah = product.PriceUahArrival,
            //        PriceRetail = product.PriceRetailArrival,
            //        PriceWholesale = product.PriceWholesaleArrival,
        
            //        Idproduct = product.IdProduct
            //    });
            //    var std = context.Products.Where(c => c.IdProduct == product.IdProduct).FirstOrDefault();
            //    std.PriceDollar = product.PriceDollarArrival;
            //    std.PriceRetail = product.PriceRetailArrival;
            //    std.PriceWholesale = product.PriceWholesaleArrival;
            //    double? sum = std.Count == null ? product.CountArrival : std.Count + product.CountArrival;
            //    std.Count = sum;
            //}
            //context.SaveChanges();
        }

        private string oldTextDiscount { get; set; }
        private void txt_ClientDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt_Discount.Text = txt_ClientDiscount.Text;
            CountValues();
        }

        private void txt_ClientDiscount_LostFocus(object sender, RoutedEventArgs e)
        {
            txt_ClientDiscount.Text = (txt_ClientDiscount.Text + "%");
            
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
        }
        private void txt_Discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txt_Discount.Text = txt_Discount.Text + "%";
            CountValues();
        }
        private void CountValues()
        {
            //string discountSum = "0";
            //if (txt_FullPrice.Text != "" || txt_FullPrice.Text != "0")
            //{ 
            //    if (txt_Discount.Text != "" || txt_Discount.Text != "0")
            //    {
            //        discountSum = ((Convert.ToDouble(txt_FullPrice.Text) * Convert.ToDouble(txt_Discount.Text)) / 100).ToString();
            //        txt_DiscountSum.Text = discountSum;
            //    }
            // txt_TotalSum.Text = ((Convert.ToDouble(txt_FullPrice.Text) - Convert.ToDouble(discountSum)) - Convert.ToDouble(txt_Prepayment.Text)).ToString();
            //}
        }

        private void txt_FullPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountValues();
        }

        private void txt_Prepayment_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountValues();

        }
    }
}
