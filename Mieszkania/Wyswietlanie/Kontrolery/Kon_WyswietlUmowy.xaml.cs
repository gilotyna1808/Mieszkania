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
    /// Logika interakcji dla klasy WyswietlUmowy.xaml
    /// </summary>
    public partial class Kon_WyswietlUmowy : UserControl
    {
        public int id_w_u { get; set; }
        public Kon_WyswietlUmowy()
        {
            InitializeComponent();
            Wysietl();
        }
        
        private void Wysietl()
        {
            string imie = txt_imi.Text;
            string naz = txt_Naz.Text;

            var dba = new DostepPrac();
            var querry =
               from a in dba.Umowa
               where (a.Lokator.Nazwisko.StartsWith(naz) && a.Lokator.Imie.StartsWith(imie))
               select new { a.IdUmowy, a.Od_Kiedy, a.Do_Kiedy, a.Stawka_Czynsz, a.Oplaty_Stale, a.IdMieszkania, a.IdLokatora, a.Lokator.Imie, a.Lokator.Nazwisko };
            dataG.ItemsSource = querry.ToList();
        }

        private void txt_imi_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wysietl();
        }

        private void txt_Naz_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wysietl();
        }
    }
}
