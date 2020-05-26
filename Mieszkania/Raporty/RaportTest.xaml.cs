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
using Microsoft.Reporting.WinForms;
namespace Mieszkania.Raporty
{
    /// <summary>
    /// Logika interakcji dla klasy RaportTest.xaml
    /// </summary>
    public partial class RaportTest : Window
    {
        User uzytkownik;
        public RaportTest(User u)
        {
            uzytkownik = u;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test.Reset();
            DostepPrac dp = new DostepPrac();
            ReportParameter rp = new ReportParameter("Imie", uzytkownik.getImie());
            ReportParameter rp2 = new ReportParameter("Nazwisko", uzytkownik.getNazwisko());
            Test.LocalReport.ReportPath = "Testowy.rdlc";
            Test.LocalReport.SetParameters(new ReportParameter[] { rp,rp2 });
            Test.RefreshReport();
        }
    }
}
