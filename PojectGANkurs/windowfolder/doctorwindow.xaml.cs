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
    /// Логика взаимодействия для doctorwindow.xaml
    /// </summary>
    public partial class doctorwindow : Window
    {
        public static int ids2;
        public doctorwindow()
        {
            InitializeComponent();
            load();
        }

        public void load()
        {
            registrGANEntities con = new registrGANEntities();
            gridtable.ItemsSource = con.Doctors.ToList();
        }

        public bool loadsearch(string role)
        {
            registrGANEntities con = new registrGANEntities();
            
            var doc = con.Doctors.Where(w=>w.Role == role).ToList();
            if(!doc.Any() && doc.Count == 0)
            {
                return false;
            }
            else
            {
                gridtable.ItemsSource = con.Doctors.Where(w => w.Role == role).ToList(); 
                return true;
            }
        }
        private void btnsddas_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gridtable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Doctors pts = gridtable.SelectedItem as Doctors;
            registrGANEntities connect = new registrGANEntities();
            if (pts != null)
            {
               firsname.Text = pts.FirstName;
                lasname.Text = pts.LastName;
                weeklist.Text = pts.Role;
                adress.Text = pts.Adress;
                email.Text = pts.Email;
                phone.Text = pts.Phone;
                ids2 = connect.Doctors.Where(w => w.FirstName == firsname.Text && w.LastName == lasname.Text && w.Role == weeklist.Text).Select(s => s.iddoctors).FirstOrDefault();
              }
            else
            {
                return;
            }
        }

        private void btndrpc_Click(object sender, RoutedEventArgs e)
        {
            if(weeklist.Text == "")
            {
                MessageBox.Show("Нужно выбрать должность");
            }
            else
            {
                loadsearch(weeklist.Text);
            }
        }
        public bool tthisupdate(string fname, string lname, string role, string phon, string emaill, string adresss, int idd)
        {
            registrGANEntities connect = new registrGANEntities();
            var check = connect.Doctors.Where(w => w.iddoctors == idd).ToList();
            if (idd == -1 || idd == 0 || !check.Any() || check.Count == 0)
            {
                return false;
            }
            else
            {
                var thisupdate = connect.Doctors.Where(w => w.iddoctors == idd).FirstOrDefault();
                thisupdate.FirstName = fname;
                thisupdate.LastName = lname;
                thisupdate.Role = role;
                thisupdate.Phone = phon;
                thisupdate.Email = emaill;
                thisupdate.Adress = adresss;
                connect.SaveChanges();
                return true;
            }
        }

        private void btnsdrpc_Click(object sender, RoutedEventArgs e)
        {
            if (firsname.Text == "" || lasname.Text == "" || weeklist.Text == "" || phone.Text == "" || email.Text == "" || adress.Text == "" )
            {
                MessageBox.Show("Не выбран доктора для изменения");
            }
            else 
            {
                tthisupdate(firsname.Text, lasname.Text, weeklist.Text, phone.Text, email.Text, adress.Text, ids2);
                load();
            }
        }
    }
}
