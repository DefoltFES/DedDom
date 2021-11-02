using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for CreateOrEditVisitLog.xaml
    /// </summary>
    public partial class CreateOrEditVisitLog : Page
    {
        private teacher Teacher { get; set; }
        private schedule Schedules { get; set; }
        private visit_log log { get; set; }
        private List<visit> visits { get; set; }
        private bool isEdit { get; set; }
        public CreateOrEditVisitLog(visit_log log, teacher teacher,bool isEdit=false)
        {
            InitializeComponent();
            Teacher = teacher;
            this.log = log;
            this.isEdit = isEdit;


        }

        private void AddShedule_OnClick(object sender, RoutedEventArgs e)
        {
            List<schedule> list= new List<schedule>();
            AddSubjectInVisit dialogWindow=new AddSubjectInVisit(Teacher);
            if (dialogWindow.ShowDialog() == true)
            {
                list.Add(dialogWindow.AddSchedule);
                Schedules = dialogWindow.AddSchedule;
                Schedule.ItemsSource = list;
                List<visit> children = new List<visit>();
                foreach (var item in dialogWindow.AddSchedule.group.students.ToList())
                {
                    children.Add(new visit()
                    {
                        student = item,
                        isPresent = false
                    });
                }

                visits = children;
                ListPeople.ItemsSource = visits;
            }
           
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (App.dbContext.visit_log.Where(x=>x.schedule.Id==Schedules.Id && x.Date==DateLog.SelectedDate).FirstOrDefault()!=null)
            {
                MessageBox.Show("Такой отчет уже существует","Ошибка");
                return;
            }
            if (isEdit == true)
            {
                if (log.Date != DateLog.SelectedDate)
                {
                    log.Date = DateLog.SelectedDate;
                }

                if (log.schedule != Schedules)
                {
                    log.schedule = Schedules;
                }
             
                log.visits = visits;
                App.dbContext.visit_log.Attach(log);
                App.dbContext.Entry(log).State = EntityState.Modified;
                App.dbContext.SaveChanges();
            }
            if (isEdit == false)
            {
                log.teacher = Teacher;
                log.Date = DateLog.SelectedDate;
                log.schedule = Schedules;
                log.visits = visits;
                App.dbContext.visit_log.Add(log);
                App.dbContext.SaveChangesAsync();
            }
            this.NavigationService.GoBack();

        }

        private void DateLog_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateLog.SelectedDate > DateTime.Now)
            {
                DateLog.SelectedDate = null;
            }
        }

        private void CreateOrEditVisitLog_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                Save.Visibility = Visibility.Collapsed;
                Edit.Visibility = Visibility.Visible;
                AddSchedule.Visibility = Visibility.Collapsed;
                Cancel.Content = "Назад";
                Schedules = log.schedule;
                visits = log.visits.ToList();
                DateLog.SelectedDate = log.Date;
                DateLog.IsEnabled = false;
                Schedule.ItemsSource = new List<schedule>() {Schedules};
                ListPeople.ItemsSource = visits;
                ListPeople.IsEnabled = false;
            }
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            Save.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Collapsed;
            AddSchedule.Visibility = Visibility.Visible;
            Cancel.Content = "Отмена";
            ListPeople.IsEnabled = true;
            DateLog.IsEnabled = true;

        }
    }
}
