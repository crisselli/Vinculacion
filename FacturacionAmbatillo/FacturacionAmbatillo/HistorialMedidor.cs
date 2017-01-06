using MySql.Data.MySqlClient;
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
    public partial class HistorialMedidor : Form
    {
        public HistorialMedidor(string nombre, string medidor)
        {
            InitializeComponent();
            this.Size = new Size(485, 490); //655, 455
            // datosMedidor();
            txtNombre.Text = nombre;
            txtMedidor.Text = medidor;
            llenarTabla(medidor);
        }

        Conexion conexion = new Conexion();
        private void datosMedidor()
        {
            dgvMedidas.Rows.Clear();
            dgvMedidas.Rows.Insert(0, "30/11/2015", "18", "2.40", "Cancelado");
            dgvMedidas.Rows.Insert(1, "31/12/2015", "18", "2.40", "Cancelado");
            dgvMedidas.Rows.Insert(2, "31/01/2016", "24", "3.40", "Abonado");
            dgvMedidas.Rows.Insert(3, "28/02/2016", "15", "1.90", "Sin pagar");
            dgvMedidas.Rows.Insert(4, "31/03/2016", "17", "2.15", "Sin pagar");
        }

        MetodosGenerales metodo = new MetodosGenerales();
        DataTable dtt;

        

        private void llenarTabla(string medidor)
        {
            try
            {
                // Historial de medidor
                string sql = "SELECT DATE_FORMAT(l.fecha,'%d/%m/%Y') Fecha, 'Consumo' Detalle, " +
                             "(c.valor * l.cant_total) Valor, l.estado Estado " +
                             "FROM lecturas l, categorias c " +
                             "WHERE c.codigo = l.cod_cat AND " +
                             "id_med_p = '" + medidor + "'";
                
                metodo.llenarGrid(dgvMedidas, sql);
                dgvMedidas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMedidas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMedidas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
       
        private void btnPagar_Click(object sender, EventArgs e)
        {
            panelPagos.Visible = true;
        }

        private void datosPago(int n)
        {
            btnAtras.Visible = true;
            dgvMedidas.Rows.Clear();
            columnasPagos(true);
            columnasMedidor(false);
            if(n==0)
                this.Size = new Size(660, 565);
            else
                this.Size = new Size(660, 630);
            dgvMedidas.Width = 583;
            btnPagar.Visible = false;
            panelPagos.Visible = false;
            label3.Visible = false;
            lblTotal.Visible = false;
            dgvMedidas.Rows.Insert(0, "", "", "", "", "376", "8", "8", "Consumo", "0.30", "2.40");
            dgvMedidas.Rows.Insert(1, "", "", "", "", "", "", "1", "Interés", "0.24", "0.24");
            dgvMedidas.Rows.Insert(2, "", "", "", "", "384", "1", "8", "Consumo", "1.50", "1.50");
            dgvMedidas.Rows.Insert(3, "", "", "", "", "", "", "1", "Interés", "0.15", "0.15");
            dgvMedidas.Rows.Insert(4, "", "", "", "", "391", "10", "10", "Consumo", "0.30", "3.00");
            dgvMedidas.Rows.Insert(5, "", "", "", "", "", "", "1", "Interés", "0.30", "0.30");
            dgvMedidas.Rows.Insert(6, "", "", "", "", "", "", "", "", "Subtotal", "7.59");
            dgvMedidas.Rows.Insert(7, "", "", "", "", "", "", "", "", "Dscto.", "0.00");
            dgvMedidas.Rows.Insert(8, "", "", "", "", "", "", "", "", "IVA 0%", "7.59");
            dgvMedidas.Rows.Insert(9, "", "", "", "", "", "", "", "", "IVA 12%", "0.00");
            dgvMedidas.Rows.Insert(10, "", "", "", "", "", "", "", "", "TOTAL", "7.59");

        }

        private void columnasPagos(bool valor)
        {
            dgvMedidas.Columns["LAnterior"].Visible = valor;
            dgvMedidas.Columns["LActual"].Visible = valor;
            dgvMedidas.Columns["Cant"].Visible = valor;
            dgvMedidas.Columns["Detalle"].Visible = valor;
            dgvMedidas.Columns["VUnitario"].Visible = valor;
            dgvMedidas.Columns["VTotal"].Visible = valor;
        }

        private void columnasMedidor(bool valor)
        {
            dgvMedidas.Columns["Fecha"].Visible = valor;
            dgvMedidas.Columns["Medida"].Visible = valor;
            dgvMedidas.Columns["Valor"].Visible = valor;
            dgvMedidas.Columns["Estado"].Visible = valor;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            btnAtras.Visible = false;
            dgvMedidas.Rows.Clear();
            columnasPagos(false);
            columnasMedidor(true);
            this.Size = new Size(485, 490);
            dgvMedidas.Width = 400;
            btnPagar.Visible = true;
            label3.Visible = true;
            lblTotal.Visible = true;
            panelSaldo.Visible = false;
            panelTotal.Visible = false;
            //datosMedidor();
        }

        private void tsmiFactura_Click(object sender, EventArgs e)
        {
            lblTipoDePago.Text = "FACTURA N°";
            panelTotal.Location = new Point(26, 386);//33, 420);
            panelTotal.Visible = true;
            datosPago(0);
        }

        private void tsmiAbono_Click(object sender, EventArgs e)
        {
            lblTipoDePago.Text = "ABONO N°";
            panelSaldo.Location = new Point(26, 386);
            panelSaldo.Visible = true;            
            datosPago(1);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void HistorialMedidor_Load(object sender, EventArgs e)
        {

        }

        private void dgvMedidas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvMedidas.Rows[dgvMedidas.CurrentRow.Index].Selected)
                dgvMedidas.Rows[dgvMedidas.CurrentRow.Index].Selected = false;
            else
            {
                string codigoPago = dgvMedidas[0, dgvMedidas.CurrentRow.Index].Value.ToString();
                string estado = dgvMedidas[4, dgvMedidas.CurrentRow.Index].Value.ToString();
                if (estado.Equals("Abonado"))
                    for (int i = 0; i < dgvMedidas.RowCount; i++)
                    {
                        if (estado == dgvMedidas[4, i].Value.ToString())
                            dgvMedidas.Rows[i].Selected = true;
                    }
            }
        }
    }
}
