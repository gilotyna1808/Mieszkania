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

namespace Mieszkania.Wyswietlanie
{
    /// <summary>
    /// Logika interakcji dla klasy WyswietlRachunki.xaml
    /// </summary>
    public partial class WyswietlRachunki : Window
    {
        public int id_w_r { get; set; }
        User uzytkownik;
        public WyswietlRachunki(User u)
        {
            uzytkownik = u;
            InitializeComponent();
            id_w_r = 0;
            Wyswietl();
        }

        private void Wyswietl()
        {
            Walidacja w = new Walidacja();
            string naz = txt_Naz.Text;
            string imi = txt_imi.Text;
            int id, idprac = uzytkownik.getIdPrac();
            if (w.sprawdzId(txt_ID.Text)) id = Convert.ToInt32(txt_ID.Text);
            else id = 0;
            if (id == 0)
            {
                if (uzytkownik.getIdStanowiska() == 1)
                {
                    var dba = new DostepPrac();
                    var querry =
                       from a in dba.Czynsz_Wplywy
                       where (a.Umowa.Lokator.Nazwisko.StartsWith(naz) && a.Umowa.Lokator.Imie.StartsWith(imi))
                       select new { a.IdCzynszu, a.IdUmowy, a.Kwota, a.Termin_Rozliczenia, a.Zaplacone, a.Umowa.Lokator.Nazwisko, a.Umowa.Lokator.Imie };
                    dataG.ItemsSource = querry.ToList();
                }
                else
                {
                    var dba = new DostepPrac();
                    var querry =
                       from a in dba.Czynsz_Wplywy
                       join a2 in dba.Pracownicy_Odp on a.Umowa.Mieszkanie.IdMieszkania equals a2.IdMieszkania
                       where (a2.IdPracownika == idprac && a.Umowa.Lokator.Nazwisko.StartsWith(naz) && a.Umowa.Lokator.Imie.StartsWith(imi))
                       select new { a.IdCzynszu, a.IdUmowy, a.Kwota, a.Termin_Rozliczenia, a.Zaplacone, a.Umowa.Lokator.Nazwisko, a.Umowa.Lokator.Imie };
                    dataG.ItemsSource = querry.ToList();
                }
            }
            else
            {
                if (uzytkownik.getIdStanowiska() == 1)
                {
                    var dba = new DostepPrac();
                    var querry =
                       from a in dba.Czynsz_Wplywy
                       where (a.Umowa.Lokator.Nazwisko.StartsWith(naz) && a.Umowa.Lokator.Imie.StartsWith(imi) && a.IdUmowy == id)
                       select new { a.IdCzynszu, a.IdUmowy, a.Kwota, a.Termin_Rozliczenia, a.Zaplacone, a.Umowa.Lokator.Nazwisko, a.Umowa.Lokator.Imie };
                    dataG.ItemsSource = querry.ToList();
                }
                else
                {
                    var dba = new DostepPrac();
                    var querry =
                       from a in dba.Czynsz_Wplywy
                       join a2 in dba.Pracownicy_Odp on a.Umowa.Mieszkanie.IdMieszkania equals a2.IdMieszkania
                       where (a2.IdPracownika == idprac && a.Umowa.Lokator.Nazwisko.StartsWith(naz) && a.Umowa.Lokator.Imie.StartsWith(imi) && a.IdUmowy == id)
                       select new { a.IdCzynszu, a.IdUmowy, a.Kwota, a.Termin_Rozliczenia, a.Zaplacone, a.Umowa.Lokator.Nazwisko, a.Umowa.Lokator.Imie };
                    dataG.ItemsSource = querry.ToList();
                }
            }

        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count == 1)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(dataG.SelectedIndex) as DataGridRow;
                DataGridColumn dc = dataG.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                id_w_r = Convert.ToInt32(cell.Text);
            }
            this.Close();
        }

        private void txt_Naz_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }

        private void txt_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }

        private void txt_imi_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }

    }
}
