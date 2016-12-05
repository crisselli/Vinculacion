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
            sql = "select codigo,nombre from barrios";

            llenarCombo(cbBarrios, sql, "nombre", "codigo");

            sql = "select codigo, cedula as Cedula, nombre as Cliente,telefono as Telefono,tipo " +
            "from clientes limit 20";


            llenarGrid(dgvClientes, sql);
            dgvClientes.Columns[0].Visible = false;
            //dgvClientes.Rows[0].Selected = false;

        }

        private void llenarCombo(ComboBox cb, String select, String mostrar, String valor)
        {

            MySqlConnection conn = new MySqlConnection(conexion.MyConString);
            MySqlCommand cmd = new MySqlCommand(select, conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            cb.DataSource = dataTable;
            cb.ValueMember = valor;
            cb.DisplayMember = mostrar;

            conn.Close();




        }

        private void llenarListview(ListBox ls, String select, String mostrar, String valor)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand(select, conn);
                conn.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                ls.DataSource = dataTable;
                ls.ValueMember = valor;
                ls.DisplayMember = mostrar;

                conn.Close();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCedula.Text = "";
            cbBarrios.SelectedIndex = -1;
            cbTipoDeUsuario.SelectedIndex = -1;
            sql = "select  cedula as Cedula, nombre as Cliente,telefono as Telefono,tipo as Tipo " +
           "from clientes limit 20";

            llenarGrid(dgvClientes, sql);

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

        //public string nombre;
        //protected string medidor;
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

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            sql = "select Cedula, nombre as Cliente, Telefono,Tipo " +
          "from clientes where nombre like '%" + txtNombre.Text + "%'" +
          " and cedula like '%" + txtCedula.Text +
          " and tipo like '%" + cbBarrios.SelectedText + "%'  limit 20";



            llenarGrid(dgvClientes, sql);
        }

        String sql;

        //public static String MyConString = "SERVER=localhost;" +
        //        "DATABASE=agua;" +
        //        "UID=root;" +
        //        "PASSWORD=root;";

        Conexion conexion = new Conexion();
        
        private void llenarGrid(DataGridView gv, String select)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void filtroClientes() {
            sql = "select Cedula, nombre as Cliente, Telefono, Tipo " +
            "from clientes where ";

            if(!txtCedula.Equals(""))


            sql+="nombre like '%" + txtNombre.Text + "%'" +
            " and cedula like '%" + txtCedula.Text +
            "%' and tipo like '%" + cbBarrios.SelectedText + "%'  limit 20";

            llenarGrid(dgvClientes, sql);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            sql = "select Cedula, nombre as Cliente, Telefono, Tipo " +
            "from clientes where nombre like '%" + txtNombre.Text + "%'"+
            " and cedula like '%" + txtCedula.Text +
            "%' and tipo like '%" + cbBarrios.SelectedText + "%'  limit 20";
            
            llenarGrid(dgvClientes, sql);
        }

        private void cbBarrios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void cbTipoDeUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

            sql = "select Cedula, nombre as Cliente, Telefono,Tipo " +
           "from clientes where nombre like '%" + txtNombre.Text + "%'" +
           " and cedula like '%" + txtCedula.Text +
           "%' and tipo ='" + cbTipoDeUsuario.SelectedItem+ "'  limit 20";

          //  MessageBox.Show(cbBarrios.SelectedItem.ToString());

            llenarGrid(dgvClientes, sql);
            dgvClientes.Focus();
            dgvClientes.Rows[dgvClientes.CurrentRow.Index].Selected = false;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sql = "select codigo " +
           "from medidores where codigo_cliente = '" + 
           dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString() + "'";

            //MessageBox.Show(dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString());
            llenarListview(lbxMedidores, sql, "codigo", "codigo");
        }


    }
}
