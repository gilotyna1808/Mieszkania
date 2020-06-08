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
    /// Interaction logic for Okno_PracownicyOdp.xaml
    /// </summary>
    public partial class Okno_PracownicyOdp : Window
    {
        public Okno_PracownicyOdp()
        {
            InitializeComponent();
            R_Pracownicy_Odp.Load += R_Pracownicy_Odp_Load;        
        }
        private bool isR_Pracownicy_OdpLoaded;
        private void R_Pracownicy_Odp_Load(object sender, EventArgs e)
        {
            if (!isR_Pracownicy_OdpLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                Pracownicy_OdpDataSet dataset = new Pracownicy_OdpDataSet();
                dataset.BeginInit();
                reportDataSource1.Name = "DataSetPracownicy_Odp";

                reportDataSource1.Value = dataset.Pracownicy_OdpGetAll;
                this.R_Pracownicy_Odp.LocalReport.DataSources.Add(reportDataSource1);
                this.R_Pracownicy_Odp.LocalReport.ReportPath = "../../Raporty/Raport_Pracownicy_Odp.rdlc";
                dataset.EndInit();

                //AutoryzacjaDataSetTableAdapters.AutoryzacjaTableAdapter autoryzacjaTableAdapter = new AutoryzacjaDataSetTableAdapters.AutoryzacjaTableAdapter();
                Pracownicy_OdpDataSetTableAdapters.Pracownicy_OdpGetAllTableAdapter dataTable1TableAdapter = new Pracownicy_OdpDataSetTableAdapters.Pracownicy_OdpGetAllTableAdapter();

                dataTable1TableAdapter.ClearBeforeFill = true;
                dataTable1TableAdapter.Fill(dataset.Pracownicy_OdpGetAll);
                R_Pracownicy_Odp.RefreshReport();
                isR_Pracownicy_OdpLoaded = true;

            }
            
        }
    }
}
