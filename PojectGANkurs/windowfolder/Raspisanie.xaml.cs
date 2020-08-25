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
    /// Логика взаимодействия для Raspisanie.xaml
    /// </summary>
    public partial class Raspisanie : Window
    {
        public Raspisanie()
        {
            InitializeComponent();
            bck();
        }

        public void bck()
        {
            registrGANEntities connect = new registrGANEntities();
            gridtable.ItemsSource = connect.Rasp.Include(i => i.Doctors).Include(ii => ii.Doctors.cabin).ToList();
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            registrGANEntities connect = new registrGANEntities();
            string dayforsearch = weeklist.Text;
            string finame = firsname.Text;
            string laname = lasname.Text;
            if(dayforsearch == "" && finame == "" && laname == "")
            {
                MessageBox.Show("Не введены критерии поиска");
            }
            else if(dayforsearch == "")
            {
                MessageBoxResult result = MessageBox.Show("Упорядочить по данным доктора?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if(takedoc(finame, laname)== true)
                    {
                        gridtable.ItemsSource = connect.Rasp.Include(i => i.Doctors).Include(ii => ii.Doctors.cabin).Where(w => w.Doctors.FirstName == finame && w.Doctors.LastName == laname).ToList();

                    }
                    else
                    {
                        MessageBox.Show("В данный день нет приемов");
                    }
                }
                else
                {

                }
            }
            else if (finame == "" && laname == "")
            {
                MessageBoxResult result = MessageBox.Show("Упорядочить по дню недели?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if(takeday(dayforsearch) == true)
                    {

                        gridtable.ItemsSource = connect.Rasp.Include(i => i.Doctors).Include(ii => ii.Doctors.cabin).Where(w => w.weekday == dayforsearch).ToList();
                    }
                    else
                    {
                        MessageBox.Show("В данный день нет приемов");
                    }
                }
                else
                {

                }
            }
            else
            {
                if(takeall(dayforsearch, finame, laname)==true)
                {
                    gridtable.ItemsSource = connect.Rasp.Include(i => i.Doctors).Include(ii => ii.Doctors.cabin).Where(w => w.weekday == dayforsearch && w.Doctors.FirstName == finame && w.Doctors.LastName == laname).ToList();

                }
                else
                {
                    MessageBox.Show("В данный день нет приемов");
                }
            }
        }

        public bool takeday(string day)
        {
            registrGANEntities connect = new registrGANEntities();
            var take = connect.Rasp.Include(i => i.Doctors).Include(ii => ii.Doctors.cabin).Where(w => w.weekday == day).ToList();
            if (take.Count() == 0 && !take.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool takedoc(string fname, string lname)
        {
            registrGANEntities connect = new registrGANEntities();
            var take = connect.Rasp.Include(i => i.Doctors).Include(ii => ii.Doctors.cabin).Where(w => w.Doctors.FirstName == fname && w.Doctors.LastName == lname).ToList();
            if (take.Count() == 0 && !take.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool takeall(string day, string fname, string lname)
        {
            registrGANEntities connect = new registrGANEntities();
            var take = connect.Rasp.Include(i => i.Doctors).Include(ii => ii.Doctors.cabin).Where(w => w.weekday == day && w.Doctors.FirstName == fname && w.Doctors.LastName == lname).ToList();
            if (take.Count() == 0 && !take.Any())
            {
                return false;
            }
            else
            {
                return true;
            }

            /**/
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            windowfolder.patienswindow page = new patienswindow();
            this.Hide();
            page.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            bck();
        }

        private void gridtable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Rasp pts = gridtable.SelectedItem as Rasp;
            registrGANEntities connect = new registrGANEntities();
            if (pts != null)
            {
                mycls.iddoct = connect.Rasp
                    .Include(x => x.Doctors)
                    .Where(w => w.Doctors.LastName == pts.Doctors.LastName && w.Doctors.FirstName == pts.Doctors.FirstName && w.Doctors.Role == pts.Doctors.Role)
                    .Select(s => s.Doctors.iddoctors)
                    .FirstOrDefault();
                mycls.idrasp = connect.Rasp.Where(w => w.Doctors.iddoctors == mycls.iddoct && w.weekday == pts.weekday && w.day == pts.day).Select(s=>s.idrasp).FirstOrDefault();
             
                mycls.weekdy = pts.weekday;
                mycls.daywer = pts.day;

            }
        }
        private void btndrpc_Click(object sender, RoutedEventArgs e)
        {
            if(mycls.weekdy == "" || mycls.daywer == "" || mycls.iddoct == 0 || mycls.iddoct ==-1)
            {
                MessageBox.Show("Не выбран прием");
            }
            else
            {
                regiin page = new regiin();
                this.Hide();
                page.ShowDialog();
                this.Show();
            }
        }

        private void btnsdrpc_Click(object sender, RoutedEventArgs e)
        {
            windowfolder.Window1 win1 = new Window1();
            this.Hide();
            win1.ShowDialog();
            this.Show();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            windowfolder.doctorwindow docw = new doctorwindow();
            this.Hide();
            docw.ShowDialog();

            this.Show();
        }

        private void btnsddas_Click(object sender, RoutedEventArgs e)
        {
            windowfolder.windowinpri page = new windowinpri();
            this.Hide();
            page.ShowDialog();
            this.Show();
        }
    }
}
