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
            metodo.llenarGridSP(dgvRubros, "SpSelectRubros");
            dgvRubros.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRubros.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRubros.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
        }

        private void cargarUsuarios()
        {
            metodo.llenarGridSP(dgvUsuarios, "SpSelect_Usuarios");
            dgvUsuarios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[3].Visible = false;
        }

        private void cargarBarrios()
        {
            metodo.llenarGridSP(dgvBarrios, "SpSelectBarrios");
            dgvBarrios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
             
        }

        string sql;

        private void cargarRangos(){
            try
            {
                sql = "select fact_desde, fact_hasta, recib_desde, recib_hasta from configuraciones;";
                DataTable dataTable = metodo.consultarDatos(sql);
                //lblErroreses.Text = dataTable.Rows[0][0].ToString() ;
                txtFaDesde.Text = dataTable.Rows[0][0].ToString();
                txtFaHasta.Text = dataTable.Rows[0][1].ToString();
                txtReDesde.Text = dataTable.Rows[0][2].ToString();
                txtReHasta.Text = dataTable.Rows[0][3].ToString();
                lblSiguienteFactura.Text = dataTable.Rows[0][0].ToString();
                lblSiguienteRecibo.Text = dataTable.Rows[0][2].ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            };
        }

        string rol=""; 

        private void cargarUsuario(string user)
        {
            sql = "select ced, nombres, tel_cel, paswd, roles from Usuarios where ced = '" + user +"';";
            DataTable dataTable = metodo.consultarDatos(sql);

            txtCedula.Text = dataTable.Rows[0][0].ToString();
            txtNombres.Text = dataTable.Rows[0][1].ToString();
            txtTelefono.Text = dataTable.Rows[0][2].ToString();
            txtPass.Text = dataTable.Rows[0][3].ToString(); 
            rol = dataTable.Rows[0][4].ToString();

            if (!rol.Equals("Administrador")) {
                tabControl2.TabPages.Remove(tpUsuarios);
                botonesAdmin();
            }else
                cargarUsuarios();

        }

        private void botonesAdmin()
        {
            btnNuevoRubro.Visible = false;
            btnEliminarRubro.Visible = false;
            btnModificarRubros.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            panelBarrios.Visible = false;
            panelRubros.Visible = false;
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
                auxDatosUsuario = new string[]{txtNombres.Text, txtPass.Text};
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
                Principal pr = new Principal();
                if (auxDatosUsuario[1].Equals(pr.pass)) 
                {
                    //MessageBox.Show("txtPass = " + txtPass.Text + "\nauxDatosUsuario[2] = " + auxDatosUsuario[2]);

                    MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                    MySqlCommand cmd = new MySqlCommand("SpUpdate_Usuarios", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // ced char(10),in nombres varchar(100), in tel_cel varchar(10), in paswd varchar(250), in roles varchar(50) 

                    cnn.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("ced", txtCedula.Text);
                    cmd.Parameters.AddWithValue("nombres", txtNombres.Text);
                    cmd.Parameters.AddWithValue("tel_cel", txtTelefono.Text);
                    
                    cnn.Close();
                    
                    // ------------------------------------------
                    
                    sql = "update configuraciones set " +
                    "nombres = '" + txtNombres.Text + "', " ;

                    if(txtNuevaPass.Text.Trim().Length>0)
                        if (txtNuevaPass.Text.Trim() == txtRepetirNuevaPass.Text.Trim())
                        {
                            cmd.Parameters.AddWithValue("paswd", txtNuevaPass.Text);
                            actualizarDatos(sql);
                            cargarRangos();
                            btnEditarPass.Text = "Editar";
                            btnEditarPass.ImageIndex = 2;
                            opcionesUsuario(false);
                        }
                        else
                        {
                            lblErrorPass.Text = "*Las contraseñas no coinciden";
                            lblErrorPass.Location = new Point(400, 171);
                            lblErrorPass.Visible = true;
                        }
                    else
                    {
                        cmd.Parameters.AddWithValue("paswd", txtPass.Text);
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
                    lblErrorPass.Location = new Point(400, 135);
                    lblErrorPass.Visible = true;
                }
                
            }
        }

        //Metodo para habilitar o dehabilitar opciones del bonon editar usuario
        private void opcionesUsuario(bool op) {
            label21.Visible = op;
            label22.Visible = op;
            txtNombres.Enabled = op;
            txtTelefono.Enabled = op;
            txtPass.Enabled = op;
            txtNuevaPass.Enabled = op;
            txtNuevaPass.Visible = op;
            txtRepetirNuevaPass.Enabled = op;
            txtRepetirNuevaPass.Visible = op;
            btnCancelarPass.Visible = op;
        }

        private void opcionesUsuarios(bool op)
        {
            panelUsuarios.Visible = op;
            txtNewCedula.Text = "";
            txtNewNombre.Text = "";
            txtNewTelefono.Text = "";
            txtNewClave.Text = "";
            cbNewRol.SelectedIndex = 1;
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
                MySqlCommand cmd = new MySqlCommand("SpUpdateRubros", conn);
                conn.Open();
                //id_rub int, nombre varchar(100), in valor decimal(10,2),in obser
                //cmd.Parameters.AddWithValue("id_rub", cod);
                //cmd.Parameters.AddWithValue("nombre", cod);
                //cmd.Parameters.AddWithValue("valor", cod);
                //cmd.Parameters.AddWithValue("obser", cod);
                
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
                    lblSiguienteFactura.ForeColor = Color.Black;
                    lblSiguienteFactura.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
                    lblSiguienteRecibo.ForeColor = Color.Black;
                    lblSiguienteRecibo.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
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
            lblSiguienteFactura.ForeColor = Color.Black;
            lblSiguienteFactura.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
            lblSiguienteRecibo.ForeColor = Color.Black;
            lblSiguienteRecibo.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
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
                txtPass.Text.Trim().Equals("") &&
                txtTelefono.Text.Trim().Equals("") &&
                txtNuevaPass.Text.Trim().Equals("") &&
                txtRepetirNuevaPass.Text.Trim().Equals(""))

                btnEditarPass.Enabled = false;
            else
                btnEditarPass.Enabled = true;
        }

      
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void opcionesRubros(bool op)
        {
            lblNombreRubro.Visible = op;
            lblValorRubro.Visible = op;
            lblObservacionRubro.Visible = op;
            txtNombre.Visible = op;
            txtValor.Visible = op;
            txtObservacion.Visible = op;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevoRubro.Text.Equals("         Nuevo"))
                {
                    opcionesRubros(true);
                    txtNombre.Text = "";
                    txtValor.Text = "";
                    txtObservacion.Text = "";
                    btnModificarRubros.Enabled = false;
                    btnEliminarRubro.Text = "Cancelar";
                    btnEliminarRubro.ImageIndex = 4;
                    btnNuevoRubro.Text = "         Guardar";
                    btnNuevoRubro.ImageIndex = 0;
                     
                    
                }
                else {
                    if (!txtNombre.Text.Trim().Equals("") &&
                        !txtValor.Text.Trim().Equals("") &&
                        !txtObservacion.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpInsertRubros", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("valor", txtValor.Text.Trim());
                        cmd.Parameters.AddWithValue("obser", txtObservacion.Text.Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > -1)
                        {
                            MessageBox.Show("Se ingresó el rubro correctamente");
                            opcionesRubros(false);
                            cargarRubros();
                            btnNuevoRubro.Text = "         Nuevo";
                            btnNuevoRubro.ImageIndex = 1;
                            btnEliminarRubro.Text = "Eliminar";
                            btnEliminarRubro.ImageIndex = 3;
                            btnModificarRubros.Enabled = true;
                            
                        }
                        else {
                            MessageBox.Show("No se pudo ingresar el rubro");
                        }
                    }
                    else {
                        MessageBox.Show("Por favor complete los campos");
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            };

        }

        private void tpPerfil_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModificarRubros.Text.Equals("Modificar"))
                {
                    if (!txtCedula.Equals(""))
                    {
                        txtNombre.Text = dgvRubros[1, 0].Value.ToString();
                        txtValor.Text = dgvRubros[2, 0].Value.ToString();
                        txtObservacion.Text = dgvRubros[3, 0].Value.ToString();
                    }

                    panelRubros.Visible = true;
                    btnNuevoRubro.Enabled = false;
                    btnEliminarRubro.Text = "Cancelar";
                    btnEliminarRubro.ImageIndex = 4;
                    btnModificarRubros.Text = "Guardar";
                    btnModificarRubros.ImageIndex = 0;
                }
                else
                {
                    if (!txtNewCedula.Text.Trim().Equals("") &&
                            !txtNewNombre.Text.Trim().Equals("") &&
                            !txtNewTelefono.Text.Trim().Equals("") &&
                            !txtNewClave.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpUpdateRubros", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        //id_rub int, nombre varchar(100), in valor decimal(10,2),in obser
                        cmd.Parameters.AddWithValue("id_rub", label16.Text.Trim());
                        cmd.Parameters.AddWithValue("nombre", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("valor", txtValor.Text.Trim());
                        cmd.Parameters.AddWithValue("obser", txtObservacion.Text.Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > -1)
                        {
                            MessageBox.Show("Se actualizó la infomación del usuario.");
                            //opcionesUsuarios(false);
                            cargarRubros();
                            btnModificarRubros.Text = "Modificar";
                            btnModificarRubros.ImageIndex = 2;
                            btnEliminarRubro.Text = "Eliminar";
                            btnEliminarRubro.ImageIndex = 3;
                            //btnNuevoUsuario.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("No se pudo cambiar la información");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor complete los campos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
            
        }

        private void btnEliminarRubro_Click(object sender, EventArgs e)
        {
            if (btnEliminarRubro.Text.Equals("Cancelar"))
            {
                opcionesRubros(false);
                btnModificarRubros.Enabled = true;
                btnNuevoRubro.Text = "         Nuevo";
                btnEliminarRubro.Text = "Eliminar";
            }
            else {
                if (dgvRubros.SelectedRows.Count > 0)
                {
                    string sql = "select cod_rubro from detalles where cod_rubro=" + label16.Text;
                    DataTable dtr = metodo.consultarDatos(sql);
                    int aux = dtr.Rows.Count;
                    //MessageBox.Show(aux.ToString() + label16.Text);
                    if (aux < 1)
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpDeleteRubros", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("id_rub", label16.Text);
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > -1)
                        {
                            MessageBox.Show("Se eliminó el rubro correctamente");
                            cargarRubros();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el rubro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El rubro está asociado a uno o más pagos, no se puede eliminar");
                    }
                }
            }
        }

        #region Rangos
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
            if (factRestantes <= 0)
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
            int val = Convert.ToInt32(txtReDesde.Text.Trim());
            int val2;
            if (txtReHasta.Text.Trim().Equals(""))
            {
                txtReHasta.Text = "1"; val2 = 1;
            }
            else
            {
                val2 = Convert.ToInt32(txtReHasta.Text.Trim());
                if (val2 < 0)
                {
                    txtReHasta.Text = "1"; val2 = 1;
                }
            }
            recibRestantes = val2 - val + 1;
            lblRecibosRestantes.Text = "Ahora quedan " + recibRestantes + " recibos";
            if (recibRestantes < 0)
                lblRecibosRestantes.ForeColor = Color.IndianRed;
            else
                lblRecibosRestantes.ForeColor = Color.DarkCyan;
        }


        private void txtFaDesde_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int val2 = Convert.ToInt32(txtFaHasta.Text.Trim());
                int val;
                if (txtFaDesde.Text.Trim().Equals(""))
                {
                    txtFaDesde.Text = "1"; val = 1;
                }
                else
                {
                    val = Convert.ToInt32(txtFaDesde.Text.Trim());
                    if (val < 0)
                    {
                        txtFaDesde.Text = "1"; val = 1;
                    }
                }
                lblSiguienteFactura.Text = val.ToString();
                lblSiguienteFactura.ForeColor = Color.DarkCyan;
                lblSiguienteFactura.Font = new Font(lblSiguienteFactura.Font, FontStyle.Bold);
                factRestantes = val2 - val + 1;
                lblFacturasRestantes.Text = "Ahora quedan " + factRestantes + " facturas";
                if (factRestantes <= 0)
                    lblFacturasRestantes.ForeColor = Color.IndianRed;
                else
                    lblFacturasRestantes.ForeColor = Color.DarkCyan;

            }
        }

        private void txtFaHasta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int val = Convert.ToInt32(txtFaDesde.Text.Trim());
                int val2;
                if (txtFaHasta.Text.Trim().Equals(""))
                {
                    txtFaHasta.Text = "1"; val2 = 1;
                }
                else
                {
                    val2 = Convert.ToInt32(txtFaHasta.Text.Trim());
                    if (val2 < 0)
                    {
                        txtFaHasta.Text = "1"; val2 = 1;
                    }
                }
                factRestantes = val2 - val + 1;
                lblFacturasRestantes.Text = "Ahora quedan " + factRestantes + " facturas";
                if (factRestantes < 0)
                    lblFacturasRestantes.ForeColor = Color.IndianRed;
                else
                    lblFacturasRestantes.ForeColor = Color.DarkCyan;
            }
        }

        private void txtReDesde_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
        }

        private void tpUsuarios_Click(object sender, EventArgs e)
        {

        }



        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevoUsuario.Text.Equals("         Nuevo"))
                {
                    opcionesUsuarios(true);
                    btnModificarUsuarios.Enabled = false;
                    btnEliminarUsuarios.Text = "Cancelar";
                    btnEliminarUsuarios.ImageIndex = 4;
                    btnNuevoUsuario.Text = "         Guardar";
                    btnNuevoUsuario.ImageIndex = 1;
                    
                }
                else
                {
                    if (!txtNewCedula.Text.Trim().Equals("") &&
                        !txtNewNombre.Text.Trim().Equals("") &&
                        !txtNewTelefono.Text.Trim().Equals("") &&
                        !txtNewClave.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpInsert_Usuarios", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        //ced char(10),in nombres varchar(100), in tel_cel varchar(10), in paswd varchar(250), in roles
                        cmd.Parameters.AddWithValue("ced", txtNewCedula.Text.Trim());
                        cmd.Parameters.AddWithValue("nombres", txtNewNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("tel_cel", txtNewTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("paswd", txtNewClave.Text.Trim());
                        cmd.Parameters.AddWithValue("roles", cbNewRol.SelectedItem.ToString().Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > -1)
                        {
                            MessageBox.Show("Se agregó el usuario correctamente");
                            opcionesUsuarios(false);
                            cargarUsuarios();
                            btnNuevoUsuario.Text = "         Nuevo";
                            btnNuevoUsuario.ImageIndex = 1;
                            btnEliminarUsuarios.Text = "Eliminar";
                            btnEliminarUsuarios.ImageIndex = 3;
                            btnModificarUsuarios.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("No se pudo ingresar el Usuario");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor complete los campos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnModificarUsuarios_Click(object sender, EventArgs e)
        {
            //opcionesUsuarios(true);
            try
            {
                if (btnModificarUsuarios.Text.Equals("Modificar"))
                {
                    if (!txtCedula.Equals("")) {
                        txtNewCedula.Text = dgvUsuarios[0, 0].Value.ToString();
                        txtNewNombre.Text = dgvUsuarios[1, 0].Value.ToString();
                        txtNewTelefono.Text = dgvUsuarios[2, 0].Value.ToString();

                        string rol = dgvUsuarios[4, 0].Value.ToString();
                        if (rol.Equals("Administrador"))
                            cbNewRol.SelectedIndex = 0;
                        else
                            cbNewRol.SelectedIndex = 1;
                    }

                    panelUsuarios.Visible = true;
                    btnNuevoUsuario.Enabled = false;
                    btnEliminarUsuarios.Text = "Cancelar";
                    btnEliminarUsuarios.ImageIndex = 4;
                    btnModificarUsuarios.Text = "Guardar";
                    btnModificarUsuarios.ImageIndex = 0;
                    txtNewCedula.Enabled = false;

                }
                else
                {
                if (!txtNewCedula.Text.Trim().Equals("") &&
                        !txtNewNombre.Text.Trim().Equals("") &&
                        !txtNewTelefono.Text.Trim().Equals("") &&
                        !txtNewClave.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpUpdate_Usuarios", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        //ced char(10),in nombres varchar(100), in tel_cel varchar(10), in paswd varchar(250), in roles
                        cmd.Parameters.AddWithValue("ced", txtNewCedula.Text);
                        cmd.Parameters.AddWithValue("nombres", txtNewNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("tel_cel", txtNewTelefono.Text.Trim());
                        cmd.Parameters.AddWithValue("paswd", txtNewClave.Text.Trim());
                        cmd.Parameters.AddWithValue("roles", cbNewRol.SelectedItem.ToString().Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > -1)
                        {
                            MessageBox.Show("Se actualizó la infomación del usuario.");
                            opcionesUsuarios(false);
                            cargarUsuarios();
                            btnModificarUsuarios.Text = "Modificar";
                            btnModificarUsuarios.ImageIndex = 2;
                            btnEliminarUsuarios.Text = "Eliminar";
                            btnEliminarUsuarios.ImageIndex = 3;
                            btnNuevoUsuario.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("No se pudo cambiar la información");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor complete los campos");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNewCedula.Text = dgvUsuarios[0, dgvUsuarios.CurrentRow.Index].Value.ToString();
            txtNewNombre.Text = dgvUsuarios[1, dgvUsuarios.CurrentRow.Index].Value.ToString();
            txtNewTelefono.Text = dgvUsuarios[2, dgvUsuarios.CurrentRow.Index].Value.ToString();
            
            string  rol = dgvUsuarios[4, dgvUsuarios.CurrentRow.Index].Value.ToString();
            if (rol.Equals("Administrador"))
                cbNewRol.SelectedIndex = 0;
            else
                cbNewRol.SelectedIndex = 1;


        }

        private void txtNombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEliminarUsuarios.Text.Equals("Eliminar"))
                {
                    if (!txtCedula.Equals("")){
                        txtNewCedula.Text = dgvUsuarios[0, 0].Value.ToString();
                    }
                    
                        string sql = "select id_user from pagos where id_user='" + txtCedula.Text + "'";
                        DataTable dtt = metodo.consultarDatos(sql);
                        int aux = dtt.Rows.Count;
                        if (aux < 0) {
                            MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                            MySqlCommand cmd = new MySqlCommand("SpDelete_Usuarios", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Open();
                            //ced char(10),in nombres varchar(100), in tel_cel varchar(10), in paswd varchar(250), in roles
                            cmd.Parameters.AddWithValue("ced", txtNewCedula.Text);
                            int result = cmd.ExecuteNonQuery();
                            conn.Close();
                            if (result > -1)
                            {
                                MessageBox.Show("Usuario eliminado");
                                opcionesUsuarios(false);
                                cargarUsuarios();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el usuario");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario tiene registros asociados. No se puede eliminar");
                        }
                    //}
                }
                else
                {
                    opcionesUsuarios(false);
                    btnNuevoUsuario.Enabled = true;
                    btnNuevoUsuario.ImageIndex = 1;
                    btnModificarUsuarios.Enabled = true;
                    btnModificarUsuarios.ImageIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void dgvRubros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label16.Text = dgvRubros[0, dgvRubros.CurrentRow.Index].Value.ToString();
            txtNombre.Text = dgvRubros[1, dgvRubros.CurrentRow.Index].Value.ToString();
            txtValor.Text = dgvRubros[2, dgvRubros.CurrentRow.Index].Value.ToString();
            txtObservacion.Text = dgvRubros[3, dgvRubros.CurrentRow.Index].Value.ToString();
            
        }

        private void txtReHasta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int val = Convert.ToInt32(txtReDesde.Text.Trim());
                int val2;
                if (txtReHasta.Text.Trim().Equals(""))
                {
                    txtReHasta.Text = "1"; val2 = 1;
                }
                else
                {
                    val2 = Convert.ToInt32(txtReHasta.Text.Trim());
                    if (val2 < 0)
                    {
                        txtReHasta.Text = "1"; val2 = 1;
                    }
                }
                recibRestantes  = val2 - val + 1;
                lblRecibosRestantes.Text = "Ahora quedan " + recibRestantes + " recibos";
                if (recibRestantes < 0)
                    lblRecibosRestantes.ForeColor = Color.IndianRed;
                else
                    lblRecibosRestantes.ForeColor = Color.DarkCyan;
            }
        }

        #endregion


    }
}
