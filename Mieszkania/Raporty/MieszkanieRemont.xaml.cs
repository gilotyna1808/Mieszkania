using Mieszkania.Raporty.MLokatorDataSetTableAdapters;
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
    /// Interaction logic for MieszkanieRemont.xaml
    /// </summary>
    public partial class MieszkanieRemont : Window
    {
        public MieszkanieRemont()
        {
            InitializeComponent();
            CBid.DisplayMemberPath = "Value";
            CBid.SelectedValuePath = "Key";
            using (var dba = new DostepPrac())
            {
                var querry =
                from a in dba.Mieszkanie
                select new { a.IdMieszkania, a.Miasto, a.Nr_Domu, a.Nr_Mieszkania,a.Ulica };
                var list = querry.ToList();
                Dictionary<int, string> mieszk = new Dictionary<int, string>();
                mieszk = list.ToDictionary(x => x.IdMieszkania, x => "Lokalizacja:" + x.Miasto+" "+x.Ulica + " "+x.Nr_Domu+"/"+x.Nr_Mieszkania);
                CBid.ItemsSource = mieszk;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();


            MLokatorDataSet dataset = new MLokatorDataSet();

            dataset.BeginInit();
            reportDataSource1.Name = "MieszkanieRemont";
            reportDataSource1.Value = dataset.MRemontGetAll;
            this.R_MieszkanieRemont.LocalReport.DataSources.Clear();
            this.R_MieszkanieRemont.LocalReport.DataSources.Add(reportDataSource1);
            this.R_MieszkanieRemont.LocalReport.ReportPath = "../../Raporty/Raport_MieszkanieRemont.rdlc";
            dataset.EndInit();

            // MLokatorDataSetTableAdapters.MLokatorGetAllTableAdapter dataTable1TableAdapter = new MLokatorDataSetTableAdapters.MLokatorGetAllTableAdapter();
            MRemontGetAllTableAdapter dataTable1TableAdapter = new MRemontGetAllTableAdapter();
            int id = Convert.ToInt32(CBid.SelectedValue);
            dataTable1TableAdapter.ClearBeforeFill = true;
            dataTable1TableAdapter.Fill(dataset.MRemontGetAll, id);
            R_MieszkanieRemont.RefreshReport();
        }

       
    }
}
