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
    /// Interaction logic for AdminSchedulePage.xaml
    /// </summary>
    public partial class AdminSchedulePage : Page
    {
        public AdminSchedulePage()
        {
            InitializeComponent();
        }

        private void AdminSchedulePage_Loaded(object sender, RoutedEventArgs e)
        {
            List<schedule> ListMonday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Понедельник" && x.IsActual == true).ToList();
            List<schedule> ListTuesday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Вторник" && x.IsActual == true).ToList();
            List<schedule> ListWednesday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Среда" && x.IsActual == true).ToList();
            List<schedule> ListThursday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Четверг" && x.IsActual == true).ToList();
            List<schedule> ListFriday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Пятница" && x.IsActual == true).ToList();
            List<schedule> ListSaturday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Суббота" && x.IsActual == true).ToList();
            
            monday.ItemsSource = ListMonday;
            tuesday.ItemsSource = ListTuesday;
            wednesday.ItemsSource = ListWednesday;
            thursday.ItemsSource = ListThursday;
            friday.ItemsSource = ListFriday;
            saturday.ItemsSource = ListSaturday;

        }

        private void addScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            AddScheduleWindow win = new AddScheduleWindow();
            win.ShowDialog();
            
            List<schedule> ListMonday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Понедельник" && x.IsActual == true).ToList();
            List<schedule> ListTuesday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Вторник" && x.IsActual == true).ToList();
            List<schedule> ListWednesday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Среда" && x.IsActual == true).ToList();
            List<schedule> ListThursday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Четверг" && x.IsActual == true).ToList();
            List<schedule> ListFriday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Пятница" && x.IsActual == true).ToList();
            List<schedule> ListSaturday = App.dbContext.schedules
                .Where(x => x.week_day.Name == "Суббота" && x.IsActual == true).ToList();

            monday.ItemsSource = ListMonday;
            tuesday.ItemsSource = ListTuesday;
            wednesday.ItemsSource = ListWednesday;
            thursday.ItemsSource = ListThursday;
            friday.ItemsSource = ListFriday;
            saturday.ItemsSource = ListSaturday;
            saturday.UpdateLayout();
        }
    }
}
