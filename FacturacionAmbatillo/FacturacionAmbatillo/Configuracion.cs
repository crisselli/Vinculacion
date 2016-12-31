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
    public partial class Configuracion : Form
    {
        public Configuracion(string user)
        {
            InitializeComponent();
            cargarUsuario(user);
            cargarRangos();
            cargarRubros();
            cargarBarrios();
        }

        Conexion conexion = new Conexion();
        MetodosGenerales metodo = new MetodosGenerales();

        private void cargarRubros()
        {
            metodo.llenarGrid(dgvRubros, "SpSelectRubros");
        }

        private void cargarBarrios()
        {
            metodo.llenarGrid(dgvBarrios, "SpSelectBarrios");
        }

        string sql;

        private void cargarRangos(){
            try
            {
                sql = "select fact_desde, fact_hasta, recib_desde, recib_hasta from configuraciones;";
                DataTable dataTable = metodo.consultarDatos(sql);
                lblErroreses.Text = dataTable.Rows[0][0].ToString() ;
                txtFaDesde.Text = dataTable.Rows[0][0].ToString();
                txtFaHasta.Text = dataTable.Rows[0][1].ToString();
                txtReDesde.Text = dataTable.Rows[0][2].ToString();
                txtReHasta.Text = dataTable.Rows[0][3].ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            };
        }
 
        private void cargarUsuario(string user)
        {
            sql = "select nombres, tel_cel from usuarios where ced = '"+ user +" ';";
            DataTable dataTable = metodo.consultarDatos(sql);

            txtNombres.Text = dataTable.Rows[0][0].ToString();
            //txtApellidos.Text = dataTable.Rows[0][1].ToString();
            txtPass.Text = "passw";
        }

        private void btnCancelarPass_Click(object sender, EventArgs e)
        {
            btnEditarPass.Text = "Editar";
            btnEditarPass.ImageIndex = 2;
            lblErrorPass.Visible = false;
            opcionesUsuario(false);
            cargarRangos();
            btnEditarPass.Enabled = true;
        }

        private string[] auxDatosUsuario;
        private int[] auxDatosRangos;

        private void btnEditarPass_Click(object sender, EventArgs e)
        {
            lblErrorPass.Visible = false;
            if (btnEditarPass.Text.Equals("Editar")) //Opción Editar Usuario
            {
                //Cargar los datos de usuario en una variable temporal para comprobar
                auxDatosUsuario = new string[]{txtNombres.Text, txtApellidos.Text, txtPass.Text};
                //Limpiar campos de contraseña
                txtPass.Text = "";
                txtNuevaPass.Text = "";
                txtRepetirNuevaPass.Text = "";
                //Cambiar apariencia del boton editar
                btnEditarPass.Text = "Guardar";
                btnEditarPass.Enabled = false;
                btnEditarPass.ImageIndex = 0;
                opcionesUsuario(true);
                lblErrorPass.Visible = false;
                
            }
            else //Opción Guardar Usuario
            {
                
                if (auxDatosUsuario[2].Equals(txtPass.Text)) 
                {
                    //MessageBox.Show("txtPass = " + txtPass.Text + "\nauxDatosUsuario[2] = " + auxDatosUsuario[2]);
                    sql = "update configuraciones set " +
                    "nombres = '" + txtNombres.Text + "', " +
                    "apellidos = '" + txtApellidos.Text + "'";

                    if(txtNuevaPass.Text.Trim().Length>0)
                        if (txtNuevaPass.Text.Trim() == txtRepetirNuevaPass.Text.Trim())
                        {
                            sql += ", paswd = '" + txtNuevaPass.Text + "';";
                            actualizarDatos(sql);
                            cargarRangos();
                            btnEditarPass.Text = "Editar";
                            btnEditarPass.ImageIndex = 2;
                            opcionesUsuario(false);
                        }
                        else
                        {
                            lblErrorPass.Text = "*Las contraseñas no coinciden";
                            lblErrorPass.Location = new Point(400, 141);
                            lblErrorPass.Visible = true;
                        }
                    else
                    {
                        actualizarDatos(sql);
                        cargarRangos();
                        btnEditarPass.Text = "Editar";
                        btnEditarPass.ImageIndex = 2;
                        opcionesUsuario(false);
                    }
                                 
                    
                }
                else
                {
                    lblErrorPass.Text = "*Su contraseña es incorrecta";
                    lblErrorPass.Location = new Point(400, 103);
                    lblErrorPass.Visible = true;
                }
                
            }
        }

        //Metodo para habilitar o dehabilitar opciones del bonon editar usuario
        private void opcionesUsuario(bool op) {
            label21.Visible = op;
            label22.Visible = op;
            txtNombres.Enabled = op;
            txtApellidos.Enabled = op;
            txtPass.Enabled = op;
            txtNuevaPass.Enabled = op;
            txtNuevaPass.Visible = op;
            txtRepetirNuevaPass.Enabled = op;
            txtRepetirNuevaPass.Visible = op;
            btnCancelarPass.Visible = op;
        }

        //Opciones para habilitar la edicion de los rangos de pagos
        private void opcionesValores(bool op)
        {
            txtFaDesde.Enabled = op;
            txtFaHasta.Enabled = op;
            txtReDesde.Enabled = op;
            txtReHasta.Enabled = op;
            btnCancelarValores.Visible = op;
        }

        private void actualizarDatos (string sql)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

       
        private int factRestantes, recibRestantes;
        private void btnEditarValores_Click_1(object sender, EventArgs e)
        {
            lblErrorPass.Visible = false;
            if (btnEditarValores.Text.Equals("Editar")) //Opción Editar Valores
            {
                //Cambiar apariencia del boton de editar a guardar
                btnEditarValores.Text = "Guardar";
                //btnEditarValores.Enabled = false;
                btnEditarValores.ImageIndex = 0;
                opcionesValores(true);
                lblErrorValores.Visible = false;

            }
            else //Opción Guardar Valores
            {
                auxDatosRangos = new int[]{
                        Convert.ToInt32(txtFaDesde.Text),
                        Convert.ToInt32(txtFaHasta.Text),
                        Convert.ToInt32(txtReDesde.Text),
                        Convert.ToInt32(txtReHasta.Text)};
                if (auxDatosRangos[0] >= 0 && auxDatosRangos[2] >= 0 &&
                    auxDatosRangos[0] < auxDatosRangos[1] && auxDatosRangos[2] < auxDatosRangos[3])
                {
                    
                    sql = "update Configuraciones set " +
                    "Fact_desde = '" + txtFaDesde.Text + "', " +
                    "Fact_hasta = '" + txtFaHasta.Text + "', " +
                    "Recib_desde = '" + txtReDesde.Text + "', " +
                    "Recib_hasta = '" + txtReHasta.Text + "'";
                    
                    actualizarDatos(sql);
                    cargarRangos();
                    btnEditarValores.Text = "Editar";
                    btnEditarValores.ImageIndex = 2;
                    lblErrorValores.Visible = false;
                    opcionesValores(false);
                        }
                        else
                        {
                            lblErrorValores.Visible = true;
                        }
                

            }

        }

        private void btnCancelarValores_Click(object sender, EventArgs e)
        {
            btnEditarValores.Text = "Editar";
            btnEditarValores.ImageIndex = 2;
            opcionesValores(false);
            btnEditarValores.Enabled = true;
            cargarRangos();
        }

        private void txtNombreCompleto_KeyUp(object sender, KeyEventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            comprobarDatosUsuario();

        }

        private void txtNuevaPass_KeyUp(object sender, KeyEventArgs e)
        {
            comprobarDatosUsuario();
        }

        private void txtRepetirNuevaPass_KeyUp(object sender, KeyEventArgs e)
        {
            comprobarDatosUsuario();
        }

        //Metodo para habilitar o deshabilitar el boton guardar Usuario
        private void comprobarDatosUsuario(){
            if (auxDatosUsuario[0].Equals(txtNombres.Text) &&
                auxDatosUsuario[1].Equals(txtApellidos.Text) &&
                txtPass.Text.Trim().Equals("") &&
                txtNuevaPass.Text.Trim().Equals("") &&
                txtRepetirNuevaPass.Text.Trim().Equals(""))

                btnEditarPass.Enabled = false;
            else
                btnEditarPass.Enabled = true;
        }

      
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dgvRubros.Rows.Add();
            //dgvRubros.Rows[dgvRubros.Rows.Count - 1].ReadOnly = false;
            
        }


        //Controlar que solo se ingresen numeros
        private void txtFaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtFaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtReDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtReHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }


        //Cambiar los valores de factura/recibo siguientes y restantes
        private void txtFaDesde_Leave(object sender, EventArgs e)
        {
            int val2 = Convert.ToInt32(txtFaHasta.Text.Trim());
            int val;
            if (txtFaDesde.Text.Trim().Equals("")){
                txtFaDesde.Text = "1"; val = 1;
            }
            else
            {
                val = Convert.ToInt32(txtFaDesde.Text.Trim());
                if (val < 0){
                    txtFaDesde.Text = "1"; val = 1;
                }
            }
            lblSiguienteFactura.Text = val.ToString();
            lblSiguienteFactura.ForeColor = Color.DarkCyan;
            lblSiguienteFactura.Font = new Font(lblSiguienteFactura.Font, FontStyle.Bold);
            factRestantes = val2 - val + 1;
            lblFacturasRestantes.Text = "Ahora quedan " + factRestantes + " facturas";
            if (factRestantes < 0)
                lblFacturasRestantes.ForeColor = Color.IndianRed;
            else 
                lblFacturasRestantes.ForeColor = Color.DarkCyan;
        }

        private void txtFaHasta_Leave(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(txtFaDesde.Text.Trim());
            int val2;
            if (txtFaHasta.Text.Trim().Equals("")){
                txtFaHasta.Text = "1"; val2 = 1;
            }
            else{
                val2 = Convert.ToInt32(txtFaHasta.Text.Trim());
                if (val2 < 0){
                    txtFaHasta.Text = "1"; val2 = 1;
                }
            }
            factRestantes = val2 - val + 1;
            lblFacturasRestantes.Text = "Ahora quedan " + factRestantes + " facturas";
            if (factRestantes < 0)
                lblFacturasRestantes.ForeColor = Color.IndianRed;
            else
                lblFacturasRestantes.ForeColor = Color.DarkCyan;

            if (txtFaHasta.Text.Trim().Equals(""))
                txtFaHasta.Text = "0";
            else if (Convert.ToInt32(txtFaHasta.Text.Trim()) < 0)
                txtFaHasta.Text = "0";
        }

        private void txtReDesde_Leave(object sender, EventArgs e)
        {
            int val2 = Convert.ToInt32(txtReHasta.Text.Trim());
            int val;
            if (txtReDesde.Text.Trim().Equals(""))
            {
                txtReDesde.Text = "1"; val = 1;
            }
            else
            {
                val = Convert.ToInt32(txtReDesde.Text.Trim());
                if (val < 0)
                {
                    txtReDesde.Text = "1"; val = 1;
                }
            }
            lblSiguienteRecibo.Text = val.ToString();
            lblSiguienteRecibo.ForeColor = Color.DarkCyan;
            lblSiguienteRecibo.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Bold);
            recibRestantes = val2 - val + 1;
            lblRecibosRestantes.Text = "Ahora quedan " + recibRestantes + " recibos";
            if (recibRestantes < 0)
                lblRecibosRestantes.ForeColor = Color.IndianRed;
            else
                lblRecibosRestantes.ForeColor = Color.DarkCyan;
        }

        private void txtReHasta_Leave(object sender, EventArgs e)
        {
            if (txtReHasta.Text.Trim().Equals(""))
                txtReHasta.Text = "0";
            else if (Convert.ToInt32(txtReHasta.Text.Trim()) < 0)
                txtReHasta.Text = "0";
        }

       
    }
}
