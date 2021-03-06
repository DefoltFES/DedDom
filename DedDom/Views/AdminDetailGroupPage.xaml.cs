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
    /// Interaction logic for AdminDetailGroupPage.xaml
    /// </summary>
    public partial class AdminDetailGroupPage : Page
    {
        private group Group { get; set; }
        private bool isEdit { get; set; }
        public AdminDetailGroupPage(group group,bool isEdit=false)
        {
            InitializeComponent();
            Group = group;
            this.isEdit = isEdit;
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AdminDetailGroupPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            var Teachers = new List<string>();
            foreach (var item in App.dbContext.teachers.ToList())
            {
                if (item.Name != null && item.Surname != null && item.Middlename != null)
                {
                    Teachers.Add($"{item.Surname}.{item.Name}.{item.Middlename}");
                }
            }
            Teacher.ItemsSource = Teachers;
            if (isEdit)
            {
                Name.Text = Group.Name;
                Name.IsEnabled = false;
                Save.Visibility = Visibility.Collapsed;
                Edit.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Collapsed;
                Teacher.IsEnabled = false;
                Teacher.SelectedItem = Teachers.Where(x=>x==$"{Group.teacher.Surname}.{Group.teacher.Name}.{Group.teacher.Middlename}").First();
                Students.ItemsSource = Group.students.ToList();
            }
            
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            Name.IsEnabled = true;
            Save.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Visible;
            Teacher.IsEnabled = true;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                return;
            }
            Group.Name = Name.Text;
            var item = Teacher.Text.Split('.');
            var name = item[1];
            var surname = item[0];
            var middlename = item[2];
            Group.teacher = App.dbContext.teachers.Where(teacher =>
                teacher.Name == name && teacher.Surname == surname && teacher.Middlename == middlename).First();
            Group.students = Students.DataContext as List<student>;
            if (isEdit == false)
            {
                App.dbContext.groups.Add(Group);
                App.dbContext.SaveChanges();
            }
            else
            {
                App.dbContext.groups.Attach(Group);
                App.dbContext.Entry(Group).State = EntityState.Modified;
                App.dbContext.SaveChanges();
            }
          this.NavigationService.GoBack();
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            AddChildrenInGroup children = new AddChildrenInGroup();
            
            if (children.ShowDialog() == true)
            {
                Students.ItemsSource = children.AddStudents;
            }
           
        }
    }
}
