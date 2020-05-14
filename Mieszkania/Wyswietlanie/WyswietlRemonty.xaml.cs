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
    /// Logika interakcji dla klasy WyswietlRemonty.xaml
    /// </summary>
    public partial class WyswietlRemonty : Window
    {
        public WyswietlRemonty()
        {
            InitializeComponent();
            var dba = new DostepPrac();
            var querry =
               from a in dba.Remonty
               select new {a.IdMieszkania,a.IdRemontu,a.Koszt_Remontu,a.Stan,a.Data_Rozpoczecia,a.Data_Zakonczenia};
            dataG.ItemsSource = querry.ToList();
        }
    }
}
