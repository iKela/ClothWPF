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
using ClothWPF.Authorization.Loading;
using ClothWPF.Entities;
using ClothWPF.Models.Group;

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
            using (EfContext contex = new EfContext())
            {
                try
                {
                    var name = contex.GroupProducts.SingleOrDefault(a => a.NameGroup == TxtName.Text).NameGroup;
                    MessageBox.Show($"Група під назвою \"'{TxtName.Text}'\" вже існує!", "Info",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    TxtName.SelectionBrush = Brushes.LightCoral;
                    TxtName.Focus();
                    TxtName.SelectAll();
                }
                catch
                {
                    contex.GroupProducts.Add(new GroupProduct       //без підгруп
                    {
                        NameGroup = TxtName.Text,
                        CodeGroup = TxtCode.Text,
                        Nds = nds,
                        DescriptionGroup = TxtDescription.Text,
                    });
                    contex.SaveChanges();
                    ConstList._Group.Add(new GroupModel            //без підгруп
                    {
                        IdGroup = contex.GroupProducts.Max(a=>a.IdGroup),
                        NameGroup = TxtName.Text,
                        CodeGroup = TxtCode.Text,
                        Nds = nds,
                        DescriptionGroup = TxtDescription.Text
                    });
                    MessageBox.Show($"Група під назвою \"'{TxtName.Text}'\" успішно створена!", "Info",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }

            }
        }

        private void TxtNDS_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char) KeyInterop.VirtualKeyFromKey(e.Key)))
            {
                e.Handled = true;
            }
        }
    }
}
           
                
                      
                       
