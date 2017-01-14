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
        private Form panel = new Form();
        Clientes cl = new Clientes();
        Pagos pg=new Pagos();
        Lecturas lc=new Lecturas();
        Reportes re = new Reportes();
        Configuracion co;

        public Principal(string user)
        {
            InitializeComponent();
            //Cargar la pagina clientes como vista principal
            lblClientes_Click(new object(), new EventArgs());
            //Ajustar posición de textos de encabezado
            Principal_Resize(new object(), new EventArgs());
            //Cargar nombre de usuario
            cargarUsuario(user);
            co = new Configuracion(user);
        }

        MetodosGenerales metodo = new MetodosGenerales();
        DataTable dtt;

        private void cargarUsuario(string user) {
            string sql = "SELECT substring_index(" +
                            "(SELECT nombres FROM usuarios " +
                            "where ced = '" + user + "'),' ',1);";
            dtt = metodo.consultarDatos(sql);
            lblUsuario.Text = dtt.Rows[0][0].ToString();
        }

        //Agregar Form en panel
        public void AddFormInPanel(Form fh){        
            fh.TopLevel = false;
            fh.MdiParent = this;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(fh);
            splitContainer2.Panel2.Tag = fh;
            fh.Show();
        }
        
        //Cambiar entre formularios ya abiertos
        public void cambiarFormulario(int b) {
            if(panel!=null)
                panel.Visible=false;

            switch (b)
            {
                case 0: 
                    this.panel = cl;    //Clientes
                    break;
                case 1: 
                    this.panel =  pg;   //Pagos
                    break;
                case 2:
                    this.panel = lc;    //Lecturas
                    break;
                case 3:
                    this.panel = re;    //Reportes
                    break;
                case 4:
                    this.panel = co;    //Configuración
                    break;
            }
            panel.Visible = true;
            AddFormInPanel(panel);

        }

        private void procesoFacuracion(string nom, string med)
        {
            //this.panel = new HistorialMedidor(nom, med);
            //AddFormInPanel(panel);

        }
        //Cambiar apariencia de los botones, todos en blanco
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

        private void Principal_Resize(object sender, EventArgs e)
        {
            int x = (this.Width - lblTitulo.Width)/2;
            pbConfiguracion.Location = new Point(this.Width - 60, pbConfiguracion.Location.Y);
            lblUsuario.Location = new Point(this.Width - lblUsuario.Width - 62, lblUsuario.Location.Y);
            lblTitulo.Location = new Point(x, lblTitulo.Location.Y);
        }
        
        #region Click cambio de panel

        private void lblClientes_Click(object sender, EventArgs e)
        {
                cambiarFormulario(0);
                limpiaLabels();
                lblClientes.Image = Properties.Resources.clientes2;
                lblClientes.ForeColor = Color.FromArgb(224, 224, 224);
                lblClientes.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "CLIENTES";
        }

        private void lblPagos_Click(object sender, EventArgs e)
        {
                cambiarFormulario(1);
                limpiaLabels();
                lblPagos.Image = Properties.Resources.factura2;
                lblPagos.ForeColor = Color.FromArgb(224, 224, 224);
                lblPagos.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "PAGOS";
        }

        private void lblLecturas_Click(object sender, EventArgs e)
        {
                cambiarFormulario(2);
                limpiaLabels();
                lblLecturas.Image = Properties.Resources.lecturas2;
                lblLecturas.ForeColor = Color.FromArgb(224, 224, 224);
                lblLecturas.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "LECTURAS";
        }

        private void lblReportes_Click(object sender, EventArgs e)
        {
                cambiarFormulario(3);
                limpiaLabels();
                lblReportes.Image = Properties.Resources.reportes2;
                lblReportes.ForeColor = Color.FromArgb(224, 224, 224);
                lblReportes.BackColor = Color.FromArgb(38, 38, 38);
                lblTitulo.Text = "REPORTES";
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

        #endregion
        
    }
}
