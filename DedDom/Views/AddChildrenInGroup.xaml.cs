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
    /// Interaction logic for AddChildrenInGroup.xaml
    /// </summary>
    public partial class AddChildrenInGroup : Window
    {
        public List<student> AddStudents { get; set; }
        public AddChildrenInGroup()
        {
            InitializeComponent();
            Students.ItemsSource = App.dbContext.students.ToList();
            AddStudents=new List<student>();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
           
            foreach (var item in Students.SelectedItems)
            {
                AddStudents.Add(item as student);
            }
            DialogResult = true;
        }
    }
}
