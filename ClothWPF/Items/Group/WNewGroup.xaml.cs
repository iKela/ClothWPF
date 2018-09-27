using System;
using System.Collections.Generic;
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
using ClothWPF.Entities;

namespace ClothWPF.Items.Group
{
    /// <summary>
    /// Interaction logic for WNewGroup.xaml
    /// </summary>
    public partial class WNewGroup : Window
    {
        public WNewGroup()
        {
            InitializeComponent();
        }

        private void btn_CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AutoGroup_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_Add_OnClick(object sender, RoutedEventArgs e)
        {
            double nds = 0;
            Double.TryParse(TxtNDS.Text, out nds);
            try
            {
                using (EfContext contex = new EfContext())
                {
                    contex.GroupProducts.Add(new GroupProduct
                    {
                        NameGroup = TxtName.Text,
                        CodeGroup = TxtCode.Text,
                        Nds = nds,
                        DescriptionGroup = TxtDescription.Text
                        //IdSubGrop = 
                    });
                    contex.SaveChanges();
                }

                MessageBox.Show($"Група під назвою \"'{TxtName.Text}'\" успішно створена!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearWindow();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           

        }

        private void ClearWindow()
        {
            foreach (Control ctl in PanelMain.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                    ((TextBox)ctl).Text = String.Empty;
            }
        }
    }
}
