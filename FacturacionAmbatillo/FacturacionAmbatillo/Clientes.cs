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
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace FacturacionAmbatillo
{
    public partial class Clientes : Form
    {
        private string usuarioID;
        private string usuarioNom;
        private string clienteID;
        private string clienteCed;
        private string clienteNom;
        private string medidorID;
        private string medidorDir;

        public Clientes(string user)
        {
            InitializeComponent();
            usuarioID = user;
            lblValores.Text = usuarioID;
            //Ocultar pestañas
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Tab Clientes
            metodo.llenarGridSP(dgvClientes, "SpSelectClientes");
            dgvClientes.Columns[0].HeaderText = "N°";
            dgvClientes.Columns[1].HeaderText = "Cédula";
            dgvClientes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvClientes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtt = (DataTable)dgvClientes.DataSource;
            dgvClientes.ClearSelection();
            dgvClientes.Rows[0].Selected = false;
            //dgvPagar.Rows.Add();

        }

        MetodosGenerales metodo = new MetodosGenerales();
        DataTable dtt, dttMed;
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
                dttMed = dataTable;
                lbxMedidores.DataSource = dataTable;
                lbxMedidores.ValueMember = "id_med";
                lbxMedidores.DisplayMember = "medidor";

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCedula.Text = "";
            txtMedidor.Text = "";
            cbTipoDeUsuario.SelectedIndex = -1;

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
            try
            {
                //clienteNom = dgvClientes[2, dgvClientes.CurrentRow.Index].Value.ToString();
                clienteCed = dgvClientes[1, dgvClientes.CurrentRow.Index].Value.ToString();
                //clienteID = dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString();
                medidorID = lbxMedidores.SelectedValue.ToString();
                medidorDir = "Santa Rosa - " + dttMed.Rows[lbxMedidores.SelectedIndex]["nombre"].ToString();
                //medidorDir = "Santa Rosa - " + dgvClientes[3, dgvClientes.CurrentRow.Index].Value.ToString();
                lblMensaje.Text = medidorDir;
                if (nombre != null && medidorID != null)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages["tpHistorial"];
                    txtClienteHist.Text = clienteNom;
                    txtMedidorHist.Text = medidorID;
                    txtClienteFact.Text = clienteNom;
                    txtMedidorFact.Text = medidorID;
                    cargarHistorial(medidorID);
                    dgvMedidas.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMedidas.Columns["ValorCI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMedidas.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };

        }

        DataTable dataTable;
        double interes;
        bool estadoAbonado;

        private void cargarHistorial(string codMedidor)
        {
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
                cnn.Close();
                //Marcar como predeterminado el siguiente pago
                if (result > 0)
                {
                    dgvMedidas.Rows[0].Selected = false;

                    bool abonado = false;
                    bool pendiente = false;
                    foreach (DataGridViewRow row in dgvMedidas.Rows)
                    {
                        //Seleccionar todos con estado 'abonado'
                        if (row.Cells["Estado"].Value.Equals("abonado"))
                        {
                            row.Selected = true;
                            abonado = true;
                        }
                        //Seleccionar solo el siguiente pago pendiente
                        else if (abonado == false)
                        {
                            if (row.Cells["Estado"].Value.Equals("pendiente") && pendiente == false)
                            {
                                row.Selected = true;
                                pendiente = true;
                            }
                        }
                    }


                    if (abonado == true || pendiente == true)
                        btnContinuar.Enabled = true;
                    else
                        btnContinuar.Enabled = false;

                    // Calcular el interés por mora

                    string sql = "SELECT valor FROM rubros where id_rub = 2; ";
                    dataTable = metodo.consultarDatos(sql);

                    //Cálculo del interés porcentual
                    //double interes = 1 + (Convert.ToDouble(dataTable.Rows[0][0].ToString()) / 100);

                    //Interés de valor fijo
                    interes = Convert.ToDouble(dataTable.Rows[0][0].ToString());

                    //Calcular si es consumo normal o con interés
                    foreach (DataGridViewRow row in dgvMedidas.Rows)
                    {

                        int intervalo = Convert.ToInt32(row.Cells["Intervalo"].Value);
                        double valor = Convert.ToDouble(row.Cells["ValorCI"].Value);
                        lblMensaje.Text += " intervalo:" + intervalo.ToString();
                        lblMensaje.Text += " Valor:" + valor.ToString();

                        //Mínimo un mes de retraso
                        if (intervalo > 0)
                            for (int j = 1; j <= intervalo; j++)
                            {
                                //valor *= interes;
                                valor += interes;
                            }
                        row.Cells["ValorCI"].Value = valor;// String.Format("0.00", valor);
                                                           //row.Cells["ValorCI"].Value = valor.ToString("0.00", CultureInfo.InvariantCulture);
                                                           //lblMensaje.Text += valor.ToString("N", CultureInfo.InvariantCulture);


                        if (row.Cells["Estado"].Value.ToString() == "cancelado")
                        {
                            row.DefaultCellStyle.ForeColor = Color.DarkGray; //BackColor = Color.LightBlue;
                        }
                    }
                    dgvMedidas.Sort(dgvMedidas.Columns[0], ListSortDirection.Ascending);
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
            clienteID = dgvClientes[0, dgvClientes.CurrentRow.Index].Value.ToString();
            clienteNom = dgvClientes[2, dgvClientes.CurrentRow.Index].Value.ToString();

            consultarMedidores(clienteID);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void nuevoPago() {
            int i = 0;
            try
            {
                //Cargar valores con interés en grid Pagos
                foreach (DataGridViewRow rowPrincipal in dgvMedidas.SelectedRows)
                {
                    int intervalo = Convert.ToInt32(rowPrincipal.Cells["intervalo"].Value);
                    //double interes = Convert.ToDouble(rowPrincipal.Cells["Valor"].Value); 
                    if (intervalo > 0)
                    {
                        //double valCI = Convert.ToDouble(rowPrincipal.Cells["ValorCI"].Value);
                        //double valSI = Convert.ToDouble(rowPrincipal.Cells["Valor"].Value);
                        //interes = valCI - valSI;

                        dgvPagar.Rows.Add(i, "2",
                                   rowPrincipal.Cells["id"].Value,
                                   "", "",
                                   intervalo,
                                   "Interés",
                                   interes,
                                   interes * intervalo);
                        i++;
                    }

                    dgvPagar.Rows.Add(i, "1",
                                   rowPrincipal.Cells["id"].Value,
                                   rowPrincipal.Cells["anterior"].Value,
                                   rowPrincipal.Cells["actual"].Value,
                                   rowPrincipal.Cells["cantidad"].Value,
                                   "Consumo - (" + rowPrincipal.Cells["Fecha"].Value + ")",
                                   rowPrincipal.Cells["ValorUnitario"].Value,
                                   rowPrincipal.Cells["Valor"].Value);
                    //rowPrincipal.Cells["ValorUnitario"].Value.ToString("C",CultureInfo.InvariantCulture),
                    //String.Format("{0:C}", rowPrincipal.Cells["Valor"].Value));
                    i++;
                    
                }

                dgvPagar.Sort(dgvPagar.Columns[0], ListSortDirection.Descending);
                rbFactura.Checked = true;
                numPago();
                // Sumar Totales
                sumarTotales();

                dgvTotal.Rows[0].Selected = false;
                dgvPagar.Rows[0].Selected = false;
                //dgvSaldos.Rows[0].Selected = false;
                //dgvPagar.ClearSelection();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int codigoDePago;

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            int i = 0, codLect = 0;

            try
            {
                bool ab = false;
                estadoAbonado = false;

                //comprbar si hay valores abonados
                foreach (DataGridViewRow row in dgvMedidas.Rows)
                {
                    if (row.Cells["estado"].Value.Equals("abonado"))
                    {
                        ab = true;
                    }
                }
                
                //comprobar si entre los seleccionados hay abonos
                foreach (DataGridViewRow row in dgvMedidas.SelectedRows)
                {
                    if (row.Cells["Estado"].Value.Equals("abonado"))
                    {
                        estadoAbonado = true;
                        codLect = Convert.ToInt32(row.Cells["id"].Value.ToString());
                    }

                }

                //Si seleccionó las lecturas correspondientes
                if (ab == estadoAbonado)
                {
                    //Pasar al tab Factura
                    tabControl1.SelectedTab = tabControl1.TabPages["tpFactura"];

                    //Si es un pago nuevo
                    if (ab == false)
                    {
                        nuevoPago();
                    }
                    else
                    {
                        foreach (DataGridViewRow rowPrincipal in dgvMedidas.SelectedRows)
                        {
                            int intervalo = Convert.ToInt32(rowPrincipal.Cells["intervalo"].Value);
                            //double interes = Convert.ToDouble(rowPrincipal.Cells["Valor"].Value); 
                            if (intervalo > 0)
                            {
                                //double valCI = Convert.ToDouble(rowPrincipal.Cells["ValorCI"].Value);
                                //double valSI = Convert.ToDouble(rowPrincipal.Cells["Valor"].Value);
                                //interes = valCI - valSI;

                                dgvPagar.Rows.Add(i, "2",
                                           rowPrincipal.Cells["id"].Value,
                                           "", "",
                                           intervalo,
                                           "Interés",
                                           interes,
                                           interes * intervalo);
                                i++;
                            }

                            dgvPagar.Rows.Add(i, "1",
                                           rowPrincipal.Cells["id"].Value,
                                           rowPrincipal.Cells["anterior"].Value,
                                           rowPrincipal.Cells["actual"].Value,
                                           rowPrincipal.Cells["cantidad"].Value,
                                           "Consumo - (" + rowPrincipal.Cells["Fecha"].Value + ")",
                                           rowPrincipal.Cells["ValorUnitario"].Value,
                                           rowPrincipal.Cells["Valor"].Value);
                            //rowPrincipal.Cells["ValorUnitario"].Value.ToString("C",CultureInfo.InvariantCulture),
                            //String.Format("{0:C}", rowPrincipal.Cells["Valor"].Value));
                            i++;

                        }

                        MessageBox.Show(codLect.ToString());
                        codigoDePago = 0;
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
                            codigoDePago = Convert.ToInt32(myreader["codigo"].ToString());
                            //dgvSaldos.Rows.Add("Abono Actual", "");
                            //dgvSaldos.Rows.Add("Saldo Actual", "");

                            string sql = "select d.cod_rubro, d.cantidad, r.nombre, r.valor, (d.cantidad*r.valor) vtotal " +
                                            "from detalles d, rubros r " +
                                            "where d.cod_rubro = r.id_rub and " +
                                            "d.cod_rubro != 1 and " +
                                            "d.cod_rubro != 2 and " +
                                            "d.cod_pag = " + codigoDePago;
                            DataTable dat = metodo.consultarDatos(sql);
                            for (int j = 0; j < dat.Rows.Count; j++)
                            {
                                dgvPagar.Rows.Add(i, dat.Rows[j]["cod_rubro"].ToString(),
                                                       "", "", "", dat.Rows[j]["cantidad"].ToString(),
                                                       dat.Rows[j]["nombre"].ToString(),
                                                       dat.Rows[j]["valor"].ToString(),
                                                       dat.Rows[j]["vtotal"].ToString());
                                i++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se cargaron los abonos anteriores");
                        }
                        
                    }

                    
                    dgvPagar.Sort(dgvPagar.Columns[0], ListSortDirection.Descending);
                    rbFactura.Checked = true;
                    numPago();
                    // Sumar Totales
                    sumarTotales();

                    dgvTotal.Rows[0].Selected = false;
                    dgvPagar.Rows[0].Selected = false;
                    //dgvSaldos.Rows[0].Selected = false;
                    //dgvPagar.ClearSelection();    
                }
                else
                    MessageBox.Show("Tiene abonos pendientes");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        double totalPago;

        private void sumarTotales()
        {
            totalPago = 0;
            foreach (DataGridViewRow row in dgvPagar.Rows)
            {
                totalPago += Convert.ToDouble(row.Cells["VTotal"].Value);
            }
            dgvTotal.Rows.Clear();
            dgvTotal.Rows.Add("Subtotal", totalPago);
            dgvTotal.Rows.Add("Descuento", "0.00");
            dgvTotal.Rows.Add("IVA 0%", totalPago);
            dgvTotal.Rows.Add("IVA 12%", "0.00");
            dgvTotal.Rows.Add("TOTAL", totalPago);
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
            bool pendiente = false;

            //if(dgvMedidas.CurrentRow.Cells["Estado"].Value.Equals("abonado"))
            foreach (DataGridViewRow row in dgvMedidas.SelectedRows)
            {
                if (row.Cells["Estado"].Value.Equals("abonado"))
                    abonado = true;
                if (row.Cells["Estado"].Value.Equals("cancelado"))
                    cancelado = true;
                if (row.Cells["Estado"].Value.Equals("pendiente"))
                    pendiente = true;
            }

            if (abonado == true)
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
            else
            {
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

        private void tpFactura_Click(object sender, EventArgs e)
        {

        }

        int nfactura;
        int nrecibo;
        string estado;

        private void cambiarNumPago()
        {
            int count = 0;
            MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
            DataTable dt = metodo.consultarDatos("SpSelectconfiguraciones");
            MySqlCommand cmd = new MySqlCommand("SpUpdateConfiguraciones", cnn);

            cnn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //in fact_desde int,in fact_hasta int, in recib_desde int , in recib_hasta int)
            if (estado == "cancelado")
            {
                cmd.Parameters.AddWithValue("fact_desde", nfactura + 1);
                cmd.Parameters.AddWithValue("recib_desde", nrecibo);
            }
            else
            {
                cmd.Parameters.AddWithValue("recib_desde", nrecibo + 1);
                cmd.Parameters.AddWithValue("fact_desde", nfactura);
            }
            cmd.Parameters.AddWithValue("fact_hasta", dt.Rows[0][2].ToString());
            cmd.Parameters.AddWithValue("recib_hasta", dt.Rows[0][4].ToString());
            count = cmd.ExecuteReader().RecordsAffected;
            cnn.Close();
            if (count > 0)
                lblValores.Text = "Ya ta";
        }

        private void numPago()
        {
            DataTable dt = metodo.consultarDatos("SpSelectconfiguraciones");
            if (dt.Rows.Count > 0)
            {
                nfactura = Convert.ToInt32(dt.Rows[0]["fact_desde"].ToString());
                nrecibo = Convert.ToInt32(dt.Rows[0]["recib_desde"].ToString());

                if (rbFactura.Checked == true)
                {
                    lblTipoDePago.Text = "FACTURA N°";
                    if (nfactura <= Convert.ToInt32(dt.Rows[0]["fact_hasta"].ToString()))
                    {
                        lblNumeroPago.ForeColor = Color.Black;
                        lblNumeroPago.Text = String.Format("{0:0000000}", nfactura);
                        estado = "cancelado";
                    }
                    else
                    {
                        lblNumeroPago.Text = "0000000";
                        lblNumeroPago.ForeColor = Color.IndianRed;
                        MessageBox.Show("Se ha alcanzado el límite de facturación\n" +
                                    "Puede actualizar el rango en Configuraciones", "Error");
                    }

                }

                else
                {
                    lblTipoDePago.Text = "RECIBO N°";
                    if (nrecibo <= Convert.ToInt32(dt.Rows[0]["recib_hasta"].ToString()))
                    {
                        lblNumeroPago.ForeColor = Color.Black;
                        lblNumeroPago.Text = String.Format("{0:0000000}", nrecibo);
                        btnPagar.Enabled = true;
                        estado = "pendiente";
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
            }
            dgvSaldos.Rows.Clear();
            if (estadoAbonado == true)
            {
                dgvSaldos.Rows.Add("Abonos anteriores", myreader["abonos"].ToString());
                dgvSaldos.Rows.Add("Valor a pagar", myreader["saldo"].ToString());
            }
        }

        private void rbFactura_CheckedChanged(object sender, EventArgs e)
        {
            numPago();

        }

        private void rbAbono_CheckedChanged(object sender, EventArgs e)
        {
            dgvSaldos.Rows.Clear();
            if (estadoAbonado == true)
                dgvSaldos.Rows.Add("Saldo Anterior", myreader["saldo"].ToString());
            else
                dgvSaldos.Rows.Add("Saldo Anterior", "0");
            dgvSaldos.Rows.Add("Abono Actual", "");
            dgvSaldos.Rows.Add("Saldo Actual", "");
        }

        #region Imprimir

        private Image facturaModelo;

        private bool imprimirFactura(Image facturaActual)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += (sender, e) => e.Graphics.DrawImage(facturaActual, 0, 0);
                pd.Print();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al imprimir la factura. Compruebe que la impresora esté conectada y encendida", "Advertencia");
                return false;
            }
        }

        private void dibujarFactura()
        {
            int[] x = { 50, 135, 215, 295, 665, 760 };
            int firstY = 265;
            int y = 20;
            Image facturaActual = facturaModelo;
            Graphics g = Graphics.FromImage(facturaActual);
            StringFormat formatter = new StringFormat();
            //formatter.LineAlignment = StringAlignment.Center;
            //formatter.Alignment = StringAlignment.Center;
            Font font = new Font("Arial Unicode MS", 14, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Black);

            //Puntos de dibujo

            g.DrawString(txtClienteFact.Text, font, brush, new Point(90, 102), formatter);
            g.DrawString(medidorDir, font, brush, new Point(105, 125), formatter);
            g.DrawString("Tungurahua", font, brush, new Point(330, 155), formatter);
            g.DrawString(txtMedidorFact.Text, font, brush, new Point(120, 195), formatter);
            g.DrawString(clienteCed, font, brush, new Point(315, 195), formatter);
            g.DrawString(DateTime.Now.Day.ToString(), font, brush, new Point(465, 155), formatter);
            g.DrawString(DateTime.Now.Month.ToString(), font, brush, new Point(530, 155), formatter);
            g.DrawString(DateTime.Now.Year.ToString(), font, brush, new Point(590, 155), formatter);

            foreach (DataGridViewRow row in dgvPagar.Rows)
            {
                g.DrawString(row.Cells["anterior"].Value.ToString(), font, brush, new Point(x[0], firstY), formatter);
                g.DrawString(row.Cells["actual"].Value.ToString(), font, brush, new Point(x[1], firstY), formatter);
                g.DrawString(row.Cells["cantidad"].Value.ToString(), font, brush, new Point(x[2], firstY), formatter);
                g.DrawString(row.Cells["detalle"].Value.ToString(), font, brush, new Point(x[3], firstY), formatter);
                g.DrawString(row.Cells["VUnitario"].Value.ToString(), font, brush, new Point(x[4], firstY), formatter);
                g.DrawString(row.Cells["VTotal"].Value.ToString(), font, brush, new Point(x[5], firstY), formatter);
                firstY += y;
            }

            firstY = 530;
            foreach (DataGridViewRow row in dgvTotal.Rows)
            {
                g.DrawString(row.Cells["total"].Value.ToString(), font, brush, new Point(x[5], firstY), formatter);
                firstY += y;
            }

            //Mostrar el dibujo


            Form f2 = new Form();
            f2.Show();
            f2.Validate();
            PictureBox pbox = new PictureBox();
            pbox.Image = facturaActual;
            pbox.SizeMode = PictureBoxSizeMode.AutoSize;
            f2.Width = pbox.Width + 17;
            f2.Height = pbox.Height + 37;
            f2.Controls.Add(pbox);


            //imprimirFactura(facturaActual);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (btnPagar.Text == "        Guardar Pago")
            {
                if (estadoAbonado == true)
                {

                }
                else {
                    guardarPago();
                    facturaModelo = FacturacionAmbatillo.Properties.Resources.Fact;
                }
                //dibujarFactura();
                //guardarPago();
                Imprimir_Solicitud();
                //btnPagar.Text = "        Finalizar";
            }
            else
            {
                //btnPagar.Text = "        Finalizar";
                tabControl1.SelectedTab = tabControl1.TabPages["tpInicio"];
                //dgvMedidas.Rows.Clear();
                dgvPagar.Rows.Clear();
                dgvTotal.Rows.Clear();
                dgvSaldos.Rows.Clear();
                btnPagar.Text = "        Guardar Pago";
                txtObservacion.Text = "";
            }
            //CaptureScreen();
            //printPreviewDialog1.Show();

        }

        #endregion

        // ////////////////////////////////////

        private Font fuente = new Font("Arial", 12);

        private void datosFactura2(object obj, PrintPageEventArgs ev)
        {
            int[] x = { 50, 135, 215, 295, 665, 760 };
            int firstY = 225;
            int y = 20;
            StringFormat formatter = new StringFormat();
            //formatter.LineAlignment = StringAlignment.Center;
            formatter.Alignment = StringAlignment.Far;
            Font font = new Font("Arial Unicode MS", 10, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Gray);

            //Puntos de dibujo

            ev.Graphics.DrawString(txtClienteFact.Text, font, brush, new Point(90, 62));//, formatter);
            ev.Graphics.DrawString(medidorDir, font, brush, new Point(105, 85));//, formatter);
            ev.Graphics.DrawString("Tungurahua", font, brush, new Point(330, 115));//, formatter);
            ev.Graphics.DrawString(txtMedidorFact.Text, font, brush, new Point(120, 155));//, formatter);
            ev.Graphics.DrawString(clienteCed, font, brush, new Point(315, 155));//, formatter);
            ev.Graphics.DrawString(DateTime.Now.Day.ToString(), font, brush, new Point(465, 115));//, formatter);
            ev.Graphics.DrawString(DateTime.Now.Month.ToString(), font, brush, new Point(530, 115));//, formatter);
            ev.Graphics.DrawString(DateTime.Now.Year.ToString(), font, brush, new Point(590, 115));//, formatter);

            foreach (DataGridViewRow row in dgvPagar.Rows)
            {
                ev.Graphics.DrawString(row.Cells["anterior"].Value.ToString(), font, brush, new Point(x[0], firstY));//, formatter);
                ev.Graphics.DrawString(row.Cells["actual"].Value.ToString(), font, brush, new Point(x[1], firstY));//, formatter);
                ev.Graphics.DrawString(row.Cells["cantidad"].Value.ToString(), font, brush, new Point(x[2], firstY));//, formatter);
                ev.Graphics.DrawString(row.Cells["detalle"].Value.ToString(), font, brush, new Point(x[3], firstY));//, formatter);
                ev.Graphics.DrawString(row.Cells["VUnitario"].Value.ToString(), font, brush, new Point(x[4], firstY), formatter);
                ev.Graphics.DrawString(row.Cells["VTotal"].Value.ToString(), font, brush, new Point(x[5], firstY), formatter);
                firstY += y;
            }

            firstY = 490;
            foreach (DataGridViewRow row in dgvTotal.Rows)
            {
                ev.Graphics.DrawString(row.Cells["total"].Value.ToString(), font, brush, new Point(x[5], firstY), formatter);
                firstY += y;
            }

        }

        public void Imprimir_Solicitud()
        {
            //como son: numero de copias, numero de paginas y seleccionar tipo de impresora
            PrintDocument formulario = new PrintDocument();
            formulario.PrintPage += new PrintPageEventHandler(datosFactura2);// Datos_Cliente);

            //PrintDialog printDialog1 = new PrintDialog();
            //printDialog1.Document = formulario;
            printPreviewDialog1.Document = formulario;
            //DialogResult result = printDialog1.ShowDialog();
            DialogResult result = printPreviewDialog1.ShowDialog();
            //PrintEventHandler handler = new PrintEventHandler()

            //if (formulario.BeginPrint)
            //{
            //    formulario.Print();
            //    MessageBox.Show("se guardo");
            //}
        }

        // ////////////////////////////////////


        private bool guardarDetalles()
        {
            DataTable ultimoPago = metodo.consultarDatos("SELECT id_pag FROM pagos order by fecha desc limit 1;");
            int codigoPago = Convert.ToInt32(ultimoPago.Rows[0][0].ToString());

            MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
            MySqlCommand cmd = new MySqlCommand("SpInsertDetalles", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            int count = 0;

            foreach (DataGridViewRow row in dgvPagar.Rows)
            {
                cnn.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("cod_pag", codigoPago);
                cmd.Parameters.AddWithValue("cantidad", Convert.ToInt32(row.Cells["cantidad"].Value));
                if (!row.Cells["idLect"].Value.Equals(""))
                    cmd.Parameters.AddWithValue("cod_lect", Convert.ToInt32(row.Cells["idLect"].Value));
                else
                    cmd.Parameters.AddWithValue("cod_lect", null);
                cmd.Parameters.AddWithValue("cod_rubro", Convert.ToInt32(row.Cells["idRubro"].Value));
                count += cmd.ExecuteReader().RecordsAffected;
                cnn.Close();

            }

            if (count > 0)
            {
                lblValores.Text = count.ToString();
                return true;
            }
            else
                return false;
        }


        private void guardarPago()
        {
            try
            {
                bool registro = false;
                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpInsertPagos", cnn);
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                if (estado == "cancelado")
                    cmd.Parameters.AddWithValue("numero", nfactura);
                else
                    cmd.Parameters.AddWithValue("numero", null);

                cmd.Parameters.AddWithValue("cod_cli", clienteID);
                cmd.Parameters.AddWithValue("id_med_p", medidorID);
                cmd.Parameters.AddWithValue("id_user", usuarioID);
                cmd.Parameters.AddWithValue("num_cuotas", 1);
                cmd.Parameters.AddWithValue("total", totalPago);
                cmd.Parameters.AddWithValue("estado", estado);
                cmd.Parameters.AddWithValue("observ", txtObservacion.Text);

                if (cmd.ExecuteReader().RecordsAffected > 0)
                {
                    if (guardarDetalles())
                    {
                        registro = actualizarLecturas();
                        if (rbAbono.Checked)
                            insertarAbono();
                    }
                    else
                        registro = false;
                }
                else
                    registro = false;

                cnn.Close();

                if (registro == true)
                {
                    MessageBox.Show("El pago se registró correctamente");
                    btnPagar.Text = "        Finalizar";
                    cambiarNumPago();
                }
                else
                {
                    MessageBox.Show("No se ha podido ingresar la factura");
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void insertarAbono() {
            try
            {
                DataTable ultimoPago = metodo.consultarDatos("SELECT id_pag FROM pagos order by fecha desc limit 1;");
                int codigoPago = codigoDePago;//Convert.ToInt32(ultimoPago.Rows[0][0].ToString());

                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpInsertAbonos", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                // valor // cod_pag  // observ
                cmd.Parameters.AddWithValue("recibo", nrecibo);
                cmd.Parameters.AddWithValue("valor", Convert.ToDouble(dgvSaldos.Rows[1].Cells[1].Value));
                cmd.Parameters.AddWithValue("cod_pag", codigoPago);
                cmd.Parameters.AddWithValue("observ", txtObservacion.Text);
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                //da.Fill(dataTable);
                //dttMed = dataTable;
                //lbxMedidores.DataSource = dataTable;
                //lbxMedidores.ValueMember = "id_med";
                //lbxMedidores.DisplayMember = "medidor";

                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private bool actualizarLecturas()
        {
            MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
            MySqlCommand cmd;
            int resultado = -1;
            string est, sql;

            if (rbFactura.Checked)
                est = "'cancelado'";
            else
                est = "'abonado'";

            foreach (DataGridViewRow row in dgvPagar.Rows)
            {
                if (!row.Cells["idLect"].Value.Equals(""))
                {
                    sql = "update lecturas set estado = " + est + " where id_lect = " + row.Cells["idLect"].Value;
                    cmd = new MySqlCommand(sql, cnn);
                    cnn.Open();
                    resultado = cmd.ExecuteNonQuery();
                    MessageBox.Show(row.Cells["idLect"].Value.ToString());
                    cnn.Close();
                }
            }

            if (resultado > -1)
                return true;
            else
                return false;

        }


        private void txtMedidor_TextChanged(object sender, EventArgs e)
        {
            string sql = "select distinct c.codigo, c.ced, c.Nombre, c.Direccion, c.Tipo " +
                            " from clientes c, medidores m " +
                            " where m.cod_cli = c.codigo " +
                            " and m.id_med like '%" + txtMedidor.Text + "%'";
            if (txtMedidor.Text.Trim().Length > 0)
                metodo.llenarGrid(dgvClientes, sql);
            else
                filtrarClientes(dtt);
        }

        private void dgvSaldos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvSaldos.Rows[0].Cells[1].ReadOnly = false;
        }

        private DataTable nombreRubro(int id_rub)
        {
            string sql = "select nombre, valor from rubros where id_rub=" + id_rub;
            return metodo.consultarDatos(sql);
        }

        private void btnAgregarRubro_Click(object sender, EventArgs e)
        {
            AgregarRubros rubros = new AgregarRubros();
            DialogResult res = rubros.ShowDialog();
            DataTable dt;
            if (res == DialogResult.OK)
            {
                //recuperando la variable publica del formulario 2
                for (int i = 0; i < rubros.nuevoValor.Length; i++)
                {
                    string sql = "select nombre, valor from rubros " +
                        "where id_rub=" + rubros.nuevoValor[i];
                    dt = metodo.consultarDatos(sql);
                    dgvPagar.Rows.Add(i, rubros.nuevoValor[i],
                                   "", "", "", "1",
                                   dt.Rows[0][0].ToString(),
                                   dt.Rows[0][1].ToString(),
                                   dt.Rows[0][1].ToString());
                }

                sumarTotales();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminarRubro_Click(object sender, EventArgs e)
        {
            if (dgvPagar.CurrentRow.Cells["idLect"].Value.ToString().Equals(""))
            {
                dgvPagar.Rows.RemoveAt(dgvPagar.CurrentRow.Index);
                sumarTotales();
            }
            else
                MessageBox.Show("No se pueden eliminar registros de lecturas", "Error");
        }

        private void dgvPagar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPagar.CurrentRow.Cells["idLect"].Value.ToString().Equals(""))
            {
                DataGridViewCell cell = dgvPagar.Rows[e.RowIndex].Cells["cantidad"];
                dgvPagar.CurrentCell = cell;
                dgvPagar.CurrentCell.ReadOnly = false;
                dgvPagar.BeginEdit(true);
            }
            else
                dgvPagar.CurrentCell.ReadOnly = true;
        }

        private void dgvPagar_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dgvPagar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvSaldos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPagar_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Validamos si no es una fila nueva
            if (!dgvPagar.Rows[e.RowIndex].IsNewRow)
            {
                //Sólo controlamos el dato de la columna 0
                if (e.ColumnIndex == 5)
                {
                    int newInteger;
                    if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                    {
                        MessageBox.Show("El valor introducido no es válido", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvPagar.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo int";
                        e.Cancel = true;
                    }
                    else
                    {
                        double vTotal = newInteger * Convert.ToDouble(dgvPagar.Rows[e.RowIndex].Cells["VUnitario"].Value);
                        dgvPagar.Rows[e.RowIndex].Cells["VTotal"].Value = String.Format("{0:.00}", vTotal);
                        sumarTotales();

                    }
                }
            }
        }

        private void dgvPagar_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sumarAbono(double abonoActual)
        {
            double saldoAnterior = Convert.ToDouble(dgvSaldos.Rows[0].Cells[1].Value);
            //double abonoActual = Convert.ToDouble(dgvSaldos.Rows[1].Cells[1].Value);
            double total = Convert.ToDouble(dgvTotal.Rows[4].Cells[1].Value);
            double saldoActual;
            if (saldoAnterior > 0)
                saldoActual = saldoAnterior - abonoActual;
            else
                saldoActual = total - abonoActual;
            dgvSaldos.Rows[2].Cells[1].Value = saldoActual;
        }

        private void dgvSaldos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSaldos.CurrentRow.Index == 1)
            {
                DataGridViewCell cell = dgvSaldos.CurrentRow.Cells[1];
                dgvSaldos.CurrentCell = cell;
                dgvSaldos.CurrentCell.ReadOnly = false;
                dgvSaldos.BeginEdit(true);
            }
            else
                dgvSaldos.CurrentCell.ReadOnly = true;
        }

        private void dgvSaldos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //Validamos si no es una fila nueva
                if (!dgvSaldos.Rows[e.RowIndex].IsNewRow)
                {
                    //Sólo controlamos el dato de la columna 0
                    if (e.ColumnIndex == 1)
                    {
                        double newValue;
                        if (!double.TryParse(e.FormattedValue.ToString(),
                        out newValue))
                        {
                            MessageBox.Show("El valor introducido no es válido", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvSaldos.Rows[1].Cells[1].Value = 0;
                            dgvSaldos.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo double";
                            e.Cancel = true;
                        }
                        else
                        {
                            //double vTotal = newValue * Convert.ToDouble(dgvPagar.Rows[e.RowIndex].Cells["VUnitario"].Value);
                            //dgvPagar.Rows[e.RowIndex].Cells["VTotal"].Value = String.Format("{0:.00}", vTotal);
                            dgvSaldos.Rows[e.RowIndex].Cells[1].Value = String.Format("{0:0.00}", newValue);
                            
                            sumarAbono(Convert.ToDouble(dgvSaldos.Rows[1].Cells[1].Value));

                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void printPreviewDialog1_Click(object sender, EventArgs e)
        {

        }

        private void DocumentOnEndPrint_Click(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void dgvSaldos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMedidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else 
            //if(e.KeyChar == '\'')
            if (!(char.IsLetter(e.KeyChar)) || e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }

        private void lbxMedidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrueba.Text = dttMed.Rows[lbxMedidores.SelectedIndex]["nombre"].ToString();
        }

    }
}
