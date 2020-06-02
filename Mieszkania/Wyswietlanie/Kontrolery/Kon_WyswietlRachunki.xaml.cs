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
    public partial class Kon_WyswietlRachunki : UserControl
    {
        public int id_w_r { get; set; }
        public Kon_WyswietlRachunki(User u)
        {
            int id = u.getIdPrac();
            InitializeComponent();
            id_w_r = 0;
            if (u.getIdStanowiska() == 1)
            {
                var dba = new DostepPrac();
                var querry =
                   from a in dba.Czynsz_Wplywy
                   select new {a.IdCzynszu,a.IdUmowy,a.Kwota,a.Termin_Rozliczenia,a.Zaplacone,a.Umowa.Lokator.Nazwisko,a.Umowa.Lokator.Imie};
                dataG.ItemsSource = querry.ToList();
            }
            else
            {
                var dba = new DostepPrac();
                var querry =
                   from a in dba.Mieszkanie
                   join a2 in dba.Pracownicy_Odp on a.IdMieszkania equals a2.IdMieszkania
                   where (a2.IdPracownika == id && a.Posiadane == true)
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
                id_w_r = Convert.ToInt32(cell.Text);
            }
        }
    }
}
