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
    /// Логика взаимодействия для patienswindow.xaml
    /// </summary>
    public partial class patienswindow : Window
    {
        public patienswindow()
        {
            InitializeComponent();
            table();
        }

        public void table()
        {
            registrGANEntities connect = new registrGANEntities();
            gridtable.ItemsSource = connect.Patients.ToList();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            windowfolder.RegistrationWindow win = new RegistrationWindow();
            this.Hide();
            win.ShowDialog();
            this.Show();
            table();
        }

        private void gridtable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Patients pts = gridtable.SelectedItem as Patients;
            registrGANEntities connect = new registrGANEntities();
            if (pts != null)
            {
                mycls.id = connect.Patients.Where(w => w.FirstName == pts.FirstName && w.LastName == pts.LastName && w.MiddleName == pts.MiddleName && w.Adress == pts.Adress).Select(s => s.idPatiens).FirstOrDefault();
            } 
        }
        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            if(mycls.id != 0 || mycls.id != -1) 
            { 
                windowfolder.update upd = new update();
                this.Hide();
                upd.ShowDialog();
                this.Show();
                table();
            }
            else
            {
                MessageBox.Show("Больной не выбран");
                table();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (mycls.id != 0 || mycls.id != -1)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Удалить пациента?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    delete(mycls.id);
                    System.Windows.MessageBox.Show("пациент удален");
                    table();
                }
                else if (result == MessageBoxResult.No)
                {
                    System.Windows.MessageBox.Show("пациент не удален");
                    table();
                }
                else
                {

                }
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            registrGANEntities connect = new registrGANEntities();
            string first = firsname.Text;
            string last = lasname.Text;
            if(search(first, last) == true)
            {
                gridtable.ItemsSource = connect.Patients.Where(w => w.FirstName == first && w.LastName == last).ToList(); ;
            }
            else
            {
                MessageBox.Show("Больного не существует");
            }
        }

        public bool delete(int idd)
        {

            registrGANEntities connector = new registrGANEntities();
            if (idd != 0 || idd != -1)
            {
                var dlee = connector.Patients.Where(w => w.idPatiens == idd).ToList();
                if (dlee.Count != 0 && dlee.Any())
                {
                    var dlee1 = connector.Patients.Where(w => w.idPatiens == idd).FirstOrDefault();
                    connector.Patients.Remove(dlee1);
                    connector.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            else
            {
                return false;
            }
        }
        public bool search(string fname, string lname)
        {
            registrGANEntities connect = new registrGANEntities();
            var take = connect.Patients.Where(w => w.FirstName == fname && w.LastName == lname).ToList();
            if (take.Count() == 0 && !take.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
