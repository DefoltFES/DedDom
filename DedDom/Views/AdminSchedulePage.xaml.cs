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
    /// Interaction logic for AdminSchedulePage.xaml
    /// </summary>
    public partial class AdminSchedulePage : Page
    {
        private List<schedule> SearchSchedules { get; set; }
        private List<schedule> AllSchedules { get; set; }
        private List<string> Teachers { get; set; }
        public AdminSchedulePage()
        {
            InitializeComponent();
            Teachers = new List<string>();
        }

        private void AdminSchedulePage_OnLoaded(object sender, RoutedEventArgs e)
        {
            AllSchedules= App.dbContext.schedules.ToList();
            Schedule.ItemsSource = AllSchedules;
            Subject.ItemsSource = App.dbContext.subjects.Select(s => s.Name).ToList();
            
            foreach (var item in App.dbContext.teachers.ToList())
            {
                if (item.Name != null && item.Surname != null && item.Middlename != null)
                {
                    Teachers.Add($"{item.Surname} {item.Name} {item.Middlename}");
                }
            }

            Teacher.ItemsSource = Teachers;
            DayOfWeek.ItemsSource = App.dbContext.week_day.Select(w => w.Name).ToList();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Default_OnClick(object sender, RoutedEventArgs e)
        {
            DayOfWeek.SelectedItem = null;
            Teacher.SelectedItem = null;
            Subject.SelectedItem = null;
            Actual.IsChecked = false;
            Schedule.ItemsSource = AllSchedules;
        }

        private void Search_OnClick(object sender, RoutedEventArgs e)
        {
            if (DayOfWeek.SelectedItem==null && Teacher.SelectedItem==null && Subject.SelectedItem==null && Actual.IsChecked==false)
            {
                return;
            }


            if (DayOfWeek.Text!="" && Teacher.SelectedItem == null && Subject.SelectedItem == null && Actual.IsChecked == false)
            {
                Schedule.ItemsSource = App.dbContext.schedules.Where(x=>x.week_day.Name==DayOfWeek.Text).ToList();
            }
            if (DayOfWeek.Text != "" && Teacher.SelectedItem != null && Subject.SelectedItem == null && Actual.IsChecked == false)
            {
                var item = Teacher.Text.Split('.');
                var name = item[1];
                var surname = item[0];
                var middlename = item[2];
                Schedule.ItemsSource = App.dbContext.schedules.Where(x => x.week_day.Name == DayOfWeek.Text && x.group.teacher.Name==name && x.group.teacher.Surname==surname && x.group.teacher.Middlename==middlename).ToList();
            }
            if (DayOfWeek.Text != "" && Teacher.SelectedItem != null && Subject.SelectedItem != null && Actual.IsChecked == false)
            {
                var item = Teacher.Text.Split('.');
                var name = item[1];
                var surname = item[0];
                var middlename = item[2];
                Schedule.ItemsSource = App.dbContext.schedules.Where(x => x.week_day.Name == DayOfWeek.Text && x.group.teacher.Name == name && x.group.teacher.Surname == surname && x.group.teacher.Middlename == middlename  && x.subject.Name==Subject.Text).ToList();
            }
            if (DayOfWeek.Text != "" && Teacher.SelectedItem != null && Subject.SelectedItem != null && Actual.IsChecked == true)
            {
                var item = Teacher.Text.Split('.');
                var name = item[1];
                var surname = item[0];
                var middlename = item[2];
                Schedule.ItemsSource = App.dbContext.schedules.Where(x => x.week_day.Name == DayOfWeek.Text && x.group.teacher.Name == name && x.group.teacher.Surname == surname && x.group.teacher.Middlename == middlename && x.subject.Name == Subject.Text && x.IsActual==false).ToList();
            }

            if (DayOfWeek.Text != ""  && Subject.SelectedItem != null )
            {
                Schedule.ItemsSource = App.dbContext.schedules.Where(x => x.week_day.Name == DayOfWeek.Text && x.subject.Name==Subject.Text).ToList();
            }

            if (DayOfWeek.SelectedItem != null)
            {
                Schedule.ItemsSource = App.dbContext.schedules.Where(x => x.week_day.Name == DayOfWeek.Text).ToList();
            }
            if (Teacher.SelectedItem != null)
            {
                var item = Teacher.Text.Split('.');
                var name = item[1];
                var surname = item[0];
                var middlename = item[2];
                Schedule.ItemsSource = App.dbContext.schedules.Where(x => x.group.teacher.Name == name && x.group.teacher.Surname == surname && x.group.teacher.Middlename == middlename && x.subject.Name == Subject.Text).ToList();
            }
            if (Subject.SelectedItem != null)
            {
                Schedule.ItemsSource = App.dbContext.schedules.Where(x => x.subject.Name==Subject.Text).ToList();
            }

            var list = Schedule.ItemsSource as List<schedule>;
            if (list.Count == 0)
            {
                Empty.Visibility = Visibility.Visible;
                Schedule.Visibility = Visibility.Collapsed;
            }
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            AddScheduleWindow schedule = new AddScheduleWindow();
            if (schedule.ShowDialog() == true)
            {
                Schedule.ItemsSource = App.dbContext.schedules.ToList();
            }
            
        }
    }
}
