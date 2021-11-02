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
    /// Логика взаимодействия для editGroupsWin.xaml
    /// </summary>
    public partial class editGroupsWin : Window
    {
        public group group1 { get; set; }
        public editGroupsWin(group group)
        {
            var teachers = App.dbContext.teachers.Select(s => s.Surname + s.Name + s.Middlename).ToList();

            group1 = group;
            InitializeComponent();
            this.DataContext = group1;
            nameBox.ItemsSource = teachers;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            group1.Name = Convert.ToString(title.Text);
            var huy = nameBox.SelectedItem.ToString();
            
            var huy2 = App.dbContext.groups.Where(s => (s.teacher.Surname + s.teacher.Name + s.teacher.Middlename) == huy).Select(s1 => s1.teacher.Surname + s1.teacher.Name + s1.teacher.Middlename).First().ToString();

            var serega = App.dbContext.groups.Where(s => huy2 == huy && s.Name == title.Text.ToString()).Select(s => s.teacher.Id).First();

            group1.Id_teacher = serega;
            App.dbContext.SaveChanges();
            this.Close();
        }
    }
}
