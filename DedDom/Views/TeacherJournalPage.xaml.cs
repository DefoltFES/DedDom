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
    /// Interaction logic for TeacherJournalPage.xaml
    /// </summary>
    public partial class TeacherJournalPage : Page
    {
        private teacher Teacher { get; set; }
        public TeacherJournalPage(teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
        }

        private void TeacherJournalPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<visit_log> Visits = Teacher.visit_log.ToList();
            ListVisit.ItemsSource = Visits;
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
