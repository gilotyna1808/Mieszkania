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
        User uzytkownik;
        public DodajUmowe(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Walidacja w = new Walidacja();
            bool walidacjaCzynsz, walidacjaOplaty, walidacjaDataP, walidacjaDataK, walidacjaIdM, walidacjaIdL;
            string czynsz_s, oplaty_s, dataP_s, dataK_s, idM_s, idL_s;
            czynsz_s = txt_czynsz.Text;
            oplaty_s = txt_oplaty.Text;
            dataP_s = txt_data_p.Text;
            dataK_s = txt_data_k.Text;
            idL_s = txt_id_l.Text;
            idM_s = txt_id_m.Text;
            walidacjaCzynsz = w.sprawdzCzynsz(czynsz_s);
            walidacjaOplaty = w.sprawdzOplaty(oplaty_s);
            walidacjaDataP = w.sprawdzDate(dataP_s);
            walidacjaDataK = w.sprawdzDate(dataK_s);
            walidacjaIdL = w.sprawdzId(idL_s);
            walidacjaIdM = w.sprawdzId(idM_s);
            if (walidacjaCzynsz && walidacjaOplaty && walidacjaDataP && walidacjaDataK && walidacjaIdM && walidacjaIdL) {
                decimal czynsz = Convert.ToDecimal(czynsz_s);
                decimal oplaty = Convert.ToDecimal(oplaty_s);
                System.DateTime dataP = Convert.ToDateTime(dataP_s);
                System.DateTime dataK = Convert.ToDateTime(dataK_s);
                int id_m = Convert.ToInt32(idM_s);
                int id_l = Convert.ToInt32(idL_s);
                using (var db = new DostepPrac())
                {
                    var dodaj = new Umowa()
                    {
                        Od_Kiedy = dataP,
                        Do_Kiedy = dataK,
                        Stawka_Czynsz = czynsz,
                        Oplaty_Stale = oplaty,
                        IdMieszkania = id_m,
                        IdLokatora = id_l

                    };
                    db.Umowa.Add(dodaj);
                    var flagaPowDod = db.SaveChanges();
                    if (flagaPowDod == 1)
                    {
                        MessageBox.Show("Dodawanie zakonczone pomyślnie");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nie spelniono wymagan");
            } 
        }

        private void btn_lista_m_Click(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania wyswietlMieszkania = new WyswietlMieszkania(uzytkownik);
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
            WyswietlLokator wyswietlLokator = new WyswietlLokator(uzytkownik);
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

        private void txt_czynsz_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzCzynsz(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }

        private void txt_oplaty_TextChanged(object sender, TextChangedEventArgs e)
        {
            Walidacja w = new Walidacja();
            TextBox x = (TextBox)sender;
            if (w.sprawdzOplaty(x.Text))
            {
                x.Background = Brushes.White;
            }
            else
            {
                x.Background = Brushes.Red;
            }
        }
    }
}
