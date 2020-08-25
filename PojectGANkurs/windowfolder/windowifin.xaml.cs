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
    /// Логика взаимодействия для windowifin.xaml
    /// </summary>
    public partial class windowifin : Window
    {
        public windowifin()
        {
            InitializeComponent();
            rsad(mycls.into, mycls.idrasp);
        }

        public bool rsad(int iddocpoint, int idreg)
        {
            registrGANEntities con = new registrGANEntities();
            var abc = con.Doctorsappoin
                .Include(i => i.Registr)
                .Include(i => i.Registr.Patients)
                .Include(i => i.Registr.Rasp.Doctors)
                .Include(i => i.Medicament)
                .Include(i => i.Disease)
                .Where(w => w.iddoctorappoint ==iddocpoint  && w.idregistr == idreg)
                .ToList();

            if (abc.Count() == 0 && !abc.Any())
            {
                return false;
            }
            else
            {
                gridtable.ItemsSource = con.Doctorsappoin
                    .Include(i => i.Registr)
                    .Include(i => i.Registr.Patients)
                    .Include(i => i.Registr.Rasp.Doctors)
                    .Include(i => i.Medicament)
                    .Include(i => i.Disease)
                    .Where(w => w.iddoctorappoint == iddocpoint && w.idregistr == idreg)
                    .ToList();
                return true;
            }
        }
        private void btngo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
