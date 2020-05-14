using Mieszkania.Wyswietlanie;
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

namespace Mieszkania
{
    /// <summary>
    /// Logika interakcji dla klasy DodajRemont.xaml
    /// </summary>
    public partial class DodajRemont : UserControl
    {
        public DodajRemont()
        {
            InitializeComponent();
        }

        private void btn_dodaj_r_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DostepPrac())
            {
                decimal koszt = Convert.ToDecimal(txt_Koszt.Text);//Do dodania walidacja
                System.DateTime dataP = Convert.ToDateTime(txt_data_p.Text); //Do dodania walidacja
                System.DateTime dataK = Convert.ToDateTime(txt_data_k.Text); //Do dodania walidacja
                int id_m = Convert.ToInt32(txt_id_m.Text);//Do dodania walidacja i wybieranie z listy
                var dodaj = new Remonty()
                {
                    Stan = txt_stan.Text,
                    Koszt_Remontu = koszt,
                    Data_Rozpoczecia=dataP,
                    Data_Zakonczenia=dataK,
                    IdMieszkania=id_m
                };
                db.Remonty.Add(dodaj);
                db.SaveChanges();
            }
        }

        private void btn_wybierz_mieszkanie_Click(object sender, RoutedEventArgs e)
        {
            WyswietlMieszkania wm = new WyswietlMieszkania();
            wm.ShowDialog();
            int temp_id = 0;
            temp_id = wm.id_w_m;
            if (temp_id != 0)
            {
                txt_id_m.Text = Convert.ToString(temp_id);
            }
        }
    }
}
