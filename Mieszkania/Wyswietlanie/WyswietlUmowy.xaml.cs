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
    public partial class WyswietlUmowy : Window
    {
        public WyswietlUmowy()
        {
            InitializeComponent();
           var dba = new DostepPrac();
           var querry =
              from a in dba.Umowa
              select new {a.IdUmowy,a.Od_Kiedy,a.Do_Kiedy,a.Czynsz,a.Oplaty_Stale,a.IdMieszkania,a.IdLokatora};
           dataG.ItemsSource = querry.ToList();
        }
    }
}
