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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            registrGANEntities connect = new registrGANEntities();
            if (mycls.idrasp == -1 || mycls.idrasp == 0)
            {
                MessageBox.Show("");
            }
            else
            {
                var regi = connect.Registr.Where(w => w.idRegistr == mycls.idrasp).FirstOrDefault();
                patientsfname.Text = regi.Patients.FirstName;
                patientslname.Text = regi.Patients.LastName;
                docfname.Text = regi.Rasp.Doctors.FirstName;
                doclname.Text = regi.Rasp.Doctors.LastName;
                docrole.Text = regi.Rasp.Doctors.Role;
                dayy.Text = regi.date;
                timee.Text = regi.time;
                typepayer.Text = regi.Typepay.name;
            }
        }

        public bool thisupdate(string dayys, string timmes, int idd, int id)
        {
            registrGANEntities connect = new registrGANEntities();

            var chec = connect.Registr.Where(w => w.idRegistr == id).ToList();
            if (idd == -1 || idd == 0 || !chec.Any() || chec.Count == 0)
            {
                return false;
            }
            else
            {
                
                var thisupdate = connect.Registr.Where(w => w.idRegistr == id).FirstOrDefault();
                thisupdate.date = dayys;
                thisupdate.time = timmes;
                thisupdate.idTypepay = idd;
                connect.SaveChanges();
                this.Close();
                return true;
            }
        }
        private void btnbck_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btngo_Click(object sender, RoutedEventArgs e)
        {
            int idpay;
            if (dayy.Text == "" && timee.Text == "" && typepayer.Text == "")
            {
                MessageBox.Show("Вы стрерли данные для изменения");
            }
            else if (dayy.Text == "" )
            {
                MessageBox.Show("Вы стрерли дату");
            }
            else if (timee.Text == "" )
            {
                MessageBox.Show("Вы стрерли время приема");
            }
            else if (typepayer.Text == "ОМС")
            {
                idpay = 1;
                thisupdate(dayy.Text, timee.Text, idpay, mycls.idrasp);
            }
            else if (typepayer.Text == "Личные средства")
            {
                idpay = 2;
                thisupdate(dayy.Text, timee.Text, idpay, mycls.idrasp);
            }
            else if (typepayer.Text == "Страховой случай")
            {
                idpay = 3;
                thisupdate(dayy.Text, timee.Text, idpay, mycls.idrasp);
            }
        }
    }
}
