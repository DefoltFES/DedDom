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

namespace DedDom.Views
{
    /// <summary>
    /// Interaction logic for AddSubjectInVisit.xaml
    /// </summary>
    public partial class AddSubjectInVisit : Window
    {
        public schedule AddSchedule { get; set; }
        private teacher Teacher { get; set; }
        public AddSubjectInVisit(teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
        }

        private void AddMonday_OnClick(object sender, RoutedEventArgs e)
        {
            if (Monday.SelectedItem != null)
            {
                AddSchedule = Monday.SelectedItem as schedule;
                DialogResult = true;
            }
           
        }

        private void AddSubjectInVisit_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<schedule> ListMonday = App.dbContext.schedules
               .Where(x => x.week_day.Name == "Понедельник" && x.group.Id_teacher == Teacher.Id && x.IsActual == true).ToList();
            List<schedule> ListTuesday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Вторник" && x.group.Id_teacher == Teacher.Id && x.IsActual == true).ToList();
            List<schedule> ListWednesday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Среда" && x.group.Id_teacher == Teacher.Id && x.IsActual == true).ToList();
            List<schedule> ListThursday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Четверг" && x.group.Id_teacher == Teacher.Id && x.IsActual == true).ToList();
            List<schedule> ListFriday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Пятница" && x.group.Id_teacher == Teacher.Id && x.IsActual == true).ToList();
            List<schedule> ListSaturday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Суббота" && x.group.Id_teacher == Teacher.Id && x.IsActual == true).ToList();
            if (ListMonday.Count == 0)
            {
                Monday.Visibility = Visibility.Collapsed;
                EmptyMonday.Visibility = Visibility.Visible;
            }
            if (ListTuesday.Count == 0)
            {
                Tuesday.Visibility = Visibility.Collapsed;
                EmptyTuesday.Visibility = Visibility.Visible;
            }
            if (ListWednesday.Count == 0)
            {
                Wednesday.Visibility = Visibility.Collapsed;
                EmptyWednesday.Visibility = Visibility.Visible;
            }
            if (ListThursday.Count == 0)
            {
                Thursday.Visibility = Visibility.Collapsed;
                EmptyThursday.Visibility = Visibility.Visible;
            }
            if (ListFriday.Count == 0)
            {
                Friday.Visibility = Visibility.Collapsed;
                EmptyFriday.Visibility = Visibility.Visible;
            }
            if (ListSaturday.Count == 0)
            {
                Saturday.Visibility = Visibility.Collapsed;
                EmptySaturday.Visibility = Visibility.Visible;
            }
            Monday.ItemsSource = ListMonday;
            Tuesday.ItemsSource = ListTuesday;
            Wednesday.ItemsSource = ListWednesday;
            Thursday.ItemsSource = ListThursday;
            Friday.ItemsSource = ListFriday;
            Saturday.ItemsSource = ListSaturday;
        }

        private void AddTuesday_OnClick(object sender, RoutedEventArgs e)
        {
            if (Tuesday.SelectedItem != null)
            {
                AddSchedule = Tuesday.SelectedItem as schedule;
                DialogResult = true;
            }
        }

        private void AddWednesday_OnClick(object sender, RoutedEventArgs e)
        {
            if (Wednesday.SelectedItem != null)
            {
                AddSchedule = Wednesday.SelectedItem as schedule;
                DialogResult = true;
            }
        }

        private void AddThursday_OnClick(object sender, RoutedEventArgs e)
        {
            if (Thursday.SelectedItem != null)
            {
                AddSchedule = Thursday.SelectedItem as schedule;
                DialogResult = true;
            }
        }

        private void AddFriday_OnClick(object sender, RoutedEventArgs e)
        {
            if (Friday.SelectedItem != null)
            {
                AddSchedule = Friday.SelectedItem as schedule;
                DialogResult = true;
            }
        }
    }
}
