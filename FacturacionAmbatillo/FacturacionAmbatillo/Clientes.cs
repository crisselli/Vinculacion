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
            try { 
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            };

        }

        DataTable dataTable;
        double interes;

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
                
                //Marcar como predeterminado el siguiente pago
                if (result>0)
                {
                    dgvMedidas.Rows[0].Selected = false;
                    
                    bool abonado = false;
                    bool pendiente = false;
                    foreach (DataGridViewRow row in dgvMedidas.Rows) {
                        //Seleccionar todos con estado 'abonado'
                        if (row.Cells["Estado"].Value.Equals("abonado"))
                        {
                            row.Selected = true;
                            abonado = true;
                        }
                        //Seleccionar solo el siguiente pago pendiente
                        else if (abonado == false) {
                            if (row.Cells["Estado"].Value.Equals("pendiente") && pendiente == false)
                            {
                                row.Selected = true;
                                pendiente = true;
                            }
                        }
                    }
                

                // Calcular el interés por mora

                string sql = "SELECT valor FROM rubros where id_rub = 4; ";
                dataTable = metodo.consultarDatos(sql);

                //Cálculo del interés porcentual
                    //double interes = 1 + (Convert.ToDouble(dataTable.Rows[0][0].ToString()) / 100);

                //Interés de valor fijo
                interes = Convert.ToDouble(dataTable.Rows[0][0].ToString());

                //Calcular si es consumo normal o con interés
                foreach (DataGridViewRow row in dgvMedidas.Rows)
                {
                    int intervalo = Convert.ToInt32(row.Cells["Intervalo"].Value);
                    double valor = Convert.ToInt32(row.Cells["ValorCI"].Value);
                    //lblMensaje.Text += " intervalo:" + intervalo.ToString();
                    //blMensaje.Text += " Valor:" + valor.ToString();

                    //Mínimo un mes de retraso
                    if (intervalo > 0)
                        for (int j = 1; j <= intervalo; j++)
                        {
                            //valor *= interes;
                            valor += interes;
                        }
                        row.Cells["ValorCI"].Value = String.Format("{0:F}", valor);

                        //lblMensaje.Text += valor.ToString("N", CultureInfo.InvariantCulture);


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

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //DataGridViewRow row = new DataGridViewRow();
            int i = 0, codLect = 0;
            bool abonado = false;

            try {

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
                    
                        dgvPagar.Rows.Add(i, "", "", "", 
                                   intervalo,
                                   "Interés",
                                   interes,
                                   interes*intervalo);
                        i++;
                    }

                    dgvPagar.Rows.Add(i,
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
                dgvTotal.Rows.Add("Descuento", "0.00");
                dgvTotal.Rows.Add("IVA 0%", subtotal);
                dgvTotal.Rows.Add("IVA 12%", "0.00");
                dgvTotal.Rows.Add("TOTAL", subtotal);

                dgvTotal.Rows[0].Selected = false;
                dgvPagar.Rows[0].Selected = false;
                dgvSaldos.Rows[0].Selected = false;
                dgvPagar.ClearSelection();

            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            //Pasar al tab Factura
            tabControl1.SelectedTab = tabControl1.TabPages["tpFactura"];

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

        #region Imprimir

        private Image facturaModelo;

        private bool imprimirFactura(Image facturaActual) {
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

        private void dibujarFactura() {
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

            foreach (DataGridViewRow row in dgvPagar.Rows) {
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
            facturaModelo = FacturacionAmbatillo.Properties.Resources.Fact;
            //dibujarFactura();
            //guardarPago();

            Imprimir_Solicitud();

            //CaptureScreen();
            //printPreviewDialog1.Show();

        }

        #endregion

        // ////////////////////////////////////

        private Font fuente = new Font("Arial", 12);

        private void datosFactura(object obj, PrintPageEventArgs ev)
        {
            int[] x = { 50, 135, 215, 295, 665, 760 };
            int firstY = 265;
            int y = 20;
            StringFormat formatter = new StringFormat();
            //formatter.LineAlignment = StringAlignment.Center;
            //formatter.Alignment = StringAlignment.Center;
            Font font = new Font("Arial Unicode MS", 10, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Black);

            //Puntos de dibujo

            //ev.Graphics.DrawString(txtClienteFact.Text, font, brush, new Point(90, 102), formatter);
            //ev.Graphics.DrawString(direccionCliente, font, brush, new Point(105, 125), formatter);
            //ev.Graphics.DrawString("Tungurahua", font, brush, new Point(330, 155), formatter);
            //ev.Graphics.DrawString(txtMedidorFact.Text, font, brush, new Point(120, 195), formatter);
            //ev.Graphics.DrawString(cedulaCliente, font, brush, new Point(315, 195), formatter);
            //ev.Graphics.DrawString(DateTime.Now.Day.ToString(), font, brush, new Point(465, 155), formatter);
            //ev.Graphics.DrawString(DateTime.Now.Month.ToString(), font, brush, new Point(530, 155), formatter);
            //ev.Graphics.DrawString(DateTime.Now.Year.ToString(), font, brush, new Point(590, 155), formatter);

            foreach (DataGridViewRow row in dgvPagar.Rows)
            {
                ev.Graphics.DrawString(row.Cells["anterior"].Value.ToString(), font, brush, new Point(x[0], firstY), formatter);
                ev.Graphics.DrawString(row.Cells["actual"].Value.ToString(), font, brush, new Point(x[1], firstY), formatter);
                ev.Graphics.DrawString(row.Cells["cantidad"].Value.ToString(), font, brush, new Point(x[2], firstY), formatter);
                ev.Graphics.DrawString(row.Cells["detalle"].Value.ToString(), font, brush, new Point(x[3], firstY), formatter);
                ev.Graphics.DrawString(row.Cells["VUnitario"].Value.ToString(), font, brush, new Point(x[4], firstY), formatter);
                ev.Graphics.DrawString(row.Cells["VTotal"].Value.ToString(), font, brush, new Point(x[5], firstY), formatter);
                firstY += y;
            }

            firstY = 530;
            foreach (DataGridViewRow row in dgvTotal.Rows)
            {
                ev.Graphics.DrawString(row.Cells["total"].Value.ToString(), font, brush, new Point(x[5], firstY), formatter);
                firstY += y;
            }

        }

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

            //Este método contiene dos componentes muy importantes los cuales son:

            //PrintDocument y printDialog estos métodos definen las propiedades de impresión

            //como son: numero de copias, numero de paginas y seleccionar tipo de impresora
            PrintDocument formulario = new PrintDocument();
            formulario.PrintPage += new PrintPageEventHandler(datosFactura2);// Datos_Cliente);
            PrintDialog printDialog1 = new PrintDialog();
            //printDialog1.Document = formulario;
            printPreviewDialog1.Document = formulario;
            //DialogResult result = printDialog1.ShowDialog();
            DialogResult result = printPreviewDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    formulario.Print();
            //}
        }
        
        // ////////////////////////////////////


        private void guardarPago()
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpInsertPagos", cnn);
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cod_cli", clienteID);
                cmd.Parameters.AddWithValue("id_med_p", medidorDir);
                cmd.Parameters.AddWithValue("id_user", usuarioID);
                cmd.Parameters.AddWithValue("num_cuotas", 1);
                cmd.Parameters.AddWithValue("observ", " ");
                MySqlDataReader myreader = cmd.ExecuteReader();
                myreader.Read();

                if (myreader.HasRows)
                {
                    MessageBox.Show("Factura ingresada");
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

        private void lbxMedidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrueba.Text = dttMed.Rows[lbxMedidores.SelectedIndex]["nombre"].ToString();
        }

    }
}
