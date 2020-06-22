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
    public partial class Kon_WyswietlRemonty : UserControl
    {
        public int id_w_r { get; set; }
        public Kon_WyswietlRemonty()
        {
            InitializeComponent();
            Wyswietl();
        }

        private void Wyswietl()
        {
            Walidacja w = new Walidacja();
            int idM;
            if (w.sprawdzId(txt_ID.Text)) idM=Convert.ToInt32(txt_ID.Text);
            else idM = 0;
            if (idM == 0)
            {
                var dba = new DostepPrac();
                var querry =
                   from a in dba.Remonty
                   select new { a.IdRemontu, a.IdMieszkania, a.Koszt_Remontu, a.Stan, a.Data_Rozpoczecia, a.Data_Zakonczenia };
                dataG.ItemsSource = querry.ToList();
            }
            else
            {
                var dba = new DostepPrac();
                var querry =
                   from a in dba.Remonty
                   where(a.IdMieszkania==idM)
                   select new { a.IdRemontu, a.IdMieszkania, a.Koszt_Remontu, a.Stan, a.Data_Rozpoczecia, a.Data_Zakonczenia };
                dataG.ItemsSource = querry.ToList();
            }
            
        }

        private void txt_ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            Wyswietl();
        }
    }
}
