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
    public partial class AdministracionClientes : Form
    {
        public AdministracionClientes()
        {
            InitializeComponent();
            cbBarrios.SelectedIndex = 0;
            llenarCombo(cbBarrios, "SpSelectBarrios", "nombre", "id");
            cbTipoDeUsuario.SelectedIndex = 0;
        }

        private string sql;
        Conexion conexion = new Conexion();

        private void llenarCombo(ComboBox cb, string selectProcedure, string mostrar, string valor)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand(selectProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);

                cb.DataSource = dataTable;
                cb.ValueMember = valor;
                cb.DisplayMember = mostrar;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbxMedidores.Items.RemoveAt(lbxMedidores.SelectedIndex);
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string barrio = cbBarrios.SelectedValue.ToString();
                //string sql = "SELECT codigo FROM agua.medidores " +
                //             "where codigo_barrio = '" + barrio + "'" +
                //             "ORDER BY codigo DESC LIMIT 1;";
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);

                MySqlCommand cmd = new MySqlCommand("SpSelectBarrios", conn);
                conn.Open();

                MySqlDataReader myreader = cmd.ExecuteReader();
                myreader.Read();
                string codMedidor;
                if (myreader.HasRows)
                {
                    codMedidor = myreader["codigo"].ToString();
                    int medidor = Convert.ToInt32(codMedidor.Substring(4))+1;
                    codMedidor = barrio + "-";
                    if (medidor < 100)
                        codMedidor += 0;
                    if (medidor < 10)
                        codMedidor += 0; 
                    codMedidor += medidor;

                    lbxMedidores.Items.Add(codMedidor);
                }
                else
                {
                    codMedidor = barrio + "-001";
                    lbxMedidores.Items.Add(codMedidor);
                }
                conn.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
