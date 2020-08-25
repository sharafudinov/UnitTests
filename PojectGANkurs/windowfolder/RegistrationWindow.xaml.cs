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

namespace PojectGANkurs.windowfolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void registationof_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void registationup_Click(object sender, RoutedEventArgs e)
        {
            registration(firstname.Text, lastname.Text, Middlename.Text, Email.Text, adress.Text, Phonenumber.Text);
        }

        public bool registration (string FirstN, string LastN, string MiddleN, string emal, string Adrss,  string phne)
        {
            registrGANEntities Connect = new registrGANEntities();
            Patients asd = new Patients();
            if (FirstN == "" && LastN == "" && emal == "" && Adrss == "" && phne == "")
            {
                MessageBox.Show("Нужно заполнить все данные");
                return false;
            }
            else if (FirstN == "")
            {
                MessageBox.Show("Вы не ввели Имя");
                return false;
            }
            else if (LastN == "")
            {
                MessageBox.Show("Вы не ввели Фамилию");
                return false;
            }
            else if (emal == "")
            {
                MessageBox.Show("Вы не ввели электронную почту");
                return false;
            }
            else if (Adrss == "")
            {
                MessageBox.Show("Вы не ввели адресс");
                return false;
            }
            else if (phne == "")
            {
                MessageBox.Show("Вы не ввели номер телефона");
                return false;
            }
            else
            {
                Patients newpa = new Patients()
                {
                    FirstName = FirstN,
                    LastName = LastN,
                    Email = emal,
                    MiddleName = MiddleN,
                    Adress = Adrss,
                    Phone = phne
                };
                asd = newpa;
                
            };
            Connect.Patients.Add(asd);
            Connect.SaveChanges();
            this.Close();
            return true;
        }
    }

} 
