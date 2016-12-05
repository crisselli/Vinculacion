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

            MySqlCommand cmd = new MySqlCommand(sql, conn);
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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ingreso();
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
