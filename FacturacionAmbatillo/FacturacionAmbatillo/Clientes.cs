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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            metodo.llenarGrid(dgvClientes, "SpSelectClientes");
            dgvClientes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtt = (DataTable)dgvClientes.DataSource;

        }

        MetodosGenerales metodo = new MetodosGenerales();
        DataTable dtt;

        //Método para llenar listView Medidores mediante stored procedures
        private void consultarMedidores(string cod)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpSelectMedidores", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod_cli", cod);
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);

                lbxMedidores.DataSource = dataTable;
                lbxMedidores.ValueMember = "id_med";
                lbxMedidores.DisplayMember = "id_med"; //"nombre"

                conn.Close();
            } catch (MySqlException ex) {
                MessageBox.Show(ex.Message);

            } catch (Exception x) {
                MessageBox.Show(x.Message);
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCedula.Text = "";
            cbTipoDeUsuario.SelectedIndex = -1;
            metodo.llenarGrid(dgvClientes, "SpSelectClientes");

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AdministracionClientes ac = new AdministracionClientes();
            ac.Text = "Nuevo Cliente";
            ac.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            AdministracionClientes ac = new AdministracionClientes();
            ac.Text = "Modificar Cliente";
            ac.ShowDialog();
        }
        
        private void btnMedidas_Click(object sender, EventArgs e)
        {
            string nombre = dgvClientes[2, dgvClientes.CurrentRow.Index].Value.ToString();
            string medidor = lbxMedidores.SelectedValue.ToString();
            if (nombre != null && medidor != null)
            {
                HistorialMedidor hm = new HistorialMedidor(nombre, medidor);
                hm.ShowDialog();
            }
        }

        public void filtrarDGV(DataGridView dgv, DataTable dt, int columna, string texto) {
            try {
                string fieldName = string.Concat("[", dt.Columns[columna].ColumnName, "]");
                dt.DefaultView.Sort = fieldName;
                DataView view = dt.DefaultView;
                view.RowFilter = string.Empty;
                if (texto != string.Empty)
                    view.RowFilter = fieldName + " LIKE '%" + texto + "%'";
                dgv.DataSource = view;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            };
        }

        public void filtrarClientes(DataTable dt)
        {
            try
            {
                DataView view = dt.DefaultView;
                view.RowFilter = string.Empty;
                if (txtCedula.Text != string.Empty ||
                    txtNombre.Text != string.Empty ||
                    cbTipoDeUsuario.SelectedText != string.Empty)
                    view.RowFilter = "[ced] LIKE '%" + txtCedula.Text + "%' AND " +
                                     "[nombre] LIKE '%" + txtNombre.Text + "%' AND " +
                                     "[tipo] LIKE '%" + cbTipoDeUsuario.SelectedText + "%'";

                dgvClientes.DataSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            filtrarClientes(dtt);
        }

        string sql;

        Conexion conexion = new Conexion();
        
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            filtrarClientes(dtt);
        }

        private void cbTipoDeUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrarClientes(dtt);
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codigo = dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString();

            //MessageBox.Show(dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString());
            consultarMedidores(codigo);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
