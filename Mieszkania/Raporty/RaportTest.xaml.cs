using System;
using System.Collections.Generic;
using System.Data;
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
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

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
        public static DataTable CreateDataTable<T>(IEnumerable<T> entities)
        {
            var dt = new DataTable();

            //creating columns
            foreach (var prop in typeof(T).GetProperties())
            {
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }

            //creating rows
            foreach (var entity in entities)
            {
                var values = GetObjectValues(entity);
                dt.Rows.Add(values);
            }


            return dt;
        }

        public static object[] GetObjectValues<T>(T entity)
        {
            var values = new List<object>();
            foreach (var prop in typeof(T).GetProperties())
            {
                values.Add(prop.GetValue(entity));
            }

            return values.ToArray();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test.Reset();
            
            DostepPrac dp = new DostepPrac();
            ReportParameter rp = new ReportParameter("Imie", uzytkownik.getImie());
            ReportParameter rp2 = new ReportParameter("Nazwisko", uzytkownik.getNazwisko());
            //ReportDataSource ds = new ReportDataSource("DataSet1",dp);
            Test.LocalReport.ReportPath = "../../Testowy.rdlc";
            Test.LocalReport.SetParameters(new ReportParameter[] { rp,rp2 });
            //Test.LocalReport.DataSources.Add(ds);
            Test.RefreshReport();
        }
    }
}
