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
        MetodosGenerales metodo = new MetodosGenerales();

        public AdministracionClientes()
        {
            InitializeComponent();
            metodo.llenarCombo(cbBarrios, "SpSelectBarrios", "nombre", "id");
            //cbBarrios.SelectedIndex = 0;
            
        }

        Conexion conexion = new Conexion();

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                lbxMedidores.Items.RemoveAt(lbxMedidores.SelectedIndex);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            };
        }

        private int codigoCliente;
        private void ingresarCliente() {
            try {
                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpInsertClientes", cnn);
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ced", txtCedula.Text.Trim());
                cmd.Parameters.AddWithValue("nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("direccion", txtDireccion.Text.Trim());
                cmd.Parameters.AddWithValue("tipo", rbPersona.Text);

                int result = cmd.ExecuteNonQuery();

                if (result > -1)
                {
                    string sql = "SELECT codigo FROM clientes " +
                                "where ced = '" + txtCedula.Text.Trim() + "'";

                    DataTable dtt = metodo.consultarDatos(sql);
                    codigoCliente = Convert.ToInt32(dtt.Rows[0][0].ToString());
                    cnn.Close();

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            };
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                string barrio = cbBarrios.SelectedValue.ToString();
                string sql = "SELECT substr(id_med,5) FROM medidores " +
                             "where barrio_id = '" + barrio + "' " +
                             "ORDER BY id_med DESC LIMIT 1";

                DataTable dtt = metodo.consultarDatos(sql);
                int siguienteMedidor;
                string codMedidor;
                if (dtt.Rows.Count > 0)
                {
                    codMedidor = dtt.Rows[0][0].ToString();
                    siguienteMedidor = Convert.ToInt32(dtt.Rows[0][0].ToString()) + 1;
                    if (rbMedidor.Checked)
                    {
                        codMedidor = barrio + "-";
                    }
                    else {
                        codMedidor = barrio + "A";
                    }
                    if (siguienteMedidor < 100)
                        codMedidor += 0;
                    if (siguienteMedidor < 10)
                        codMedidor += 0;
                    codMedidor += siguienteMedidor;
                }
                else
                {
                    if (rbMedidor.Checked)
                    {
                        codMedidor = barrio + "-";
                    }
                    else
                    {
                        codMedidor = barrio + "A";
                    }
                    codMedidor += "001";
                }
                lbxMedidores.Items.Add(codMedidor);

            }
            catch (Exception ex)
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
            try
            {
                ingresarCliente();
                string tipo;
                string barrio;
                string mensaje = "Se ingresaron: ";
                int result;

                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpInsertMedidores", cnn);
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                
                for (int i = 0; i< lbxMedidores.Items.Count; i++)
                {
                    barrio = lbxMedidores.Items[i].ToString().Substring(0, 3);

                    if (lbxMedidores.Items[i].ToString().Substring(3,1) == "-")
                        tipo = "MD";
                    else
                        tipo = "AC";
                    
                    cmd.Parameters.AddWithValue("cod_cli", codigoCliente);
                    cmd.Parameters.AddWithValue("barrio_id", barrio);
                    cmd.Parameters.AddWithValue("tipo", tipo);
                    
                    result = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    if (result > -1)
                    {
                        mensaje += lbxMedidores.Items[i].ToString() + " ";
                    }
                }

                MessageBox.Show("Nuevo cliente ingresado exitosamente.");
                txtCedula.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                cbBarrios.SelectedIndex = -1;
                lbxMedidores.Items.Clear();


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
