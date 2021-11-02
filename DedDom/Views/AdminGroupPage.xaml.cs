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

namespace DedDom.Views
{
    /// <summary>
    /// Interaction logic for AdminGroupPage.xaml
    /// </summary>
    public partial class AdminGroupPage : Page
    {
        public AdminGroupPage()
        {
            InitializeComponent();
        }

        private void DetailsClick(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as group;
            this.NavigationService.Navigate(new AdminDetailGroupPage(item,true));
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as group;
            var result = MessageBox.Show("Вы хотите удалить группу ?","Предупреждение",MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                App.dbContext.schedules.RemoveRange(item.schedules);
                App.dbContext.groups.Remove(item);
                App.dbContext.SaveChanges();
                Groups.ItemsSource = App.dbContext.groups.ToList();

            }
        }

        private void AdminGroupPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Groups.ItemsSource = App.dbContext.groups.ToList();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminDetailGroupPage(new @group()));
        }
    }
}
