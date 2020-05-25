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

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy DodajPracownikow.xaml
    /// </summary>
    public partial class DodajPracownika : UserControl
    {
        private int temp = 0;
        public int id { get; set; }
        public DodajPracownika()
        {
            InitializeComponent();
        }
        public DodajPracownika(int x)
        {
            temp = x;
            InitializeComponent();
        }
        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            string imie = txt_imiePrac.Text;
            string naz = txt_nazPrac.Text;
            string nrTelPrac = txt_telPrac.Text;

            using (var v = new DostepPrac())
            {
                var p = new Pracownicy()
                {
                    Imie = imie,
                    Nazwisko = naz,
                    NrTel = nrTelPrac
                };
                v.Pracownicy.Add(p);
                v.SaveChanges();
            }
            if(temp == 1)
            {
                var v = new DostepPrac();
                var q = from a in v.Pracownicy
                        where (a.Imie == imie && a.Nazwisko == naz && a.NrTel == nrTelPrac)
                        select new { a.IdPracownika };
                if(q.Count()==1)
                {
                    id = ((Convert.ToInt32(q.ToList().Last().IdPracownika)));
                }
            }
        }
    }
}
