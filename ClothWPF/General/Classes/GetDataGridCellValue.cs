using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace ClothWPF.General.Classes
{
    public class GetDataGridCellValue
    {
        public void GetSingleCellValue(DataGrid dataGrid, int row, int column)
        {

        }
        public void GetColumnValue(DataGrid dGrid, int column)
        {
            DataGrid dataGrid = dGrid as DataGrid;
            if (dGrid.Items != null && dGrid.Items.Count > 0)
            {

                for (int i = 0; i < dGrid.Items.Count; i++)
                {
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dGrid.Items[i]);
                    if (row != null)
                    {
                        int index = 0;
                        DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

                        foreach (DataGridColumn Sum in dGrid.Columns)
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
                            string value = ((TextBlock)cell.Content).Text;
                            //return (TextBlock)cell.Content;
                            
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
    }
}
