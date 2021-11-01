using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DetailsGroupPage.xaml
    /// </summary>
    public partial class DetailsGroupPage : Page
    {
        private group Group { get; set; }
        public DetailsGroupPage(group group)
        {
            InitializeComponent();
            Group = group;
        }

        private void DetailsGroupPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Students.ItemsSource = Group.students.ToList();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
