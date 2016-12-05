using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionAmbatillo
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            cambiarFormulario(0);
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            lblClientes.Image = Properties.Resources.clientes2;
            lblClientes.ForeColor = Color.FromArgb(224, 224, 224);
            lblClientes.BackColor = Color.FromArgb(38, 38, 38);
            int x = (this.Width - lblTitulo.Width) / 2;
            lblTitulo.Location = new Point(x, lblTitulo.Location.Y);

        }

        private void AddFormInPanel(Form fh){        
            fh.TopLevel = false;
            fh.MdiParent = this;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.splitContainer2.Panel2.Controls.Add(fh);
            this.splitContainer2.Panel2.Tag = fh;
            fh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2.Controls.Count > 0)
                this.splitContainer1.Panel2.Controls.RemoveAt(0);
        }

        private void tsmiClientes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Clientes"] != null) {
                MessageBox.Show("Clientes ya está abierta");
            } else {
                cambiarFormulario(0);
                //tsmiClientes.Image = Properties.Resources.clientes3;
                //tsmiClientes.ForeColor = Color.FromArgb(224,224,224);
                //tsmiClientes.BackColor = Color.FromArgb(38,38,38);
               
            }
        }

        private void tsmiPagos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Pagos"] != null)
            {
                MessageBox.Show("Pagos ya está abierta");
            }
            else
            {
                cambiarFormulario(1);
            }
        }

        private void tsmiLecturas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Lecturas"] != null)
            {
                MessageBox.Show("Lecturas ya está abierta");
            }
            else
            {
                cambiarFormulario(2);
            }
        }

        private void tsmiReportes_Click(object sender, EventArgs e)
        {
            
        }

        private Form panel = new Form();

        private void cambiarFormulario(int b) {
            
            if(panel!=null)
                panel.Close();

            switch (b)
            {
                case 0: 
                    this.panel = new Clientes();
                    break;
                case 1: 
                    this.panel = new Pagos();
                    break;
                case 2:
                    this.panel = new Lecturas();
                    break;
                case 3:
                    this.panel = new Reportes();
                    break;
                case 4:
                    this.panel = new Configuracion();
                    break;
            }
            AddFormInPanel(panel);

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            
        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            int x = (this.Width - lblTitulo.Width)/2;
            pbConfiguracion.Location = new Point(this.Width - 60, pbConfiguracion.Location.Y);
            lblTitulo.Location = new Point(x, lblTitulo.Location.Y);
        }

        private void tsmiClientes_MouseEnter(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;

            // Create semi-transparent picture.
            Bitmap bm = new Bitmap(tsi.Width, tsi.Height);
            for (int y = 0; y < tsi.Height; y++)
            {
                for (int x = 0; x < tsi.Width; x++)
                    bm.SetPixel(x, y, Color.FromArgb(150, Color.Red));
            }

            // Set background.
            tsi.BackgroundImage = bm;
        }

        private void tsmiClientes_MouseLeave(object sender, EventArgs e)
        {
            (sender as ToolStripItem).BackgroundImage = null;
        }


        private void lblClientes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Clientes"] == null)
            {
                cambiarFormulario(0);
                limpiaLabels();
                lblClientes.Image = Properties.Resources.clientes2;
                lblClientes.ForeColor = Color.FromArgb(224, 224, 224);
                lblClientes.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "CLIENTES";
            }
        }

        private void lblPagos_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Pagos"] == null)
            {
                cambiarFormulario(1);
                limpiaLabels();
                lblPagos.Image = Properties.Resources.factura2;
                lblPagos.ForeColor = Color.FromArgb(224, 224, 224);
                lblPagos.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "PAGOS";
            }
        }

        private void lblLecturas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Lecturas"] == null)
            {
                cambiarFormulario(2);
                limpiaLabels();
                lblLecturas.Image = Properties.Resources.lecturas2;
                lblLecturas.ForeColor = Color.FromArgb(224, 224, 224);
                lblLecturas.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "LECTURAS";
            }
        }

        private void lblReportes_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Reportes"] == null)
            {
                cambiarFormulario(3);
                limpiaLabels();
                lblReportes.Image = Properties.Resources.reportes2;
                lblReportes.ForeColor = Color.FromArgb(224, 224, 224);
                lblReportes.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "REPORTES";
            }
        }

        private void limpiaLabels()
        {
            lblClientes.Image = Properties.Resources.clientes1;
            lblClientes.ForeColor = Color.FromArgb(38, 38, 38);
            lblClientes.BackColor = Color.FromArgb(224, 224, 224);

            lblPagos.Image = Properties.Resources.factura1;
            lblPagos.ForeColor = Color.FromArgb(38, 38, 38);
            lblPagos.BackColor = Color.FromArgb(224, 224, 224);

            lblLecturas.Image = Properties.Resources.lecturas1;
            lblLecturas.ForeColor = Color.FromArgb(38, 38, 38);
            lblLecturas.BackColor = Color.FromArgb(224, 224, 224);

            lblReportes.Image = Properties.Resources.reportes1;
            lblReportes.ForeColor = Color.FromArgb(38, 38, 38);
            lblReportes.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void pbConfiguracion_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Configuracion"] == null)
            {
                cambiarFormulario(4);
                limpiaLabels();
                lblTitulo.Text = "CONFIGURACIÓN";
            }
        }
    }
}
