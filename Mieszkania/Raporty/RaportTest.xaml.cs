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
    public partial class RaportTest : UserControl
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
            ReportParameter rp = new ReportParameter("Imie", uzytkownik.getImie());
            ReportParameter rp2 = new ReportParameter("Nazwisko", uzytkownik.getNazwisko());
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Pracownicy_OdpDataSet dataset = new Pracownicy_OdpDataSet();
            dataset.BeginInit();
            reportDataSource1.Name = "DataSet1";

            reportDataSource1.Value = dataset.Pracownicy_OdpDataSet1;
            this.Test.LocalReport.DataSources.Add(reportDataSource1);
            this.Test.LocalReport.ReportPath = "../../Raporty/PracownikMieszkaniaODP.rdlc";
            Test.LocalReport.SetParameters(new ReportParameter[] { rp, rp2 });
            dataset.EndInit();

            Pracownicy_OdpDataSetTableAdapters.Pracownicy_OdpDataSet1TableAdapter dataTable1TableAdapter = new Pracownicy_OdpDataSetTableAdapters.Pracownicy_OdpDataSet1TableAdapter();

            dataTable1TableAdapter.ClearBeforeFill = true;
            dataTable1TableAdapter.Fill(dataset.Pracownicy_OdpDataSet1,uzytkownik.getIdPrac());
            Test.RefreshReport();
        }
    }
}
