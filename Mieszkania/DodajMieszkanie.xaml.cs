using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy DodajMieszkanie.xaml
    /// </summary>
    public partial class DodajMieszkanie : UserControl
    {
        
       
        public DodajMieszkanie()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new DostepPrac())
            {
                var m = new Mieszkanie()
                {
                    Miasto = txt_Miasto.Text.Trim(),
                    Mieszkanie1 = txt_Mieszkanie.Text.Trim(),
                    Nr_Domu = txt_Nr.Text.Trim(),
                    Ulica = txt_Ul.Text.Trim(),
                    Status_Mieszkania = txt_status.Text.Trim(),
                    Kod_Pocztowy = txt_Kod.Text
                };
                db.Mieszkanie.Add(m);
                db.SaveChanges();
            }
            //Do testów 
            /*var dba = new DostepPrac();
            var querry =
               from a in dba.Mieszkanie
               select new {a.IdMieszkania,a.Kod_Pocztowy,a.Miasto,a.Mieszkanie1,a.Nr_Domu,a.Status_Mieszkania,a.Ulica};
            dataG.ItemsSource = querry.ToList();*/
        }
    }
}
