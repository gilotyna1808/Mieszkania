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
        public int id_w_r { get; set; }
        private User uzytkownik;
        public WyswietlRemonty(User u)
        {
            uzytkownik = u;
            InitializeComponent();
            var dba = new DostepPrac();
            if (uzytkownik.getIdStanowiska()==1)
            {
                var querry =
               from a in dba.Remonty
               select new { a.IdRemontu, a.IdMieszkania, a.Koszt_Remontu, a.Stan, a.Data_Rozpoczecia, a.Data_Zakonczenia };
                dataG.ItemsSource = querry.ToList();
            }
            else
            {
                int temp_id = uzytkownik.getIdPrac();
                var querry =
               from a in dba.Remonty
               join a2 in dba.Mieszkanie on a.IdMieszkania equals a2.IdMieszkania
               join a3 in dba.Pracownicy_Odp on a2.IdMieszkania equals a3.IdMieszkania
               where(a2.Posiadane==true && a3.IdPracownika== temp_id)
               select new { a.IdRemontu, a.IdMieszkania, a.Koszt_Remontu, a.Stan, a.Data_Rozpoczecia, a.Data_Zakonczenia };
                dataG.ItemsSource = querry.ToList();
            }
            
        }

        private void btn_W_Click(object sender, RoutedEventArgs e)
        {
            if (dataG.SelectedItems.Count == 1)
            {
                DataGridRow dr = dataG.ItemContainerGenerator.ContainerFromIndex(dataG.SelectedIndex) as DataGridRow;
                DataGridColumn dc = dataG.Columns[0];
                TextBlock cell = dc.GetCellContent(dr) as TextBlock;
                id_w_r = Convert.ToInt32(cell.Text);
            }
            this.Close();
        }
    }
}
