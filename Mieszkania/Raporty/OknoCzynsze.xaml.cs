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

namespace Mieszkania.Raporty
{
    /// <summary>
    /// Interaction logic for OknoCzynsze.xaml
    /// </summary>
    public partial class OknoCzynsze : Window
    {
        public OknoCzynsze()
        {
            
            InitializeComponent();
            CBid.DisplayMemberPath = "Value";
            CBid.SelectedValuePath = "Key";
            using (var dba = new DostepPrac())
            {
                var querry =
                from a in dba.Mieszkanie
                select new { a.IdMieszkania, a.Miasto, a.Nr_Domu, a.Nr_Mieszkania };
                var list = querry.ToList();
                Dictionary<int, string> lok = new Dictionary<int, string>();
                lok = list.ToDictionary(x => x.IdMieszkania, x => "Miasto:" + x.Miasto + " Nr_domu:" + x.Nr_Domu + " Nr_mieszkania:" + x.Nr_Mieszkania);
                CBid.ItemsSource = lok;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();


            MieszkanieKosztyDataSet dataset = new MieszkanieKosztyDataSet();

            dataset.BeginInit();
            reportDataSource1.Name = "ZaplCzynsz";
            reportDataSource1.Value = dataset.Czynsz;
            this.R_Czynsze.LocalReport.DataSources.Clear();
            this.R_Czynsze.LocalReport.DataSources.Add(reportDataSource1);
            this.R_Czynsze.LocalReport.ReportPath = "../../Raporty/Raport_Czynsz.rdlc";
            dataset.EndInit();

            // MLokatorDataSetTableAdapters.MLokatorGetAllTableAdapter dataTable1TableAdapter = new MLokatorDataSetTableAdapters.MLokatorGetAllTableAdapter();
            MieszkanieKosztyDataSetTableAdapters.CzynszTableAdapter dataTable1TableAdapter = new MieszkanieKosztyDataSetTableAdapters.CzynszTableAdapter();
            int id = Convert.ToInt32(CBid.SelectedValue);
            dataTable1TableAdapter.ClearBeforeFill = true;
            dataTable1TableAdapter.Fill(dataset.Czynsz, id);
            R_Czynsze.RefreshReport();
        }
    }
}
