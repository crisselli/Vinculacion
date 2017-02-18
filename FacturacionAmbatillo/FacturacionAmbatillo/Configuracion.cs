using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionAmbatillo
{
    public partial class Configuracion : Form
    {
        
        public Configuracion(string user, string pass)
        {
            InitializeComponent();
            cargarUsuario(user);
            cargarRangos();
            cargarRubros();
            cargarBarrios();
            cargarCategorias();
            clave = pass;
            cedUser = user;
        }

        Conexion conexion = new Conexion();
        MetodosGenerales metodo = new MetodosGenerales();
        ConfigUsuarios cUsu = new ConfigUsuarios();
        Principal pr = new Principal();

        string cedUser;
        string nombre;
        string clave;
        string sql;
        string rol = "";
        private int[] auxDatosRangos;
        private int factRestantes, recibRestantes;


        #region Cargar Datos
        private void cargarUsuarios()
        {
            metodo.llenarGridSP(dgvUsuarios, "SpSelect_Usuarios");
            dgvUsuarios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvUsuarios.Columns[3].Visible = false;
        }

        private void cargarUsuario(string user)
        {
            sql = "select ced, nombres, tel_cel, roles from Usuarios where ced = '" + user + "';";
            DataTable dataTable = metodo.consultarDatos(sql);

            txtCedula.Text = dataTable.Rows[0][0].ToString();
            txtNombrePerfil.Text = dataTable.Rows[0][1].ToString();
            txtTelefono.Text = dataTable.Rows[0][2].ToString();
            rol = dataTable.Rows[0][3].ToString();

            if (!rol.Equals("Administrador"))
            {
                tabControl2.TabPages.Remove(tpUsuarios);
                btnEditarValores.Visible = false;
            }
            else
                cargarUsuarios();

        }

        private void cargarRubros()
        {
            metodo.llenarGridSP(dgvRubros, "SpSelectRubros");
            dgvRubros.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRubros.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRubros.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
        }

        private void cargarRangos()
        {
            try
            {
                //sql = "select fact_desde, fact_hasta, recib_desde, recib_hasta from configuraciones;";
                DataTable dataTable = metodo.consultarDatosSP("SpSelectconfiguraciones");
                //lblErroreses.Text = dataTable.Rows[0][0].ToString() ;
                txtFaDesde.Text = dataTable.Rows[0][1].ToString();
                txtFaHasta.Text = dataTable.Rows[0][2].ToString();
                txtReDesde.Text = dataTable.Rows[0][3].ToString();
                txtReHasta.Text = dataTable.Rows[0][4].ToString();
                lblSiguienteFactura.Text = dataTable.Rows[0][1].ToString();
                lblSiguienteRecibo.Text = dataTable.Rows[0][3].ToString();
                int desde, hasta;

                desde = Convert.ToInt32(dataTable.Rows[0][1].ToString());
                hasta = Convert.ToInt32(dataTable.Rows[0][2].ToString());
                lblFacturasRestantes.Text = "Quedan " + (hasta - desde + 1).ToString() + " facturas";

                desde = Convert.ToInt32(dataTable.Rows[0][3].ToString());
                hasta = Convert.ToInt32(dataTable.Rows[0][4].ToString());
                lblRecibosRestantes.Text = "Quedan " +(hasta - desde + 1).ToString() + " recibos";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void cargarBarrios()
        {
            metodo.llenarGridSP(dgvBarrios, "SpSelectBarrios");
            dgvBarrios.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
             
        }

        private void cargarCategorias()
        {
            //sql = "select Codigo ID, Nombre, rango_min Desde, rango_max Hasta, Valor from categorias;";
            metodo.llenarGridSP(dgvCategorias, "SpSelectCategorias");
            dgvCategorias.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCategorias.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCategorias.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCategorias.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }
        
        #endregion
        

        #region Tab Usuarios
        // Proecdimiento para crear un usuario
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
                    btnNuevoUsuario.ImageIndex = 0;

                }
                else
                {
                    if (!txtNewCedula.Text.Trim().Equals("") &&
                        !txtNewNombre.Text.Trim().Equals("") &&
                        !txtNewTelefono.Text.Trim().Equals("") &&
                        !txtNewClave.Text.Trim().Equals(""))
                    {
                        cUsu.Ced = txtNewCedula.Text.Trim();
                        cUsu.Nombres = txtNewNombre.Text.Trim();
                        cUsu.Tel_cel = txtNewTelefono.Text.Trim();
                        cUsu.Paswd = txtNewClave.Text.Trim();
                        cUsu.Roles = cbNewRol.SelectedItem.ToString().Trim();

                        int result = cUsu.ingresarUsuario();

                        if (result > 0)
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

        // Proceso para editar y modificar los datos de un usario existente
        private void btnModificarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModificarUsuarios.Text.Equals("Modificar"))
                {
                    if (txtCedula.Equals(""))
                    {
                        txtNewCedula.Text = dgvUsuarios[0, 0].Value.ToString();
                        txtNewNombre.Text = dgvUsuarios[1, 0].Value.ToString();
                        txtNewTelefono.Text = dgvUsuarios[2, 0].Value.ToString();

                        string rol = dgvUsuarios[4, 0].Value.ToString();
                        if (rol.Equals("Administrador"))
                            cbNewRol.SelectedIndex = 0;
                        else
                            cbNewRol.SelectedIndex = 1;
                    }

                    txtNewCedula.Enabled = false;
                    panelUsuarios.Visible = true;
                    btnNuevoUsuario.Enabled = false;
                    btnEliminarUsuarios.Text = "Cancelar";
                    btnEliminarUsuarios.ImageIndex = 4;
                    btnModificarUsuarios.Text = "Guardar";
                    btnModificarUsuarios.ImageIndex = 0;

                }
                else
                {
                    if (!txtNewCedula.Text.Trim().Equals("") &&
                            !txtNewNombre.Text.Trim().Equals("") &&
                            !txtNewTelefono.Text.Trim().Equals(""))
                    {
                        int result = 0;
                        cUsu.Ced = txtNewCedula.Text.Trim();
                        cUsu.Nombres = txtNewNombre.Text.Trim();
                        cUsu.Tel_cel = txtNewTelefono.Text.Trim();
                        cUsu.Roles = cbNewRol.SelectedItem.ToString().Trim();

                        if (!txtNewClave.Text.Trim().Equals(""))
                        {
                            cUsu.Paswd = txtNewClave.Text.Trim();
                            result = cUsu.modificarUsuarioPw();
                        }
                        else
                            result = cUsu.modificarUsuario();

                        if (result > 0)
                        {
                            MessageBox.Show("Se actualizó la infomación del usuario.");
                            opcionesUsuarios(false);
                            cargarUsuarios();
                            btnModificarUsuarios.Text = "Modificar";
                            btnModificarUsuarios.ImageIndex = 2;
                            btnEliminarUsuarios.Text = "Eliminar";
                            btnEliminarUsuarios.ImageIndex = 3;
                            btnNuevoUsuario.Enabled = true;
                            txtNewCedula.Enabled = true;

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

        // Cargar los datos de una fila seleccionada en los campos de Usuarios
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNewCedula.Text = dgvUsuarios[0, dgvUsuarios.CurrentRow.Index].Value.ToString();
            txtNewNombre.Text = dgvUsuarios[1, dgvUsuarios.CurrentRow.Index].Value.ToString();
            txtNewTelefono.Text = dgvUsuarios[2, dgvUsuarios.CurrentRow.Index].Value.ToString();

            string rol = dgvUsuarios[4, dgvUsuarios.CurrentRow.Index].Value.ToString();
            if (rol.Equals("Administrador"))
                cbNewRol.SelectedIndex = 0;
            else
                cbNewRol.SelectedIndex = 1;


        }

        // Proceso para eliminar un usuario existente
        private void btnEliminarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEliminarUsuarios.Text.Equals("Eliminar"))
                {
                    if (txtCedula.Equals(""))
                    {
                        txtNewCedula.Text = dgvUsuarios[0, 0].Value.ToString();
                    }

                    sql = "select id_user from pagos where id_user='" + txtNewCedula.Text + "'";
                    DataTable dtt = metodo.consultarDatos(sql);
                    int aux = dtt.Rows.Count;
                    if (aux < 1)
                    {

                        cUsu.Ced = txtNewCedula.Text.Trim();
                        int result = cUsu.eliminarUsuario();
                        if (result > 0)
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
                }
                else
                {
                    opcionesUsuarios(false);
                    btnNuevoUsuario.Enabled = true;
                    btnNuevoUsuario.Text = "         Nuevo";
                    btnNuevoUsuario.ImageIndex = 1;
                    btnModificarUsuarios.Enabled = true;
                    btnModificarUsuarios.Text = "Modificar";
                    btnModificarUsuarios.ImageIndex = 2;
                    btnEliminarUsuarios.Text = "Eliminar";
                    btnEliminarUsuarios.ImageIndex = 3;
                    txtNewCedula.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        #endregion

        #region Tab Perfil

        private void btnEditarPass_Click(object sender, EventArgs e)
        {
            lblErrorPass.Visible = false;
            if (btnEditarPass.Text.Equals("Editar")) //Opción Editar Usuario
            {
                txtNombrePerfil.Enabled = true;
                btnCancelarPass.Visible = true;
                //Cargar los datos de usuario en una variable temporal para comprobar
                nombre = txtNombrePerfil.Text;
                //Limpiar campos de contraseña
                txtPass.Text = "";
                txtNuevaPass.Text = "";
                txtRepetirNuevaPass.Text = "";
                //Cambiar apariencia del boton editar
                btnEditarPass.Text = "Guardar";
                btnEditarPass.Enabled = false;
                btnEditarPass.ImageIndex = 0;
                //opcionesUsuario(true);
                panelUsuario.Visible = true;
                lblErrorPass.Visible = false;
                
            }
            else //Opción Guardar Usuario
            {
                if (!txtCedula.Text.Trim().Equals("") &&
                        !txtNombrePerfil.Text.Trim().Equals("") &&
                        !txtTelefono.Text.Trim().Equals("") &&
                        !txtPass.Text.Trim().Equals(""))
                {
                    cUsu.Ced = txtCedula.Text.Trim();
                    cUsu.Nombres = txtNombrePerfil.Text.Trim();
                    cUsu.Tel_cel = txtTelefono.Text.Trim();
                    cUsu.Roles = rol;

                    if (txtNuevaPass.Text.Trim() == txtRepetirNuevaPass.Text.Trim()) {
                        if (txtNuevaPass.Text.Trim().Length > 0)
                            cUsu.Paswd = txtNuevaPass.Text.Trim();
                        else
                            cUsu.Paswd = txtPass.Text.Trim();

                        if (clave.Equals(txtPass.Text.Trim())) {

                            int result = cUsu.modificarUsuario();

                            if (result > 0)
                            {
                                MessageBox.Show("Se actualizó la información correctamente");
                                panelUsuario.Visible = false;
                                btnEditarPass.Text = "Editar";
                                btnEditarPass.ImageIndex = 2;
                                btnCancelarPass.Visible = false;
                                txtNombrePerfil.Enabled = false;
                                cargarUsuario(cedUser);
                                clave = cUsu.Paswd;
                                if (rol.Equals("Administrador"))
                                    cargarUsuarios();
                                Principal pr = new Principal();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar la información");
                            }
                        }
                        else
                        {
                            lblErrorPass.Text = "*Su contraseña es incorrecta";
                            lblErrorPass.Location = new Point(390, 40);
                            lblErrorPass.Visible = true;
                        }

                    }
                    else
                    {
                        lblErrorPass.Text = "*Las contraseñas no coinciden";
                        lblErrorPass.Location = new Point(390, 80);
                        lblErrorPass.Visible = true;
                    }

                }
                else
                {
                    MessageBox.Show("Por favor complete los campos");
                }
            }
        }

        private void btnCancelarPass_Click(object sender, EventArgs e)
        {
            btnEditarPass.Text = "Editar";
            btnEditarPass.ImageIndex = 2;
            lblErrorPass.Visible = false;
            panelUsuario.Visible = false;
            txtNombrePerfil.Enabled = false;
            btnEditarPass.Enabled = true;
            btnCancelarPass.Visible = false;
        }

        // Comprobar si los datos han cambiado 
        private void txtNombreCompleto_KeyUp(object sender, KeyEventArgs e)
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
        private void comprobarDatosUsuario()
        {
            if (txtNombrePerfil.Text.Equals(nombre) &&
                txtPass.Text.Trim().Equals("") &&
                txtTelefono.Text.Trim().Equals("") &&
                txtNuevaPass.Text.Trim().Equals("") &&
                txtRepetirNuevaPass.Text.Trim().Equals(""))

                btnEditarPass.Enabled = false;
            else
                btnEditarPass.Enabled = true;
        }

        #endregion

        #region Tab Rubros

        // Proceso del botón Nuevo Rubro
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevoRubro.Text.Equals("         Nuevo"))
                {
                    opcionesRubros(true);
                    btnModificarRubros.Enabled = false;
                    btnEliminarRubro.Text = "Cancelar";
                    btnEliminarRubro.ImageIndex = 4;
                    btnNuevoRubro.Text = "         Guardar";
                    btnNuevoRubro.ImageIndex = 0;

                }
                else
                {
                    if (!txtNombreRubro.Text.Trim().Equals("") &&
                        !txtValorRubro.Text.Trim().Equals("") &&
                        !txtObservacion.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpInsertRubros", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("nombre", txtNombreRubro.Text.Trim());
                        cmd.Parameters.AddWithValue("valor", txtValorRubro.Text.Trim());
                        cmd.Parameters.AddWithValue("obser", txtObservacion.Text.Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > 0)
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
                        else
                        {
                            MessageBox.Show("No se pudo ingresar el rubro");
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

        // Proceso del botón Modificar Rubro
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModificarRubros.Text.Equals("Modificar"))
                {
                    if (lblCodRubro.Equals(""))
                    {
                        lblCodRubro.Text = dgvRubros[0, 0].Value.ToString();
                        txtNombreRubro.Text = dgvRubros[1, 0].Value.ToString();
                        txtValorRubro.Text = dgvRubros[2, 0].Value.ToString();
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
                    if (!txtNombreRubro.Text.Trim().Equals("") &&
                        !txtValorRubro.Text.Trim().Equals("") &&
                        !txtObservacion.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpUpdateRubros", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        //id_rub int, nombre varchar(100), in valor decimal(10,2),in obser
                        cmd.Parameters.AddWithValue("id_rub", lblCodRubro.Text.Trim());
                        cmd.Parameters.AddWithValue("nombre", txtNombreRubro.Text.Trim());
                        cmd.Parameters.AddWithValue("valor", txtValorRubro.Text.Trim());
                        cmd.Parameters.AddWithValue("obser", txtObservacion.Text.Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Se actualizó la infomación del rubro.");
                            opcionesRubros(false);
                            cargarRubros();
                            btnModificarRubros.Text = "Modificar";
                            btnModificarRubros.ImageIndex = 2;
                            btnEliminarRubro.Text = "Eliminar";
                            btnEliminarRubro.ImageIndex = 3;
                            btnNuevoRubro.Enabled = true;

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

        // Proceso del botón Eliminar Rubro
        private void btnEliminarRubro_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEliminarRubro.Text.Equals("Eliminar"))
                {
                    if (lblCodRubro.Text.Equals(""))
                    {
                        lblCodRubro.Text = dgvRubros[0, 0].Value.ToString();
                    }

                    sql = "select cod_rubro from detalles where cod_rubro=" + lblCodRubro.Text;
                    DataTable dtt = metodo.consultarDatos(sql);
                    int aux = dtt.Rows.Count;
                    if (aux < 1)
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpDeleteRubros", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("id_rub", lblCodRubro.Text);
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Se eliminó el rubro correctamente");
                            cargarRubros();
                            opcionesRubros(false);
                            lblCodRubro.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el rubro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El rubro está asociado a pagos. No se puede eliminar");
                    }
                }
                else
                {
                    opcionesRubros(false);
                    btnNuevoRubro.Enabled = true;
                    btnNuevoRubro.Text = "         Nuevo";
                    btnNuevoRubro.ImageIndex = 1;
                    btnModificarRubros.Enabled = true;
                    btnModificarRubros.Text = "Modificar";
                    btnModificarRubros.ImageIndex = 2;
                    btnEliminarRubro.Text = "Eliminar";
                    btnEliminarRubro.ImageIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        // Llenar compos de panel rubros al seleccionar una fila del datagridview
        private void dgvRubros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCodRubro.Text = dgvRubros[0, dgvRubros.CurrentRow.Index].Value.ToString();
            txtNombreRubro.Text = dgvRubros[1, dgvRubros.CurrentRow.Index].Value.ToString();
            txtValorRubro.Text = dgvRubros[2, dgvRubros.CurrentRow.Index].Value.ToString().Replace(",", ".");
            txtObservacion.Text = dgvRubros[3, dgvRubros.CurrentRow.Index].Value.ToString();

        }

        #endregion

        #region Tab Barrios

        // Proceso del botón Nuevo Barrio
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnNuevoBarrio.Text.Equals("         Nuevo"))
                {
                    panelBarrios.Visible = true;
                    txtNombreBarrio.Text = "";
                    btnModificarBarrio.Enabled = false;
                    btnEliminarBarrio.Text = "Cancelar";
                    btnEliminarBarrio.ImageIndex = 4;
                    btnNuevoBarrio.Text = "         Guardar";
                    btnNuevoBarrio.ImageIndex = 0;

                }
                else
                {
                    if (!txtNombreBarrio.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpInsertBarrios", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("nombre", txtNombreBarrio.Text.Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Se ingresó el barrio correctamente");
                            panelBarrios.Visible = false;
                            txtNombreBarrio.Text = "";
                            cargarBarrios();
                            btnNuevoBarrio.Text = "         Nuevo";
                            btnNuevoBarrio.ImageIndex = 1;
                            btnEliminarBarrio.Text = "Eliminar";
                            btnEliminarBarrio.ImageIndex = 3;
                            btnModificarBarrio.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("No se pudo ingresar el barrio");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un nombre de barrio");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        // Proceso del botón Modificar Barrio
        private void btnModificarBarrio_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModificarBarrio.Text.Equals("Modificar"))
                {
                    if (lblCodBarrio.Text.Equals(""))
                    {
                        lblCodBarrio.Text = dgvBarrios[0, 0].Value.ToString();
                        txtNombreBarrio.Text = dgvBarrios[1, 0].Value.ToString();
                    }

                    panelBarrios.Visible = true;
                    btnNuevoBarrio.Enabled = false;
                    btnEliminarBarrio.Text = "Cancelar";
                    btnEliminarBarrio.ImageIndex = 4;
                    btnModificarBarrio.Text = "Guardar";
                    btnModificarBarrio.ImageIndex = 0;
                }
                else
                {
                    if (!txtNombreBarrio.Text.Trim().Equals(""))
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpUpdateBarrios", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        //id char(3), in nombre
                        cmd.Parameters.AddWithValue("id", lblCodBarrio.Text.Trim());
                        cmd.Parameters.AddWithValue("nombre", txtNombreBarrio.Text.Trim());

                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Se actualizó la infomación del barrio.");
                            panelBarrios.Visible = false;
                            txtNombreBarrio.Text = "";
                            cargarBarrios();
                            btnModificarBarrio.Text = "Modificar";
                            btnModificarBarrio.ImageIndex = 2;
                            btnEliminarBarrio.Text = "Eliminar";
                            btnEliminarBarrio.ImageIndex = 3;
                            btnNuevoBarrio.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("No se pudo cambiar la información");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese un nombre de barrio");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        //Proceso del botón Eliminar Barrio
        private void btnEliminarBarrio_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEliminarBarrio.Text.Equals("Eliminar"))
                {
                    if (lblCodBarrio.Text.Equals(""))
                    {
                        lblCodBarrio.Text = dgvBarrios[0, 0].Value.ToString();
                    }

                    sql = "select barrio_id from medidores where barrio_id='" + lblCodBarrio.Text + "';";
                    DataTable dtt = metodo.consultarDatos(sql);
                    int aux = dtt.Rows.Count;
                    if (aux < 1)
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpDeleteBarrios", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("id", lblCodBarrio.Text);
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Se eliminó el barrio correctamente");
                            cargarBarrios();
                            panelBarrios.Visible = false;
                            txtNombreBarrio.Text = "";
                            lblCodBarrio.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el barrio");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El barrio tiene medidores registrados. No se puede eliminar");
                    }
                }
                else
                {
                    panelBarrios.Visible = false;
                    txtNombreBarrio.Text = "";
                    btnNuevoBarrio.Enabled = true;
                    btnNuevoBarrio.Text = "         Nuevo";
                    btnNuevoBarrio.ImageIndex = 1;
                    btnModificarBarrio.Enabled = true;
                    btnModificarBarrio.Text = "Modificar";
                    btnModificarBarrio.ImageIndex = 2;
                    btnEliminarBarrio.Text = "Eliminar";
                    btnEliminarBarrio.ImageIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        // Cargar datos en campos del panel Barrios
        private void dgvBarrios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCodBarrio.Text = dgvBarrios[0, dgvBarrios.CurrentRow.Index].Value.ToString();
            txtNombreBarrio.Text = dgvBarrios[1, dgvBarrios.CurrentRow.Index].Value.ToString();
        }

        #endregion

        #region Tab Pagos

        private void btnEditarValores_Click_1(object sender, EventArgs e)
        {
            lblErrorPass.Visible = false;
            if (btnEditarValores.Text.Equals("Modificar")) //Opción Editar Valores
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
                    MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                    MySqlCommand cmd = new MySqlCommand("SpUpdateConfiguraciones", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    //fact_desde int,in fact_hasta int, in recib_desde int , in recib_hasta
                    cmd.Parameters.AddWithValue("fact_desde", txtFaDesde.Text.Trim());
                    cmd.Parameters.AddWithValue("fact_hasta", txtFaHasta.Text.Trim());
                    cmd.Parameters.AddWithValue("recib_desde", txtReDesde.Text.Trim());
                    cmd.Parameters.AddWithValue("recib_hasta", txtReHasta.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (result > 0)
                    {
                        MessageBox.Show("Se actualizó la infomación correctamente.");
                        cargarRangos();
                        btnEditarValores.Text = "Modificar";
                        btnEditarValores.ImageIndex = 2;
                        lblErrorValores.Visible = false;
                        opcionesValores(false);
                        lblSiguienteFactura.ForeColor = Color.Black;
                        lblSiguienteFactura.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
                        lblSiguienteRecibo.ForeColor = Color.Black;
                        lblSiguienteRecibo.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
                        lblFacturasRestantes.ForeColor = Color.Black;
                        lblFacturasRestantes.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
                        lblRecibosRestantes.ForeColor = Color.Black;
                        lblRecibosRestantes.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cambiar la información");
                    }

                }
                else
                {
                    lblErrorValores.Visible = true;
                }
            }

        }

        private void btnCancelarValores_Click(object sender, EventArgs e)
        {
            btnEditarValores.Text = "Modificar";
            btnEditarValores.ImageIndex = 2;
            opcionesValores(false);
            lblSiguienteFactura.ForeColor = Color.Black;
            lblSiguienteFactura.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
            lblSiguienteRecibo.ForeColor = Color.Black;
            lblSiguienteRecibo.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
            lblFacturasRestantes.ForeColor = Color.Black;
            lblFacturasRestantes.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
            lblRecibosRestantes.ForeColor = Color.Black;
            lblRecibosRestantes.Font = new Font(lblSiguienteRecibo.Font, FontStyle.Regular);
            btnEditarValores.Enabled = true;
            cargarRangos();
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

        private void txtFaHasta_Leave(object sender, EventArgs e)
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
                recibRestantes = val2 - val + 1;
                lblRecibosRestantes.Text = "Ahora quedan " + recibRestantes + " recibos";
                if (recibRestantes < 0)
                    lblRecibosRestantes.ForeColor = Color.IndianRed;
                else
                    lblRecibosRestantes.ForeColor = Color.DarkCyan;
            }
        }

        #endregion

        #region Tab Categorias

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCodCategoria.Text = dgvCategorias[0, dgvCategorias.CurrentRow.Index].Value.ToString();
            txtNombreCateg.Text = dgvCategorias[1, dgvCategorias.CurrentRow.Index].Value.ToString();
            txtDesde.Text = dgvCategorias[2, dgvCategorias.CurrentRow.Index].Value.ToString();
            txtHasta.Text = dgvCategorias[3, dgvCategorias.CurrentRow.Index].Value.ToString();
            txtValorCateg.Text = dgvCategorias[4, dgvCategorias.CurrentRow.Index].Value.ToString().Replace(",", ".");
            selCateg = dgvCategorias.CurrentRow.Index;
        }

        int selCateg;
        string codigoCat, nombreCat, rango_min, rango_max, valorCat;

        private bool cargarRangosCategorias()
        {
            bool result = false;
            int filas = 0;
            int maxAnterior, minSiguiente, limMin, limMax;
            limMin = int.Parse(dgvCategorias[2, dgvCategorias.CurrentRow.Index].Value.ToString());
            limMax = int.Parse(dgvCategorias[3, dgvCategorias.CurrentRow.Index].Value.ToString());

            // Cambiar la fila seleccionada

            codigoCat = lblCodCategoria.Text;
            nombreCat = txtNombreCateg.Text.Trim();
            rango_min = txtDesde.Text.Trim();
            rango_max = txtHasta.Text.Trim();
            valorCat = txtValorCateg.Text.Replace(",", ".").Trim();

            filas += actualizarCategorias();

            // -------------------------------

            if (selCateg == 0) // Si es la primera fila modificar también la inferior
            {
                maxAnterior = 0;
                minSiguiente = int.Parse(txtHasta.Text) + 1;

                codigoCat = dgvCategorias[0, dgvCategorias.CurrentRow.Index + 1].Value.ToString();
                nombreCat = dgvCategorias[1, dgvCategorias.CurrentRow.Index + 1].Value.ToString();
                rango_min = minSiguiente.ToString();
                rango_max = dgvCategorias[3, dgvCategorias.CurrentRow.Index + 1].Value.ToString();
                valorCat = dgvCategorias[4, dgvCategorias.CurrentRow.Index + 1].Value.ToString().Replace(",", ".").Trim();

                filas += actualizarCategorias();

                if (filas == 2)
                    result = true;

            }
            else if (selCateg == dgvCategorias.RowCount - 1) // Si es la última modificar también la anterior
            {
                maxAnterior = int.Parse(txtDesde.Text) - 1;
                minSiguiente = 0;

                codigoCat = dgvCategorias[0, dgvCategorias.CurrentRow.Index - 1].Value.ToString();
                nombreCat = dgvCategorias[1, dgvCategorias.CurrentRow.Index - 1].Value.ToString();
                rango_min = dgvCategorias[2, dgvCategorias.CurrentRow.Index - 1].Value.ToString();
                rango_max = maxAnterior.ToString();
                valorCat = dgvCategorias[4, dgvCategorias.CurrentRow.Index - 1].Value.ToString().Replace(",", ".").Trim();

                filas += actualizarCategorias();

                if (filas == 2)
                    result = true;

            }
            else
            { // Si es intermedia modificar superior e inferior

                minSiguiente = int.Parse(txtHasta.Text) + 1;

                codigoCat = dgvCategorias[0, dgvCategorias.CurrentRow.Index + 1].Value.ToString();
                nombreCat = dgvCategorias[1, dgvCategorias.CurrentRow.Index + 1].Value.ToString();
                rango_min = minSiguiente.ToString();
                rango_max = dgvCategorias[3, dgvCategorias.CurrentRow.Index + 1].Value.ToString();
                valorCat = dgvCategorias[4, dgvCategorias.CurrentRow.Index + 1].Value.ToString().Replace(",", ".").Trim();

                filas += actualizarCategorias();

                //-------------------------------------

                maxAnterior = int.Parse(txtDesde.Text) - 1;

                codigoCat = dgvCategorias[0, dgvCategorias.CurrentRow.Index - 1].Value.ToString();
                nombreCat = dgvCategorias[1, dgvCategorias.CurrentRow.Index - 1].Value.ToString();
                rango_min = dgvCategorias[2, dgvCategorias.CurrentRow.Index - 1].Value.ToString();
                rango_max = maxAnterior.ToString();
                valorCat = dgvCategorias[4, dgvCategorias.CurrentRow.Index - 1].Value.ToString().Replace(",", ".").Trim();

                filas += actualizarCategorias();

                if (filas == 3)
                    result = true;

            }

            lblTest.Text = "Maximo anterior: " + maxAnterior + Environment.NewLine +
                            "Minimo actual: " + limMin + "  Maximo actual: " + limMax + Environment.NewLine +
                            "Minimo siguiente: " + minSiguiente + "    Filas: " + filas;

            return result;

        }

        private int actualizarCategorias()
        {
            MySqlConnection conn = new MySqlConnection(conexion.MyConString);
            MySqlCommand cmd = new MySqlCommand("SpUpdateCategorias", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            //codigo int,in nombre varchar(50),in rango_min int,in rango_max int ,in valor                        
            cmd.Parameters.AddWithValue("codigo", codigoCat);
            cmd.Parameters.AddWithValue("nombre", nombreCat);
            cmd.Parameters.AddWithValue("rango_min", rango_min);
            cmd.Parameters.AddWithValue("rango_max", rango_max);
            cmd.Parameters.AddWithValue("valor", valorCat);

            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                int catDesde = 0;
                int catHasta = 0;
                if (btnNuevaCategoria.Text.Equals("         Nuevo"))
                {
                    opcionesCategorias(true);
                    btnModificarCategoria.Enabled = false;
                    btnEliminarCategoria.Text = "Cancelar";
                    btnEliminarCategoria.ImageIndex = 4;
                    btnNuevaCategoria.Text = "         Guardar";
                    btnNuevaCategoria.ImageIndex = 0;

                    catDesde = int.Parse(dgvCategorias[3, dgvCategorias.RowCount - 1].Value.ToString()) + 1;
                    txtDesde.Text = catDesde.ToString();

                }
                else
                {
                    if (!txtNombreCateg.Text.Trim().Equals("") &&
                        !txtDesde.Text.Trim().Equals("") &&
                        !txtHasta.Text.Trim().Equals("") &&
                        !txtValorCateg.Text.Trim().Equals(""))
                    {
                        catHasta = int.Parse(txtHasta.Text);
                        catDesde = int.Parse(txtDesde.Text);

                        if (catHasta >= catDesde)
                        {
                            MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                            MySqlCommand cmd = new MySqlCommand("SpInsertCategorias", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Open();
                            // nombre varchar(50),in rango_min int,in rango_max int,in valor
                            cmd.Parameters.AddWithValue("nombre", txtNombreCateg.Text.Trim());
                            cmd.Parameters.AddWithValue("rango_min", txtDesde.Text.Trim());
                            cmd.Parameters.AddWithValue("rango_max", txtHasta.Text.Trim());
                            cmd.Parameters.AddWithValue("valor", txtValorCateg.Text.Trim());

                            int result = cmd.ExecuteNonQuery();
                            conn.Close();
                            if (result > 0)
                            {
                                MessageBox.Show("Se ingresó la categoría correctamente");
                                opcionesCategorias(false);
                                cargarCategorias();
                                btnNuevaCategoria.Text = "         Nuevo";
                                btnNuevaCategoria.ImageIndex = 1;
                                btnEliminarCategoria.Text = "Eliminar";
                                btnEliminarCategoria.ImageIndex = 3;
                                btnModificarCategoria.Enabled = true;

                            }
                            else
                            {
                                MessageBox.Show("No se pudo ingresar la categoría");
                            }
                        }
                        else
                        {
                            lblErrorCateg.Visible = true;
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

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnModificarCategoria.Text.Equals("Modificar"))
                {
                    if (lblCodCategoria.Text.Equals(""))
                    {
                        dgvCategorias.Rows[0].Selected = true;
                        selCateg = 0;
                        lblCodCategoria.Text = dgvCategorias[0, 0].Value.ToString();
                        txtNombreCateg.Text = dgvCategorias[1, 0].Value.ToString();
                        txtDesde.Text = dgvCategorias[2, 0].Value.ToString();
                        txtHasta.Text = dgvCategorias[3, 0].Value.ToString();
                        txtValorCateg.Text = dgvCategorias[4, 0].Value.ToString();
                    }

                    panelCategorias.Visible = true;
                    btnNuevaCategoria.Enabled = false;
                    btnEliminarCategoria.Text = "Cancelar";
                    btnEliminarCategoria.ImageIndex = 4;
                    btnModificarCategoria.Text = "Guardar";
                    btnModificarCategoria.ImageIndex = 0;
                    txtDesde.ReadOnly = false;
                }
                else
                {
                    if (!txtNombreCateg.Text.Trim().Equals("") &&
                        !txtDesde.Text.Trim().Equals("") &&
                        !txtHasta.Text.Trim().Equals("") &&
                        !txtValorCateg.Text.Trim().Equals(""))
                    {
                        //cargarRangosCategorias();

                        if (cargarRangosCategorias())
                        {
                            MessageBox.Show("Se actualizó la infomación de la categoría.");
                            opcionesCategorias(false);
                            cargarCategorias();
                            btnModificarCategoria.Text = "Modificar";
                            btnModificarCategoria.ImageIndex = 2;
                            btnEliminarCategoria.Text = "Eliminar";
                            btnEliminarCategoria.ImageIndex = 3;
                            btnNuevaCategoria.Enabled = true;
                            txtDesde.ReadOnly = true;
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

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEliminarCategoria.Text.Equals("Eliminar"))
                {
                    if (lblCodCategoria.Text.Equals(""))
                    {
                        lblCodCategoria.Text = dgvCategorias[0, 0].Value.ToString();
                    }

                    sql = "select cod_cat from lecturas where cod_cat = " + lblCodCategoria.Text;
                    DataTable dtt = metodo.consultarDatos(sql);
                    int aux = dtt.Rows.Count;
                    if (aux < 1)
                    {
                        MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                        MySqlCommand cmd = new MySqlCommand("SpDeleteCategorias", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Parameters.AddWithValue("codigo", lblCodCategoria.Text);
                        int result = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (result > 0)
                        {
                            MessageBox.Show("Se eliminó la categoría correctamente");
                            cargarCategorias();
                            opcionesCategorias(false);
                            lblCodCategoria.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la categoría");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La categoría está asociada a lecturas. No se puede eliminar");
                    }
                }
                else
                {
                    opcionesCategorias(false);
                    btnNuevaCategoria.Enabled = true;
                    btnNuevaCategoria.Text = "         Nuevo";
                    btnNuevaCategoria.ImageIndex = 1;
                    btnModificarCategoria.Enabled = true;
                    btnModificarCategoria.Text = "Modificar";
                    btnModificarCategoria.ImageIndex = 2;
                    btnEliminarCategoria.Text = "Eliminar";
                    btnEliminarCategoria.ImageIndex = 3;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        #endregion

        //Opciones para habilitar la edicion de los campos

        private void opcionesUsuarios(bool op)
        {
            panelUsuarios.Visible = op;
            txtNewCedula.Text = "";
            txtNewNombre.Text = "";
            txtNewTelefono.Text = "";
            txtNewClave.Text = "";
            cbNewRol.SelectedIndex = 1;
        }

        private void opcionesValores(bool op)
        {
            txtFaDesde.Enabled = op;
            txtFaHasta.Enabled = op;
            txtReDesde.Enabled = op;
            txtReHasta.Enabled = op;
            btnCancelarValores.Visible = op;
        }

        private void opcionesRubros(bool op)
        {
            panelRubros.Visible = op;
            txtNombreRubro.Text = "";
            txtValorRubro.Text = "";
            txtObservacion.Text = "";
            lblCodRubro.Text = "";
        }

        private void opcionesCategorias(bool op)
        {
            panelCategorias.Visible = op;
            txtNombreCateg.Text = "";
            txtDesde.Text = "";
            txtHasta.Text = "";
            txtValorCateg.Text = "";
            lblCodRubro.Text = "";
            lblErrorCateg.Visible = false;
        }


        




    }
}
