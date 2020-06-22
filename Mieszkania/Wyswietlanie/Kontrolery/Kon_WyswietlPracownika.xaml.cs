using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace Mieszkania.Wyswietlanie
{
    /// <summary>
    /// Logika interakcji dla klasy WyswietlPracownika.xaml
    /// </summary>
    public partial class Kon_WyswietlPracownika : UserControl
    {
        public int id_w_p { get; set; }
        public Kon_WyswietlPracownika()
        {
            InitializeComponent();
            id_w_p = 0;
            Wyswietl();

        }

        public void Wyswietl()
        {
            string naz, imi, pes;
            naz = txt_Naz.Text;
            imi = txt_imi.Text;
            pes = txt_pes.Text;
            var dba = new DostepPrac();
            var querry =
               from a in dba.Pracownicy
               where (a.Nazwisko.StartsWith(naz) && a.Imie.StartsWith(imi) && a.Pesel.StartsWith(pes))
               select new { a.IdPracownika, a.Imie, a.Nazwisko, a.NrTel,a.Pesel,a.Miasto_Zamieszkania,a.Stanowiska.Nazwa_Stanowiska };
            dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count == 1)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(dataG.SelectedIndex) as DataGridRow;
                DataGridColumn dc = dataG.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                id_w_p = Convert.ToInt32(cell.Text);       
            }
        }

        private void txt_Naz_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }

        private void txt_imi_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }

        private void txt_pes_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }
    }
}
