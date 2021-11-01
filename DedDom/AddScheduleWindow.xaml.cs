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

namespace DedDom
{
    /// <summary>
    /// Interaction logic for AddScheduleWindow.xaml
    /// </summary>
    public partial class AddScheduleWindow : Window
    {
        public AddScheduleWindow()
        {
            InitializeComponent();
            subjectBox.ItemsSource = App.dbContext.subjects.Select(s => s.Name).ToList();
            groupBox.ItemsSource = App.dbContext.groups.Select(g => g.Name).ToList();
            classroomBox.ItemsSource = App.dbContext.classroms.Select(c => c.Name).ToList();
            weekDayBox.ItemsSource = App.dbContext.week_day.Select(w => w.Name).ToList();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            if (subjectBox.SelectedItem != default && startTime.Text != "" && endTime.Text != "" && groupBox.SelectedItem != default && weekDayBox.SelectedItem != default)
            {
                schedule schedule = new schedule()
                {
                    Id_Subject = App.dbContext.subjects.Where(s => s.Name == subjectBox.SelectedItem.ToString()).Select(s => s.Id).FirstOrDefault(),
                    Start_Time = TimeSpan.Parse(startTime.Text),
                    End_Time = TimeSpan.Parse(startTime.Text),
                    Id_Classroom = App.dbContext.classroms.Where(c=>c.Name == classroomBox.SelectedItem.ToString()).Select(c=>c.Id).FirstOrDefault(),
                    Id_Group = App.dbContext.groups.Where(g => g.Name == groupBox.SelectedItem.ToString()).Select(g => g.Id).FirstOrDefault(),
                    Id_Week_Day = App.dbContext.week_day.Where(wd => wd.Name == weekDayBox.SelectedItem.ToString()).Select(wd => wd.Id).FirstOrDefault(),
                    IsActual = isActualCheck.IsChecked
                };
                App.dbContext.schedules.Add(schedule);
                App.dbContext.SaveChanges();
                this.Close();
            }
           
        }
    }
}
