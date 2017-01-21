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
        
        private void validarUser(string ced,string pass)
        {
            //string user = null;
            try
            {
                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpLoginUsuarios", cnn);
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ced", ced.Trim());
                cmd.Parameters.AddWithValue("pass", pass.Trim());
                
                MySqlDataReader myreader = cmd.ExecuteReader();
                myreader.Read();

                if (myreader.HasRows)
                {
                    this.Hide();
                    Principal pr = new Principal(txtUsuario.Text.Trim(), myreader["nombres"].ToString());
                    //Principal pr = new Principal();
                    pr.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblErrorPass.Visible = true;
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            

            //return user;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            validarUser(txtUsuario.Text,txtClave.Text);
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validarUser(txtUsuario.Text, txtClave.Text);
                
            }
        }

        private void txtClave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validarUser(txtUsuario.Text, txtClave.Text);
            }
        }


    }
}
