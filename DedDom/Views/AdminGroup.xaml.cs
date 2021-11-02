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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DedDom
{
    /// <summary>
    /// Логика взаимодействия для AdminGroup.xaml
    /// </summary>
    public partial class AdminGroup : Page
    {
        public AdminGroup()
        {
            InitializeComponent();
            snus.ItemsSource = App.dbContext.groups.Select(s => s).ToList();
        }

        private void snus_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void snus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Group = (sender as DataGrid).SelectedItem as group;
            editGroupsWin editGroup = new editGroupsWin(Group);
            editGroup.ShowDialog();
            snus.ItemsSource = App.dbContext.groups.Select(s => s).ToList();
            snus.UpdateLayout();

        }
    }
}
