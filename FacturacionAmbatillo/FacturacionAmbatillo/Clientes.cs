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
using System.Globalization;

namespace FacturacionAmbatillo
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();

            //Ocultar pestañas
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Tab Clientes
            metodo.llenarGridSP(dgvClientes, "SpSelectClientes");
            dgvClientes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            dtt = (DataTable)dgvClientes.DataSource;
            dgvClientes.ClearSelection();
            dgvClientes.Rows[0].Selected = false;

        }

        MetodosGenerales metodo = new MetodosGenerales();
        DataTable dtt;
        MySqlDataReader myreader;

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
            metodo.llenarGridSP(dgvClientes, "SpSelectClientes");

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

        private Form panel = new Form();


        private void btnMedidas_Click(object sender, EventArgs e)
        {
            try { 
                string nombre = dgvClientes[2, dgvClientes.CurrentRow.Index].Value.ToString();
                string medidor = lbxMedidores.SelectedValue.ToString();
                if (nombre != null && medidor != null)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tpHistorial"];
                    txtClienteHist.Text = nombre;
                    txtMedidorHist.Text = medidor;
                    txtClienteFact.Text = nombre;
                    txtMedidorFact.Text = medidor;
                    cargarHistorial(medidor);
                    dgvMedidas.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMedidas.Columns["ValorCI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMedidas.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            };

        }

        DataTable dataTable;

        private void cargarHistorial(string codMedidor){
            try
            {
                // Cargar StoredProcedure para ver historial
                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpHistorialMedidor", cnn);
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_med_p", codMedidor.Trim());

                dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                int result = da.Fill(dataTable);
                dgvMedidas.DataSource = dataTable;

                dgvMedidas.Columns["Intervalo"].Visible = false;
                dgvMedidas.Columns["id"].Visible = false;
                dgvMedidas.Columns["anterior"].Visible = false;
                dgvMedidas.Columns["actual"].Visible = false;
                dgvMedidas.Columns["cantidad"].Visible = false;
                dgvMedidas.Columns["Valor"].Visible = false;
                dgvMedidas.Columns["ValorUnitario"].Visible = false;

                dgvMedidas.Columns["ValorCI"].HeaderText = "Valor";
                
                if (result>0)
                {
                    dgvMedidas.Rows[0].Selected = false;
                    
                    bool abonado = false;
                    bool pendiente = false;
                    foreach (DataGridViewRow row in dgvMedidas.Rows) {
                        if (row.Cells["Estado"].Value.Equals("abonado"))
                        {
                            row.Selected = true;
                            abonado = true;
                        }
                        else if (abonado == false) {
                            if (row.Cells["Estado"].Value.Equals("pendiente") && pendiente == false)
                            {
                                row.Selected = true;
                                pendiente = true;
                            }
                        }
                    }
                

                // Calcular el interés por mora

                string sql = "SELECT valor FROM rubros where nombre = 'Interés por mora'; ";
                dataTable = metodo.consultarDatos(sql);
                double interes = 1 + (Convert.ToDouble(dataTable.Rows[0][0].ToString()) / 100);

                foreach (DataGridViewRow row in dgvMedidas.Rows)
                {
                    int intervalo = Convert.ToInt32(row.Cells["Intervalo"].Value);
                    double valor = Convert.ToInt32(row.Cells["ValorCI"].Value);
                    //lblMensaje.Text += " intervalo:" + intervalo.ToString();
                    //blMensaje.Text += " Valor:" + valor.ToString();

                    if (intervalo > 0)
                        for (int j = 1; j <= intervalo; j++)
                        {
                            valor *= interes;
                        }
                    row.Cells["ValorCI"].Value = String.Format("{0:F}", valor);
                    
                    //lblMensaje.Text += " con interes:" + row.Cells["ValorCI"].Value;


                    if (row.Cells["Estado"].Value.ToString() == "cancelado")
                    {
                        row.DefaultCellStyle.ForeColor = Color.DarkGray; //BackColor = Color.LightBlue;
                    }
                }
                    calcularSubtotal();
                }
                else
                {
                    btnContinuar.Enabled = false;
                    MessageBox.Show("No se encontraron datos en el historial");
                }

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            
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

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            //Pasar al tab Factura
            tabControl1.SelectedTab = tabControl1.TabPages["tpFactura"];
            DataTable dt = new DataTable();
            DataGridViewRow row = new DataGridViewRow();
            int i = 0, codLect = 0;
            bool abonado = false;

            try {

                //Cargar valores con interés en grid Pagos
                foreach (DataGridViewRow rowPrincipal in dgvMedidas.SelectedRows)
                {
                    int intervalo = Convert.ToInt32(rowPrincipal.Cells["intervalo"].Value);
                    double interes = Convert.ToDouble(rowPrincipal.Cells["Valor"].Value); 
                    if (intervalo > 0)
                    {
                        double valCI = Convert.ToDouble(rowPrincipal.Cells["ValorCI"].Value);
                        double valSI = Convert.ToDouble(rowPrincipal.Cells["Valor"].Value);
                        interes = valCI - valSI;
                    
                        dgvPagar.Rows.Add(i, "", "", "", 
                                   intervalo,
                                   "Interés",
                                   interes,
                                   interes);
                        i++;
                    }

                    dgvPagar.Rows.Add(i,
                                   rowPrincipal.Cells["id"].Value,
                                   rowPrincipal.Cells["anterior"].Value,
                                   rowPrincipal.Cells["actual"].Value,
                                   rowPrincipal.Cells["cantidad"].Value,
                                   "Consumo - " + rowPrincipal.Cells["Fecha"].Value,
                                   rowPrincipal.Cells["ValorUnitario"].Value,
                                   rowPrincipal.Cells["Valor"].Value);
                    i++;

                    if (rowPrincipal.Cells["Estado"].Value.Equals("abonado"))
                    {
                        abonado = true;
                        codLect = Convert.ToInt32(rowPrincipal.Cells["id"].Value.ToString());
                    }

                }

                if (abonado == true)
                {
                    MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                    MySqlCommand cmd = new MySqlCommand("SpTotalAbonos", cnn);
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("cod_lect", codLect);

                    myreader = cmd.ExecuteReader();
                    myreader.Read();

                    if (myreader.HasRows)
                    {
                        dgvSaldos.Rows.Add("Abonos anteriores", myreader["abonos"].ToString());
                        dgvSaldos.Rows.Add("Valor a pagar", myreader["saldo"].ToString());
                        lblValores.Text += " Total: " + myreader["total"].ToString() +
                                           " Abonos: " + myreader["abonos"].ToString() +
                                           " Saldo: " + myreader["saldo"].ToString();
                        //dgvSaldos.Rows.Add("Abono Actual", "");
                        //dgvSaldos.Rows.Add("Saldo Actual", "");
                    }
                    else
                    {
                        //lblErrorPass.Visible = true;
                    }
                }



                    dgvPagar.Sort(dgvPagar.Columns[0], ListSortDirection.Descending);
                rbFactura.Checked = true;

                // Sumar Totales
                double subtotal = 0;
                for (int j = 0; j < i; j++)
                {
                    subtotal += Convert.ToDouble(dgvPagar.Rows[j].Cells["VTotal"].Value);
                }
                dgvTotal.Rows.Add("Subtotal", subtotal);
                dgvTotal.Rows.Add("Descuento", "");
                dgvTotal.Rows.Add("IVA 0%", subtotal);
                dgvTotal.Rows.Add("IVA 12%", "");
                dgvTotal.Rows.Add("TOTAL", subtotal);

                dgvTotal.Rows[0].Selected = false;
                dgvPagar.Rows[0].Selected = false;
                dgvSaldos.Rows[0].Selected = false;
                dgvPagar.ClearSelection();
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            

        }


        private void tabHistorial_Click(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            
            tabControl1.SelectedTab = tabControl1.TabPages["tpInicio"];
            btnContinuar.Enabled = true;
            lblMensaje.Text = "Cálculos";
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtMedidorHist_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClienteHist_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAtrasFact_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["tpHistorial"];
            dgvPagar.Rows.Clear();
            dgvTotal.Rows.Clear();
            dgvSaldos.Rows.Clear();
        }

        private void tpInicio_Click(object sender, EventArgs e)
        {

        }

        private void btnContinuarFact_Click(object sender, EventArgs e)
        {

        }

        private void dgvMedidas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //double subtotal = 0;
            //foreach (DataGridViewRow row in dgvMedidas.SelectedRows)
            //{
            //    double valor = Convert.ToInt32(row.Cells["ValorCI"].Value);
            //    subtotal += valor;
            //    txtSubTotal.Text = subtotal.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                

            //}
        }

        private void dgvMedidas_MouseUp(object sender, MouseEventArgs e)
        {
            bool cancelado = false;
            bool abonado = false;
            
            //if(dgvMedidas.CurrentRow.Cells["Estado"].Value.Equals("abonado"))
            foreach (DataGridViewRow row in dgvMedidas.SelectedRows)
            {
                if (row.Cells["Estado"].Value.Equals("abonado"))
                    abonado = true;
                if (row.Cells["Estado"].Value.Equals("cancelado"))
                    cancelado = true;
            }

            if(abonado==true)
                foreach (DataGridViewRow row in dgvMedidas.Rows)
                {
                    if (row.Cells["Estado"].Value.Equals("abonado"))
                        row.Selected = true;
                }

            foreach (DataGridViewRow row in dgvMedidas.Rows)
            {
                if (row.Cells["Estado"].Value.Equals("abonado"))
                    abonado = true;
            }

            if (cancelado == true)
            {
                txtSubTotal.Text = "";
            }
            else {
                calcularSubtotal();
            }

            if (cancelado == true)
                btnContinuar.Enabled = false;
            else
                btnContinuar.Enabled = true;

            lblMensaje.Text += "Cancelado: " + cancelado.ToString() +
                               " Abonado: " + abonado.ToString();
            
        }

        private void calcularSubtotal()
        {
            double subtotal = 0;
            foreach (DataGridViewRow row in dgvMedidas.SelectedRows)
            {
                double valor = Convert.ToDouble(row.Cells["ValorCI"].Value);
                subtotal += valor;
                txtSubTotal.Text = subtotal.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
                //String.Format("{0:C}", subtotal);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            
        }

        private void tpFactura_Click(object sender, EventArgs e)
        {

        }

        private void rbFactura_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = metodo.consultarDatos("spNumSiguientePago");
            int nfactura = Convert.ToInt32(dt.Rows[0][0].ToString());
            int nrecibo = Convert.ToInt32(dt.Rows[1][0].ToString());

            if (rbFactura.Checked == true)
            {
                lblTipoDePago.Text = "FACTURA N°";
                if (nfactura > 0) {
                    lblNumeroPago.ForeColor = Color.Black;
                    lblNumeroPago.Text = String.Format("{0:0000000}", nfactura);
                }
                else {
                    lblNumeroPago.Text = "0000000";
                    lblNumeroPago.ForeColor = Color.IndianRed;
                    MessageBox.Show("Se ha alcanzado el límite de facturación\n" +
                                    "Puede actualizar el rango en Configuraciones", "Error");
                }
            }

            else { 
                lblTipoDePago.Text = "RECIBO N°";
                if (nrecibo > 0)
                {
                    lblNumeroPago.ForeColor = Color.Black;
                    lblNumeroPago.Text = String.Format("{0:0000000}", nrecibo);
                    btnPagar.Enabled = true;
                }
                else
                {
                    lblNumeroPago.Text = "0000000";
                    lblNumeroPago.ForeColor = Color.IndianRed;
                    MessageBox.Show("Se ha alcanzado el límite de recibos\n" +
                                    "Puede actualizar el rango en Configuraciones", "Error");
                    btnPagar.Enabled = false;
                }
            }

            dgvSaldos.Rows.Clear();
            dgvSaldos.Rows.Add("Abonos anteriores", myreader["abonos"].ToString());
            dgvSaldos.Rows.Add("Valor a pagar", myreader["saldo"].ToString());

        }

        private void rbAbono_CheckedChanged(object sender, EventArgs e)
        {
            dgvSaldos.Rows.Clear();
            dgvSaldos.Rows.Add("Saldo Anterior", myreader["saldo"].ToString());
            dgvSaldos.Rows.Add("Abono Actual", "");
            dgvSaldos.Rows.Add("Saldo Actual", "");
        }
    }
}
