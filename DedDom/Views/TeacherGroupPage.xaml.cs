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
    /// Interaction logic for TeacherGroupPage.xaml
    /// </summary>
    public partial class TeacherGroupPage : Page
    {
        private teacher Teacher { get; set; }
        public TeacherGroupPage(teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
        }

        private void TeacherGroupPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<group> groups = Teacher.groups.ToList();
            Groups.ItemsSource = groups;
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            group group = (sender as Button).DataContext as group;
            this.NavigationService.Navigate(new DetailsGroupPage(group));
        }
    }
}
