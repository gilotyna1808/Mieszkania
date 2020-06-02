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
    /// Logika interakcji dla klasy UsunPracownika.xaml
    /// </summary>
    public partial class UkryjPracownika : UserControl
    {
        User uzytkownik;
        public UkryjPracownika(User u)
        {
            uzytkownik = u;
            InitializeComponent();
            var dba = new DostepPrac();
            var querry =
               from a in dba.Stanowiska
               select new { a.IdStanowiska, a.Nazwa_Stanowiska };

            dataG.ItemsSource = querry.ToList();
            Dictionary<bool, string> d = new Dictionary<bool, string>();
            d.Add(true, "Tak");
            d.Add(false, "Nie");
            cbox_zatrudniony.ItemsSource = d;
        }

        private void btn_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlPrac wp = new WyswietlPrac();
            wp.ShowDialog();
            int temp_id = 0;
            temp_id = wp.id_w_p;
            if (temp_id != 0)
            {
                txt_id.Text = Convert.ToString(temp_id);
                using (var com = new DostepPrac())
                {
                    var i = com.Pracownicy.Where(s => s.IdPracownika == temp_id);
                    txt_imiePrac.Text = Convert.ToString(i.Select(s => s.Imie).FirstOrDefault());
                    txt_nazPrac.Text = Convert.ToString(i.Select(s => s.Nazwisko).FirstOrDefault());
                    txt_Pesel.Text = Convert.ToString(i.Select(s => s.Pesel).FirstOrDefault());
                    txt_telPrac.Text = Convert.ToString(i.Select(s => s.NrTel).FirstOrDefault());
                    txt_miasto.Text = Convert.ToString(i.Select(s => s.Miasto_Zamieszkania).FirstOrDefault());
                    txt_adres.Text = Convert.ToString(i.Select(s => s.Adres_Zamieszkania).FirstOrDefault());
                    cbox_stanowisko.SelectedValue = Convert.ToInt32(i.Select(s => s.IdStanowisko).FirstOrDefault());
                    cbox_zatrudniony.SelectedValue = Convert.ToBoolean(i.Select(s => s.Zatrudniony).FirstOrDefault());
                }
            }

            Dictionary<int, string> stan = new Dictionary<int, string>();
            for (int i = 0; i < dataG.Items.Count; i++)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
                TextBlock id = dataG.Columns[0].GetCellContent(dr) as TextBlock;
                TextBlock nazwa = dataG.Columns[1].GetCellContent(dr) as TextBlock;
                stan.Add(Convert.ToInt32(id.Text), nazwa.Text);
            }
            cbox_stanowisko.ItemsSource = stan;
        }

        private void UkryjPrac(int temp_id)
        {
            using (DostepPrac dp = new DostepPrac())
            {
                var q = from data in dp.Pracownicy
                        orderby data.IdPracownika
                        select data;
                foreach (Pracownicy p in q)
                {
                    if (p.IdPracownika == temp_id)
                    {
                        p.Zatrudniony = false;
                    }
                }
                dp.SaveChanges();
            }
        }

        private void deaktywujKonto(int temp_id)
        {
            using (DostepPrac dp = new DostepPrac())
            {
                var q = from data in dp.Autoryzacja
                        orderby data.IdPracownika
                        select data;
                foreach (Autoryzacja p in q)
                {
                    if (p.IdPracownika == temp_id)
                    {
                        p.Aktywne = false;
                    }
                }
                dp.SaveChanges();
            }
        }

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            int temp_id = Convert.ToInt32(txt_id.Text);
            UkryjPrac(temp_id);
            deaktywujKonto(temp_id);
           
        }
    }
}