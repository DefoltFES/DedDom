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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private teacher Teacher { get; set; }
        private string login;
        private string password;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" || Login.Text == "Логин" || Password.Text=="" || Password.Text=="Пароль")
            {
                Error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                login = Login.Text;
                password = Password.Text;
            }
            if (isExist())
            {
                MessageBox.Show("Хорошо");
            }
            else
            {
                Error.Visibility = Visibility.Visible;
            }
        }

        public  bool isExist()
        {
            
            var teacher = App.dbContext.teachers.Where(x => x.Login==login).FirstOrDefault();
            if (teacher != null)
            {
                if (teacher.Password == password)
                {
                    Teacher = teacher;
                    return true;
                }
            }
            return false;
        }

        private void Text_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var x = sender as TextBox;
            x.Text = string.Empty;
            x.GotFocus -= Text_OnGotFocus;
        }
    }
}
