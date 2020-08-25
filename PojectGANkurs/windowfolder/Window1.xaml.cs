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
using System.Windows.Shapes;

namespace PojectGANkurs.windowfolder
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnbck_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btngo_Click(object sender, RoutedEventArgs e)
        {
            if (patientsfname.Text == "" && patientslname.Text == "" && docfname.Text == "" && doclname.Text == "" && dayy.Text == "" && docrole.Text == "")
            {
                MessageBox.Show("Введите данные для поиска");
            }
            else if(patientsfname.Text == "")
            {
                MessageBox.Show("Введите имя пациента");
            }
            else if (patientslname.Text == "")
            {
                MessageBox.Show("Введите фамилию пациента");
            }
            else if (docfname.Text == "")
            {
                MessageBox.Show("Введите имя доктора");
            }
            else if (doclname.Text == "")
            {
                MessageBox.Show("Введите Фамилию доктора");
            }
            else if (dayy.Text == "")
            {
                MessageBox.Show("Введите дату приема");
            }
            else if (docrole.Text == "")
            {
                MessageBox.Show("Введите должность врача");
            }
            else
            {
                selectid(patientsfname.Text, patientslname.Text, docfname.Text, doclname.Text, docrole.Text, dayy.Text);
            }

        }

        public bool selectid(string patfname, string patlname, string docffname, string doclname, string docrol, string dayo)
        {
            registrGANEntities connect = new registrGANEntities();
            mycls.idrasp = connect.Registr
                .Include(i => i.Patients)
                .Include(ii => ii.Rasp.Doctors)
                .Where(w => w.Patients.LastName == patlname && w.Patients.FirstName == patfname && w.Rasp.Doctors.FirstName == docffname && w.Rasp.Doctors.LastName == doclname && w.date == dayo && w.Rasp.Doctors.Role == docrol)
                .Select(s => s.idRegistr)
                .FirstOrDefault();
            if(mycls.idrasp != 0 || mycls.idrasp != -1)
            {
                windowfolder.Window2 won = new Window2();
                this.Hide();
                won.ShowDialog();
                this.Close();
                return true;
            }
            else
            {
                MessageBox.Show("" + mycls.idrasp);
                return false;
            }
            
        }
    }
}
