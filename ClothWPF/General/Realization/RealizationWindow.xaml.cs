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
        private string value { get; set; }
        public RealizationWindow()
        {
            InitializeComponent();

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
                    if (bindingPath == "Ціна")
                    {
                        int rowIndex = e.Row.GetIndex();
                        var el = e.EditingElement as TextBox;

                        value = el.Text;
                        // rowIndex has the row index
                        // bindingPath has the column's binding
                        // el.Text has the new, user-entered value
                        GetCell(realizationGrid, rowIndex, realizationGrid.Columns.Count).Content = (Convert.ToDouble(el.Text) - Convert.ToDouble(GetCell(realizationGrid, rowIndex, 7).Content.ToString())); // Пробую відняти Знижку від Ціни і записати в Суму
                        MessageBox.Show(value);
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
        private void CalculateAddedItems()
        {
            DataGrid dataGrid = realizationGrid as DataGrid;
            if (realizationGrid.Items != null && realizationGrid.Items.Count > 0)
            {

                for (int i = 0; i < realizationGrid.Items.Count; i++)
                {
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(realizationGrid.Items[i]);
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
            CalculateAddedItems();
        }
        
        private void btn_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Enterprise.ProductList addProduct = new Enterprise.ProductList();
            addProduct.ShowDialog();
            realizationGrid.Items.Add(addProduct.item);
           // CalculateAddedItem();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentPrincipal.IsInRole("Administrators"))
            {
                //Product obj = ((FrameworkElement)sender).DataContext as Product;
                if (realizationGrid.SelectedItem != null)
                {
                    try
                    {
                        using (EfContext context = new EfContext())
                        {
                            //context.Products.Remove(context.Products.Find(obj.IdProduct));
                            //context.SaveChanges();
                        }
                        //loaded();
                        MessageBox.Show("Видалено!!!", "Amazon Web Service!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ви не володієте правами для видалення", "Увага!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
