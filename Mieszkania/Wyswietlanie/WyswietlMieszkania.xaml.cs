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
    /// Logika interakcji dla klasy WyswietlMieszkania.xaml
    /// </summary>
    public partial class WyswietlMieszkania : Window
    {
        public int id_w_m { get; set; }
        User uzytkownik;
        public WyswietlMieszkania(User u)
        {
            InitializeComponent();
            id_w_m = 0;
            uzytkownik = u;
            Wyswietl();
        }

        private void Wyswietl()
        {
            string miasto = txt_M.Text;
            string ul = txt_ul.Text;
            string kod = txt_kod.Text;
            if (uzytkownik.getIdStanowiska() == 1)
            {
                var dba = new DostepPrac();
                var querry =
                   from a in dba.Mieszkanie
                   where (a.Miasto.StartsWith(miasto) && a.Kod_Pocztowy.StartsWith(kod) && a.Ulica.StartsWith(ul))
                   select new { a.IdMieszkania, a.Kod_Pocztowy, a.Miasto, a.Nr_Mieszkania, a.Nr_Domu, a.Status_Mieszkania, a.Ulica, a.Posiadane };
                dataG.ItemsSource = querry.ToList();
            }
            else
            {
                var dba = new DostepPrac();
                var querry =
                   from a in dba.Mieszkanie
                   join a2 in dba.Pracownicy_Odp on a.IdMieszkania equals a2.IdMieszkania
                   where (a2.IdPracownika == uzytkownik.getIdPrac() && a.Posiadane == true && a.Miasto.StartsWith(miasto) && a.Kod_Pocztowy.StartsWith(kod) && a.Ulica.StartsWith(ul))
                   select new { a.IdMieszkania, a.Kod_Pocztowy, a.Miasto, a.Nr_Mieszkania, a.Nr_Domu, a.Status_Mieszkania, a.Ulica };
                dataG.ItemsSource = querry.ToList();
            }
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count == 1)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(dataG.SelectedIndex) as DataGridRow;
                DataGridColumn dc = dataG.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                id_w_m = Convert.ToInt32(cell.Text);
            }
            this.Close();
        }

        private void txt_ul_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }

        private void txt_kod_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }

        private void txt_M_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }
    }
}
