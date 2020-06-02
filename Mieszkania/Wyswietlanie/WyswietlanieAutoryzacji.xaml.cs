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
    /// Logika interakcji dla klasy WyswietlanieAutoryzacji.xaml
    /// </summary>
    public partial class WyswietlanieAutoryzacji : Window
    {
        public WyswietlanieAutoryzacji()
        {
            InitializeComponent();
            var dba = new DostepPrac();
            var querry =
               from a in dba.Autoryzacja
               select new { a.IdPracownika,a.Login,a.Haslo,a.Aktywne };
            dataG.ItemsSource = querry.ToList();
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
