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

namespace PojectGANkurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void autorizate_Click(object sender, RoutedEventArgs e)
        {
            registrGANEntities con = new registrGANEntities();
            string lgn = Logintxt.Text;
            string pswrd = Passwordtxt.Password.ToString();
            if (autorizat(lgn, pswrd) == false)
            {
                Logintxt.Text = "";
                Passwordtxt.Password = "";
            }
            else
            {
                var getuser = con.UserRegistr.Where(w => w.Login == lgn && w.Password == pswrd).FirstOrDefault();
                windowfolder.Raspisanie a = new windowfolder.Raspisanie();
                MessageBox.Show("Вы авторизировались как: " + getuser.FirstName + " " + getuser.LastName);
                a.Show();
                this.Close();
            }
        }
        public bool autorizat(string login, string Password)
        {
            registrGANEntities connect = new registrGANEntities();
            if (login == "" && Password == "")
            {
                MessageBox.Show("Введите данные");
                return false;
            }
            else if (login == "")
            {
                MessageBox.Show("Введите логин");
                return false;
            }
            else if (Password == "")
            {
                MessageBox.Show("Введите пароль");
                return false;
            }
            else
            {
                if (!connect.UserRegistr.Select(s => s.Login + " " + s.Password).Contains(login + " " + Password))
                {
                    MessageBox.Show("Пользователя не существует");
                    return false;
                }
                else
                {
                    var getuser = connect.UserRegistr.Where(w => w.Login == login && w.Password == Password).FirstOrDefault();
                    mycls.userid = getuser.iduserR;
                    return true;
                }
            }
        }
    }
}
