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
using System.Data.SqlClient;
using System.Data;

namespace Mieszkania.Raporty
{
    /// <summary>
    /// Interaction logic for MieszkanieLokator.xaml
    /// </summary>
    public partial class MieszkanieLokator : Window
    {


        public MieszkanieLokator()
        {
            InitializeComponent();
            using(var dba = new DostepPrac())
            {
               var querry =
               from a in dba.Lokator
               select new { a.IdLokatora , a.Nazwisko, a.Imie, a.Pesel};
               var list = querry.ToList();
                Dictionary<int, string> lok= new Dictionary<int, string>();
                lok = list.ToDictionary(x=>x.IdLokatora,x=> "Pesel:"+ x.Pesel+" Nazwisko:" +x.Nazwisko +" Imie:" + x.Imie);
                CBid.ItemsSource = lok;
            }
        }
 
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();


                MLokatorDataSet dataset = new MLokatorDataSet();

                dataset.BeginInit();
                reportDataSource1.Name = "MLokator";
                reportDataSource1.Value = dataset.MLokatorGetAll;
                this.R_MieszkanieLokator.LocalReport.DataSources.Clear();
                this.R_MieszkanieLokator.LocalReport.DataSources.Add(reportDataSource1);
                this.R_MieszkanieLokator.LocalReport.ReportPath = "../../Raporty/Raport_MieszkanieLokator.rdlc";
                dataset.EndInit();

                MLokatorDataSetTableAdapters.MLokatorGetAllTableAdapter dataTable1TableAdapter = new MLokatorDataSetTableAdapters.MLokatorGetAllTableAdapter();
            int id = Convert.ToInt32( CBid.SelectedValue);
            dataTable1TableAdapter.ClearBeforeFill = true;
                dataTable1TableAdapter.Fill(dataset.MLokatorGetAll,id);
                R_MieszkanieLokator.RefreshReport();
              

            }

        }

        }
    

