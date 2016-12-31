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

namespace FacturacionAmbatillo
{
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
            clbTipoDePago.SetItemCheckState(0, CheckState.Checked);
            llenarTabla();
            dgvPagos.ClearSelection();
            dtpDesde.MaxDate = DateTime.Today;
            dtpHasta.MaxDate = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
        }

        Conexion conexion = new Conexion();
        //public static String MyConString = "SERVER=localhost;" +
        //        "DATABASE=agua;" +
        //        "UID=root;" +
        //        "PASSWORD=root;";

        private void btnLimpiarPagos_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            llenarTabla();
        }

        private void llenarTabla()
        {
            try
            {
                string sql = "";

                // Ver facturas
                if (clbTipoDePago.GetItemCheckState(0) == CheckState.Checked)  
                    sql = sql = "SELECT p.id_pag, date_format(p.fecha,'%d-%m-%Y') Fecha, c.Nombre, p.Total " +
                        "FROM pagos p, detalles d, lecturas l, medidores m, clientes c " +
                        "WHERE p.estado = 1 " +
                        "AND d.cod_pag = p.id_pag " +
                        "AND d.cod_lect = l.id_lect " +
                        "AND l.id_med_p =  m.id_med " +
                        "AND m.cod_cli = c.codigo " +
                        "GROUP BY p.id_pag " +
                        "ORDER BY p.fecha desc;";

                // Ver Recibos
                if (clbTipoDePago.GetItemCheckState(1) == CheckState.Checked)

                    sql = "SELECT a.Numero, date_format(a.fecha,'%d-%m-%Y') Fecha, c.Nombre, a.Valor " +
                        "FROM abonos a, pagos p, detalles d, lecturas l, medidores m, clientes c   " +
                        "WHERE a.cod_pag = p.id_pag " +
                        "AND p.id_pag =  d.cod_pag " +
                        "AND d.cod_lect = l.id_lect " +
                        "AND l.id_med_p =  m.id_med " +
                        "AND m.cod_cli = c.codigo " +
                        "GROUP BY a.id_abon desc;";

                // Ver pagos incompletos
                if (clbTipoDePago.GetItemCheckState(2) == CheckState.Checked)

                    sql = "SELECT a.Numero, date_format(a.fecha,'%d-%m-%Y') Fecha, c.Nombre, a.Valor " +
                        "FROM abonos a, pagos p, detalles d, lecturas l, medidores m, clientes c   " +
                        "WHERE a.cod_pag = p.id_pag " +
                        "AND p.id_pag =  d.cod_pag " +
                        "AND d.cod_lect = l.id_lect " +
                        "AND l.id_med_p =  m.id_med " +
                        "AND m.cod_cli = c.codigo " +
                        "GROUP BY a.id_abon desc;";
                /*
                sql = "SELECT date_format(p.fecha,'%d-%m-%Y') Fecha, c.Nombre, p.Total, a.Abono, p.total - a.abono Saldo, p.Descripcion " +
                        "FROM(SELECT codigo_pago, sum(valor) abono " +
                             "FROM abonos GROUP BY codigo_pago) a, pagos p, " +
                             "detalles d, lecturas l, medidores m, clientes c " +
                        "WHERE p.estado = 0 AND p.numero is null AND " +
                        "a.codigo_pago = p.codigo AND " +
                        "d.codigo_pago = p.codigo AND " +
                        "d.codigo_lectura = l.codigo AND " +
                        "l.codigo_medidor = m.codigo AND " +
                        "m.codigo_cliente = c.codigo " +
                        "GROUP BY p.codigo desc; "; 
                    */
                llenarGrid(dgvPagos, sql);
            }catch (Exception e){
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
            //gv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            conn.Close();


        }

        private void txtNombrePagos_KeyPress(object sender, KeyPressEventArgs e)
        {
       //    string sql = "select ced_cli as Cedula,concat(nom_cli,' ',ape_cli) as Cliente,tel_cli as Telefono,tipo_cli as Tipo " +
       // "from clientes where " +
       // "ced_cli='%" + txtCedula.Text + "%' or" +
       // "nom_cli='%" + txtNombre.Text + "%' or" +
       // "ape_cli='%" + txtNombre.Text + "%' limit 20";


       //     llenarGrid(dgvPagos, sql);
        }

        private void clbTipoDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipo = clbTipoDePago.SelectedIndex;
            for (int i = 0; i < clbTipoDePago.Items.Count; i++) {
                if (i!=tipo)
                    clbTipoDePago.SetItemCheckState(i, CheckState.Unchecked);
            }
            if (clbTipoDePago.CheckedIndices.Count == 0)
                clbTipoDePago.SetItemCheckState(tipo, CheckState.Checked);
            llenarTabla();

            if (clbTipoDePago.SelectedIndex == 2)
                btnAnularPago.Visible = false;
            else
                btnAnularPago.Visible = true;
        }

        private void clbTipoDePago_DoubleClick(object sender, EventArgs e)
        {
            int tipo = clbTipoDePago.SelectedIndex;
            for (int i = 0; i < clbTipoDePago.Items.Count; i++)
            {
                if (i != tipo)
                    clbTipoDePago.SetItemCheckState(i, CheckState.Unchecked);
            }
            if (clbTipoDePago.CheckedIndices.Count == 0)
                clbTipoDePago.SetItemCheckState(tipo, CheckState.Checked);
            llenarTabla();
        }

        private void dgvPagos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Detalles"));
                m.MenuItems.Add(new MenuItem("Anular"));

                int currentMouseOverRow = dgvPagos.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                }

                m.Show(dgvPagos, new Point(e.X, e.Y));

            }
        }

        private void btnAnularPago_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {

        }
    }
}
