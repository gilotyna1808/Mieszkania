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

namespace Mieszkania.Dodawanie
{
    /// <summary>
    /// Logika interakcji dla klasy DodajPracownikowOdp.xaml
    /// </summary>
    public partial class DodajPracownikowOdp : UserControl
    {
        private int id = 0;
        public DodajPracownikowOdp()
        {
            InitializeComponent();
        }

        private void strukuraDataGDost()
        {
            DataGridTextColumn textColumn0 = new DataGridTextColumn();
            textColumn0.Header = "Id Mieszkania";
            textColumn0.Binding = new Binding("IdMieszkania");
            dataG_dost.Columns.Add(textColumn0);
            DataGridTextColumn textColumn1 = new DataGridTextColumn();
            textColumn1.Header = "Miasto";
            textColumn1.Binding = new Binding("Miasto");
            dataG_dost.Columns.Add(textColumn1);
            DataGridTextColumn textColumn2 = new DataGridTextColumn();
            textColumn2.Header = "Ulica";
            textColumn2.Binding = new Binding("Ulica");
            dataG_dost.Columns.Add(textColumn2);
            DataGridTextColumn textColumn3 = new DataGridTextColumn();
            textColumn3.Header = "Nr Domu";
            textColumn3.Binding = new Binding("Nr_Domu");
            dataG_dost.Columns.Add(textColumn3);
            DataGridTextColumn textColumn4 = new DataGridTextColumn();
            textColumn4.Header = "Nr Mieszkania";
            textColumn4.Binding = new Binding("Nr_Mieszkania");
            dataG_dost.Columns.Add(textColumn4);

        }

        private void btn_wybierz_Click(object sender, RoutedEventArgs e)
        {
            WyswietlPrac wp = new WyswietlPrac();
            wp.ShowDialog();
            id = wp.id_w_p;
            if (id != 0)
            {
                lbl_id.Content = Convert.ToString(id);
                zaladujDataGOdp();
                zaladujDataGDost();
            }
        }

        private void zaladujDataGOdp()
        {
            using (var com = new DostepPrac())
            {
                var i = com.Pracownicy.Where(s => s.IdPracownika == id);
                lbl_imie.Content = Convert.ToString(i.Select(s => s.Imie).FirstOrDefault());
                lbl_nazw.Content = Convert.ToString(i.Select(s => s.Nazwisko).FirstOrDefault());

                var querry =
                   from a in com.Mieszkanie
                   join a2 in com.Pracownicy_Odp on a.IdMieszkania equals a2.IdMieszkania
                   where (a2.IdPracownika == id && a.Posiadane == true)
                   select new { a.IdMieszkania, a.Miasto, a.Ulica, a.Nr_Domu, a.Nr_Mieszkania };
                dataG_Odp.ItemsSource = querry.ToList();
            }
        }

        private void zaladujDataGDost()
        {
            dataG_dost.Items.Clear();
            dataG_dost.Items.Refresh();
            using (var com = new DostepPrac())
            {
                var querry2 =
                     from a in com.Mieszkanie
                     join a2 in com.Pracownicy_Odp on a.IdMieszkania equals a2.IdMieszkania
                     where (a2.IdPracownika == id && a.Posiadane == true)
                     select new { a.IdMieszkania };

                var querry3 =
                   from a in com.Mieszkanie
                   where (a.IdMieszkania != 1)
                   select new { a.IdMieszkania, a.Miasto, a.Ulica, a.Nr_Domu, a.Nr_Mieszkania };

                strukuraDataGDost();

                foreach (var b in querry3)
                {
                    bool flag1 = true;
                    foreach (var c in querry2)
                    {
                        if (b.IdMieszkania == c.IdMieszkania) flag1 = false;
                    }
                    if (flag1) dataG_dost.Items.Add(b);
                }
            }
        }

        private void btn_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataG_dost.SelectedItems.Count; i++)
            {
                DataGridRow dr = dataG_dost.ItemContainerGenerator.ContainerFromItem(dataG_dost.SelectedItems[i]) as DataGridRow;
                DataGridColumn dc = dataG_dost.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                int temp_id = Convert.ToInt32(cell.Text);
                using (var v = new DostepPrac())
                {
                    var p = new Pracownicy_Odp()
                    {
                        IdPracownika = id,
                        IdMieszkania = temp_id
                    };
                    v.Pracownicy_Odp.Add(p);
                    v.SaveChanges();
                }
            }
            zaladujDataGDost();
            zaladujDataGOdp();
        }

        private void btn_Usun_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dataG_Odp.SelectedItems.Count; i++)
            {
                DataGridRow dr = dataG_Odp.ItemContainerGenerator.ContainerFromItem(dataG_Odp.SelectedItems[i]) as DataGridRow;
                DataGridColumn dc = dataG_Odp.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                int temp_id = Convert.ToInt32(cell.Text);
                using (var v = new DostepPrac())
                {
                    var q = from data in v.Pracownicy_Odp
                            orderby data.IdMieszkania
                            select data;
                    foreach (Pracownicy_Odp m in q)
                    {
                        if (m.IdMieszkania == temp_id)
                        {
                            v.Pracownicy_Odp.Remove(m);
                        }
                    }
                    v.SaveChanges();
                }
            }
            zaladujDataGDost();
            zaladujDataGOdp();
        }
    }
    
}
