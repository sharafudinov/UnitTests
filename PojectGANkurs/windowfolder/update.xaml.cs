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
    /// Логика взаимодействия для update.xaml
    /// </summary>
    public partial class update : Window
    {
        public update()
        {
            InitializeComponent();
            registrGANEntities connect = new registrGANEntities();
            if (mycls.id == -1 || mycls.id == 0)
            {

            }
            else
            {
                var thisupdate = connect.Patients.Where(w => w.idPatiens == mycls.id).FirstOrDefault();
                firstname.Text  = thisupdate.FirstName;
                lastname.Text = thisupdate.LastName;
                Middlename.Text = thisupdate.MiddleName;
                Phonenumber.Text = thisupdate.Phone;
                Email.Text = thisupdate.Email;
                adress.Text = thisupdate.Adress;
            }
        }

        private void registationup_Click(object sender, RoutedEventArgs e)
        {
            if (firstname.Text== "" && lastname.Text== "" && Middlename.Text == "" && Phonenumber.Text== "" && Email.Text== "" && adress.Text =="" &&  mycls.id == -1 && mycls.id == 0 )
            {
                MessageBox.Show("Данные не введены");
            }
            else if (mycls.id == -1 || mycls.id == 0)
            {
                MessageBox.Show("Пациент не выбран");
            }
            else  if(firstname.Text == "")
            {
                MessageBox.Show("Не написано имя пациента");
            }
            else if (lastname.Text == "")
            {
                MessageBox.Show("Не написано фамилия пациента");
            }
            else if (Phonenumber.Text == "")
            {
                MessageBox.Show("Не введен номер телефон");
            }
            else if (Email.Text == "")
            {
                MessageBox.Show("Не введен email");
            }
            else if (adress.Text == "")
            {
                MessageBox.Show("Не введен адресс");
            }
            else
            {
                thisupdate(firstname.Text, lastname.Text, Middlename.Text, Phonenumber.Text, Email.Text, adress.Text, mycls.id);
            }
        }

        public bool thisupdate(string fname, string lname, string middlen, string phon, string emaill, string adresss, int idd)
        {
            registrGANEntities connect = new registrGANEntities();
            var com = connect.Patients.Where(w => w.idPatiens == idd).ToList();
            if (idd == -1 || idd == 0 || com.Count == 0 || !com.Any())
            {
                return false;
            }
            else
            {
                var thisupdate = connect.Patients.Where(w => w.idPatiens == idd).FirstOrDefault();
                thisupdate.FirstName = fname;
                thisupdate.LastName = lname;
                thisupdate.MiddleName = middlen;
                thisupdate.Phone = phon;
                thisupdate.Email = emaill;
                thisupdate.Adress = adresss;
                connect.SaveChanges();
                this.Close();
                return true;
            }
        }

        private void registationof_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
