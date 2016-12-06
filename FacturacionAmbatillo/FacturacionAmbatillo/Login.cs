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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();

        private void ingreso() {
            string sql = "select nombre from configuraciones " +
                         "where usuario = '" + txtUsuario.Text + "' and " +
                         "clave = '" + txtClave.Text + "'";
            MySqlConnection conn = new MySqlConnection(conexion.MyConString);

            MySqlCommand cmd = new MySqlCommand("SpLoginUsuarios",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ced");
            cmd.Parameters.Add("pass");

            MySqlDataReader red = cmd.ExecuteReader();
            
            cmd.ExecuteNonQuery();

            conn.Open();

            MySqlDataReader myreader = cmd.ExecuteReader();
            myreader.Read();

            if (myreader.HasRows)
            {
                this.Hide();
                Principal pr = new Principal();
                pr.ShowDialog();
                this.Close();
            }
            else
            {
                lblErrorPass.Visible = true;
            }

            conn.Close();
        }
        private string validarUser(string ced,string pass)
        {
            string user=null;
            try
            {
                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SpLoginUsuarios", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ced",ced.Trim());
                cmd.Parameters.AddWithValue("pass",pass.Trim());
                MySqlDataReader red = cmd.ExecuteReader();
                red.Read();
                if (red.HasRows)
                {
                    this.Hide();
                    Principal pr = new Principal();
                    pr.ShowDialog();
                    this.Close();
                
                    while (red.NextResult())
                    {
                        user = red["nombre"].ToString();
                    }

                }
                else
                {
                    lblErrorPass.Visible = true;
                }
                red.Close();
                cnn.Close();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

            return user;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            validarUser(txtUsuario.Text,txtClave.Text);
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ingreso();
            }
        }

        private void txtClave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ingreso();
            }
        }


    }
}
