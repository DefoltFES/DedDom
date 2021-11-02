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
            this.NavigationService.Navigate(new CreateOrEditVisitLog(new visit_log(),Teacher));
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            visit_log log = (sender as Button).DataContext as visit_log;
            var dialogItem = MessageBox.Show("Вы действительно хотите удалить отчет?","Предупреждение",MessageBoxButton.YesNo);
            if (dialogItem == MessageBoxResult.Yes)
            {
                App.dbContext.visits.RemoveRange(log.visits);
                App.dbContext.visit_log.Remove(log);
                App.dbContext.SaveChanges();
                List<visit_log> Visits = Teacher.visit_log.ToList();
                ListVisit.ItemsSource = Visits;
            }
         
        }

        private void Details_OnClick(object sender, RoutedEventArgs e)
        {
            visit_log log = (sender as Button).DataContext as visit_log;
            this.NavigationService.Navigate(new CreateOrEditVisitLog(log,Teacher,true));
        }
    }
}
