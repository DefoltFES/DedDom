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
    /// Interaction logic for AddScheduleWindow.xaml
    /// </summary>
    public partial class AddScheduleWindow : Window
    {
        public AddScheduleWindow()
        {
            InitializeComponent();
            Subject.ItemsSource = App.dbContext.subjects.Select(s => s.Name).ToList();
            Group.ItemsSource = App.dbContext.groups.Select(g => g.Name).ToList();
            Classroom.ItemsSource = App.dbContext.classroms.Select(c => c.Name).ToList();
            weekDayBox.ItemsSource = App.dbContext.week_day.Select(w => w.Name).ToList();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Subject.SelectedItem != default && startTime.Text != "" && endTime.Text != "" && Group.SelectedItem != default && weekDayBox.SelectedItem != default)
            {
                schedule schedule = new schedule()
                {
                    Id_Subject = App.dbContext.subjects.Where(s => s.Name == Subject.SelectedItem.ToString()).Select(s => s.Id).FirstOrDefault(),
                    Start_Time = TimeSpan.Parse(startTime.Text),
                    End_Time = TimeSpan.Parse(startTime.Text),
                    Id_Classroom = App.dbContext.classroms.Where(c => c.Name == Classroom.SelectedItem.ToString()).Select(c => c.Id).FirstOrDefault(),
                    Id_Group = App.dbContext.groups.Where(g => g.Name == Group.SelectedItem.ToString()).Select(g => g.Id).FirstOrDefault(),
                    Id_Week_Day = App.dbContext.week_day.Where(wd => wd.Name == weekDayBox.SelectedItem.ToString()).Select(wd => wd.Id).FirstOrDefault(),
                    IsActual = isActualCheck.IsChecked
                };
                App.dbContext.schedules.Add(schedule);
                App.dbContext.SaveChanges();
                DialogResult = true;
            }
        }
    }
}
