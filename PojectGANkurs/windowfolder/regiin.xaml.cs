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
    /// Логика взаимодействия для regiin.xaml
    /// </summary>
    public partial class regiin : Window
    {
        public regiin()
        {
            InitializeComponent();
        }

        private void regisdown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void regisup_Click(object sender, RoutedEventArgs e)
        {
            int idpay;
            if (patientsfname.Text == "" && patientslname.Text == "" && adress.Text == "" && time.Text == ""  && typepayer.Text == "" && mycls.iddoct == -1 && mycls.iddoct == 0)
            {
                MessageBox.Show("Данные не введены");
            }
            else if (mycls.iddoct == -1 && mycls.iddoct == 0)
            {
                MessageBox.Show("Врач не выбран");
            }
            else if (patientsfname.Text == "")
            {
                MessageBox.Show("Не написано имя пациента");
            }
            else if (patientslname.Text == "")
            {
                MessageBox.Show("Не написано фамилия пациента");
            }
            else if (time.Text == "")
            {
                MessageBox.Show("Не указано время посещения");
            }
            else if (typepayer.Text == "")
            {
                MessageBox.Show("Не выбран тип оплаты");
            }
            else if (adress.Text == "")
            {
                MessageBox.Show("Не введен адресс");
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Записать пациента?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (typepayer.Text == "ОМС")
                    {
                        string day = mycls.daywer;
                        int ras = mycls.idrasp;
                        int useridd = mycls.userid;
                        idpay = 1;
                        if (regup(patientsfname.Text, patientslname.Text, time.Text, adress.Text, day, idpay, ras, useridd) == true)
                        {
                            this.Close();
                        }
                    }
                    else if (typepayer.Text == "Личные средства")
                    {
                        string day = mycls.daywer;
                        int ras = mycls.idrasp;
                        int useridd = mycls.userid;
                        idpay = 2;
                        if (regup(patientsfname.Text, patientslname.Text, time.Text, adress.Text, day, idpay, ras, useridd) == true)
                        {
                            this.Close();
                        }
                    }
                    else if(typepayer.Text == "Страховой случай")
                    {
                        string day = mycls.daywer;
                        int ras = mycls.idrasp;
                        int useridd = mycls.userid;
                        idpay = 3;
                        if (regup(patientsfname.Text, patientslname.Text, time.Text, adress.Text, day, idpay, ras, useridd) == true)
                        {
                            this.Close();
                            MessageBox.Show("запись оформленна");
                        }
                        else
                        {
                            MessageBox.Show("Введеные данные не верны");
                        }
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    patientsfname.Text = "";
                    patientslname.Text = "";
                    adress.Text = "";
                    time.Text = "";
                }
                else
                {

                }
            }
        }

        public bool regup(string fname, string lname, string timme, string adres, string dayof, int typepay, int rasp, int ddd)
        {
            
                registrGANEntities connect = new registrGANEntities();
                int idp = connect.Patients.Where(w => w.FirstName == fname && w.LastName == lname && w.Adress == adres).Select(s => s.idPatiens).FirstOrDefault();
                if (idp != 0 && idp != -1 && rasp != 0 && rasp != -1)
                {
                    Registr reg = new Registr()
                    {
                        date = dayof,
                        idrasp = rasp,
                        idPatient = idp,
                        time = timme,
                        idTypepay = typepay,
                        iduserRegistr = ddd
                    };
                    connect.Registr.Add(reg);
                    connect.SaveChanges();
                    return true;
                }
                else
                {

                MessageBox.Show(" " + dayof + " " + rasp + " " + ddd);
                return false;
                }
           
        }
    }
}
