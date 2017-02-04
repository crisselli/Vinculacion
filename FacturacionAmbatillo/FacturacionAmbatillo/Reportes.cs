using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace FacturacionAmbatillo
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
            rvDiario.Visible = false;
            rvMensual.Visible = false;
            panel.Visible = false;
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tesisfid_aguaDataSetDiario.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.tesisfid_aguaDataSetDiario.DataTable1);
            // TODO: esta línea de código carga datos en la tabla 'tesisfid_aguaDataSetDiario.SpReporte' Puede moverla o quitarla según sea necesario.
            //this.SpReporteTableAdapter.Fill(this.tesisfid_aguaDataSetDiario.SpReporte);
            // TODO: esta línea de código carga datos en la tabla 'tesisfid_aguaDataSetDiario.DataTable1' Puede moverla o quitarla según sea necesario.
            //this.reportViewer1.RefreshReport();
        }

        private void btnDiario_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            rvMensual.Visible = false;
            rvDiario.Visible = true;
            this.dataTable1TableAdapter1.Fill(this.tesisfid_aguaDataSetDiario.DataTable1);
            this.rvDiario.RefreshReport();
        }

        private void btnMensual_Click(object sender, EventArgs e)
        {
            rvDiario.Visible = false;
            rvMensual.Visible = true;
            panel.Visible = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1;
                DateTime dt2;
                dt1 = Convert.ToDateTime(dtpFecha1.Value.Date);
                dt2 = Convert.ToDateTime(dtpFecha2.Value.Date);
                ReportParameter[] parameters = new ReportParameter[2];
                //Establecemos el valor de los parámetros
                //parameters[0] = new ReportParameter("Fecha1",String.Format("{0:dd/MM/yyyy}", dt1));
                //parameters[0] = new ReportParameter("Fecha1", String.Format("{0:yyyy-MM-dd}", dt1));
                parameters[0] = new ReportParameter("Fecha1", "2017/01/19");
                //MessageBox.Show(String.Format("{0:yyyy-MM-dd HH:mm:ss t}", dt1));
                //parameters[1] = new ReportParameter("Fecha2", String.Format("{0:yyyy-MM-dd}", dt2));
                parameters[1] = new ReportParameter("Fecha2", "2017/01/31");
                //MessageBox.Show(String.Format("{0:yyyy-MM-dd HH:mm:ss t}", dt2));
                rvMensual.LocalReport.SetParameters(parameters);
                //reportViewer1.RefreshReport();
                SpReporteTableAdapter.Fill(tesisfid_aguaDataSetDiario.SpReporte,dt1,dt2);
                rvMensual.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
