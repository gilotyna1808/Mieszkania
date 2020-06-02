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
    /// Logika interakcji dla klasy WyswietlLokator.xaml
    /// </summary>
    public partial class Kon_WyswietlLokator : UserControl
    {
        User uzytkownik;
        public int id_w_l { get; set; }
        public Kon_WyswietlLokator(User u)
        {
            uzytkownik = u;
            InitializeComponent();
            id_w_l = 0;
            var dba = new DostepPrac();
            if (u.getIdStanowiska() == 1)
            {
                var querry =
                               from a in dba.Lokator
                               select new { a.IdLokatora, a.Imie, a.Nazwisko, a.Pesel, a.Nr_Telefonu, a.Adres_Mailowy, a.Adres_Korespondecyjny, a.Mieszka };
                dataG.ItemsSource = querry.ToList();
            }
            else
            {
                var querry =
               from a in dba.Lokator
               where (a.Mieszka == true)
               select new { a.IdLokatora, a.Imie, a.Nazwisko, a.Pesel, a.Nr_Telefonu, a.Adres_Mailowy, a.Adres_Korespondecyjny };
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
                id_w_l = Convert.ToInt32(cell.Text);
            }
        }
    }
}
