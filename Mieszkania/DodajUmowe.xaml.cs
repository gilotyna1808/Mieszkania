using Mieszkania.Wyswietlanie;
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

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy DodajUmowe.xaml
    /// </summary>
    public partial class DodajUmowe : UserControl
    {
        public DodajUmowe()
        {
            InitializeComponent();
        }

        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            decimal czynsz = Convert.ToDecimal(txt_czynsz.Text);//Do dodania walidacja
            decimal oplaty = Convert.ToDecimal(txt_oplaty.Text);//Do dodania walidacja
            System.DateTime dataP = Convert.ToDateTime(txt_data_p.Text); //Do dodania walidacja
            System.DateTime dataK = Convert.ToDateTime(txt_data_k.Text); //Do dodania walidacja
            System.DateTime dataRozl = Convert.ToDateTime(txt_data_rozl.Text); //Do dodania walidacja
            int id_m = Convert.ToInt32(txt_id_m.Text);//Do dodania walidacja i wybieranie z listy
            int id_l = Convert.ToInt32(txt_id_l.Text);//Do dodania walidacja i wybieranie z listy
            using (var db = new DostepPrac())
            {
                var dodaj = new Umowa()
                {
                    Od_Kiedy = dataP,
                    Do_Kiedy = dataK,
                    Czynsz = czynsz,
                    Oplaty_Stale = oplaty,
                    Termin_Rozliczenia = dataRozl,
                    IdMieszkania = id_m,
                    IdLokatora = id_l

                };
                db.Umowa.Add(dodaj);
                db.SaveChanges();
            }
        }

        private void btn_lista_m_Click(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania wyswietlMieszkania = new WyswietlMieszkania();
            wyswietlMieszkania.ShowDialog();
            int temp_id = 0;
            temp_id = wyswietlMieszkania.id_w_m;
            if (temp_id != 0)
            {
                txt_id_m.Text = Convert.ToString(temp_id);
            }
        }

        private void btn_lisa_l_Click(object sender, RoutedEventArgs e)
        {
            WyswietlLokator wyswietlLokator = new WyswietlLokator();
            wyswietlLokator.ShowDialog();
            int temp_id = 0;
            temp_id = wyswietlLokator.id_w_l;
            if (temp_id != 0)
            {
                txt_id_l.Text = Convert.ToString(temp_id);
            }
        }

        private void btn_dodaj_l_Click(object sender, RoutedEventArgs e)
        {
            empty emp = new empty("lokator");
            emp.ShowDialog();
        }
    }
}
