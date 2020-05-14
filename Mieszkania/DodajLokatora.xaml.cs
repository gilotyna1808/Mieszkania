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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mieszkania.Dodawanie
{
    /// <summary>
    /// Logika interakcji dla klasy DodajLokatora.xaml
    /// </summary>
    public partial class DodajLokatora : UserControl
    {
        private int temp = 0;
        public int id { get; set; }
        public DodajLokatora()
        {
            InitializeComponent();
        }

        public DodajLokatora(int x)
        {
            temp = x;
            InitializeComponent();
        }

        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            string imie = txt_imi.Text;
            string nazwisko = txt_naz.Text;
            string nrTel = txt_tel.Text;
            using (var db = new DostepPrac())
            {
                var m = new Lokator()
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    NrTelefonu = nrTel
                };
                db.Lokator.Add(m);
                db.SaveChanges();
            }
            if (temp == 1)
            {
                var db = new DostepPrac();
                var querry =
                from a in db.Lokator
                where (a.Imie==imie && a.Nazwisko ==nazwisko && a.NrTelefonu==nrTel)
                select new {a.IdLokatora};
                if (querry.Count() == 1)
                {
                    id = ((Convert.ToInt32(querry.ToList().Last().IdLokatora)));
                }
            }
        }
    }
}
