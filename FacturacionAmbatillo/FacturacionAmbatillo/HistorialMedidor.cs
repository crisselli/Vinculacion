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
            llenarTabla();
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


        private void llenarTabla()
        {
            try
            {
                // Historial de medidor
                string sql = "Select p.codigo CodigoDePago, date_format(l.fecha,'%d-%m-%Y') Fecha, l.Lectura,  " +
                "(IF(l.codigo_categoria = 1 , c.valor , l.lectura * c.valor ) ) AS Valor, " +
                "(IF(p.codigo is not null, IF(p.estado = 0, " +
                "IF(p.numero is not null,'Pendiente','Abonado'),'Cancelado') ,'Pendiente') ) AS Estado " +
                "from categorias c, medidores m, lecturas l left join detalles d " +
                "on l.codigo=d.codigo_lectura " +
                "left join pagos p on d.codigo_pago = p.codigo " +
                "WHERE l.codigo_categoria = c.codigo  " +
                "AND l.codigo_medidor = '" + txtMedidor.Text + "' " +
                "group by l.codigo; ";

                llenarGrid(dgvMedidas, sql);
                dgvMedidas.Columns[0].Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void llenarGrid(DataGridView gv, String select)
        {

            MySqlConnection conn = new MySqlConnection(conexion.MyConString);
            MySqlCommand cmd = new MySqlCommand(select, conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            gv.DataSource = dataTable;
            gv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            conn.Close();
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
            datosMedidor();
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
