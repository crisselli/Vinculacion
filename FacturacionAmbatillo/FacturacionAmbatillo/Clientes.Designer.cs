namespace FacturacionAmbatillo
{
    partial class Clientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clientes));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMedidor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoDeUsuario = new System.Windows.Forms.ComboBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnMedidas = new System.Windows.Forms.Button();
            this.lbxMedidores = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpInicio = new System.Windows.Forms.TabPage();
            this.tpHistorial = new System.Windows.Forms.TabPage();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMedidorHist = new System.Windows.Forms.TextBox();
            this.txtClienteHist = new System.Windows.Forms.TextBox();
            this.dgvMedidas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.tpFactura = new System.Windows.Forms.TabPage();
            this.lblValores = new System.Windows.Forms.Label();
            this.dgvSaldos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNumeroPago = new System.Windows.Forms.Label();
            this.lblTipoDePago = new System.Windows.Forms.Label();
            this.rbCredito = new System.Windows.Forms.RadioButton();
            this.rbAbono = new System.Windows.Forms.RadioButton();
            this.rbFactura = new System.Windows.Forms.RadioButton();
            this.btnPagar = new System.Windows.Forms.Button();
            this.dgvTotal = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMedidorFact = new System.Windows.Forms.TextBox();
            this.txtClienteFact = new System.Windows.Forms.TextBox();
            this.dgvPagar = new System.Windows.Forms.DataGridView();
            this.i = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAtrasFact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpInicio.SuspendLayout();
            this.tpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidas)).BeginInit();
            this.tpFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagar)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.btnModificar);
            this.splitContainer1.Panel2.Controls.Add(this.btnNuevo);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(791, 539);
            this.splitContainer1.SplitterDistance = 116;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtMedidor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.txtCedula);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbTipoDeUsuario);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 103);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BÚSQUEDA";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtMedidor
            // 
            this.txtMedidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedidor.Location = new System.Drawing.Point(94, 36);
            this.txtMedidor.Name = "txtMedidor";
            this.txtMedidor.Size = new System.Drawing.Size(124, 21);
            this.txtMedidor.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "N° Medidor";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.ImageIndex = 0;
            this.btnLimpiar.ImageList = this.imageList1;
            this.btnLimpiar.Location = new System.Drawing.Point(686, 19);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(84, 31);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Tag = "";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "limpar.png");
            this.imageList1.Images.SetKeyName(1, "nuevo.png");
            this.imageList1.Images.SetKeyName(2, "editar.png");
            this.imageList1.Images.SetKeyName(3, "guardar.png");
            this.imageList1.Images.SetKeyName(4, "eliminar.png");
            this.imageList1.Images.SetKeyName(5, "cancelar.png");
            this.imageList1.Images.SetKeyName(6, "historial.png");
            this.imageList1.Images.SetKeyName(7, "pago.png");
            this.imageList1.Images.SetKeyName(8, "atras.png");
            this.imageList1.Images.SetKeyName(9, "siguiente.png");
            // 
            // txtCedula
            // 
            this.txtCedula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.Location = new System.Drawing.Point(297, 38);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(124, 21);
            this.txtCedula.TabIndex = 3;
            this.txtCedula.TextChanged += new System.EventHandler(this.txtCedula_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(94, 63);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(327, 21);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cédula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(534, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo de Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre";
            // 
            // cbTipoDeUsuario
            // 
            this.cbTipoDeUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoDeUsuario.FormattingEnabled = true;
            this.cbTipoDeUsuario.Items.AddRange(new object[] {
            "persona",
            "entidad"});
            this.cbTipoDeUsuario.Location = new System.Drawing.Point(649, 63);
            this.cbTipoDeUsuario.Name = "cbTipoDeUsuario";
            this.cbTipoDeUsuario.Size = new System.Drawing.Size(121, 23);
            this.cbTipoDeUsuario.TabIndex = 6;
            this.cbTipoDeUsuario.SelectedIndexChanged += new System.EventHandler(this.cbTipoDeUsuario_SelectedIndexChanged);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.ImageIndex = 2;
            this.btnModificar.ImageList = this.imageList1;
            this.btnModificar.Location = new System.Drawing.Point(99, 344);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(95, 31);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Tag = "";
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.ImageIndex = 1;
            this.btnNuevo.ImageList = this.imageList1;
            this.btnNuevo.Location = new System.Drawing.Point(12, 344);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(81, 31);
            this.btnNuevo.TabIndex = 23;
            this.btnNuevo.Tag = "";
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvClientes);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.btnMedidas);
            this.splitContainer2.Panel2.Controls.Add(this.lbxMedidores);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Size = new System.Drawing.Size(791, 327);
            this.splitContainer2.SplitterDistance = 627;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientes.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvClientes.Location = new System.Drawing.Point(0, 0);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(627, 327);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.TabStop = false;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            // 
            // btnMedidas
            // 
            this.btnMedidas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedidas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMedidas.ImageIndex = 6;
            this.btnMedidas.ImageList = this.imageList1;
            this.btnMedidas.Location = new System.Drawing.Point(0, 126);
            this.btnMedidas.Name = "btnMedidas";
            this.btnMedidas.Size = new System.Drawing.Size(160, 31);
            this.btnMedidas.TabIndex = 23;
            this.btnMedidas.Tag = "";
            this.btnMedidas.Text = "       Medidas";
            this.btnMedidas.UseVisualStyleBackColor = true;
            this.btnMedidas.Click += new System.EventHandler(this.btnMedidas_Click);
            // 
            // lbxMedidores
            // 
            this.lbxMedidores.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxMedidores.FormattingEnabled = true;
            this.lbxMedidores.Location = new System.Drawing.Point(0, 18);
            this.lbxMedidores.Name = "lbxMedidores";
            this.lbxMedidores.Size = new System.Drawing.Size(160, 108);
            this.lbxMedidores.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "MEDIDORES";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpInicio);
            this.tabControl1.Controls.Add(this.tpHistorial);
            this.tabControl1.Controls.Add(this.tpFactura);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(805, 571);
            this.tabControl1.TabIndex = 1;
            // 
            // tpInicio
            // 
            this.tpInicio.BackColor = System.Drawing.Color.White;
            this.tpInicio.Controls.Add(this.splitContainer1);
            this.tpInicio.Location = new System.Drawing.Point(4, 22);
            this.tpInicio.Name = "tpInicio";
            this.tpInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tpInicio.Size = new System.Drawing.Size(797, 545);
            this.tpInicio.TabIndex = 0;
            this.tpInicio.Text = "Inicio";
            this.tpInicio.Click += new System.EventHandler(this.tpInicio_Click);
            // 
            // tpHistorial
            // 
            this.tpHistorial.BackColor = System.Drawing.Color.White;
            this.tpHistorial.Controls.Add(this.lblMensaje);
            this.tpHistorial.Controls.Add(this.txtSubTotal);
            this.tpHistorial.Controls.Add(this.label8);
            this.tpHistorial.Controls.Add(this.txtMedidorHist);
            this.tpHistorial.Controls.Add(this.txtClienteHist);
            this.tpHistorial.Controls.Add(this.dgvMedidas);
            this.tpHistorial.Controls.Add(this.label6);
            this.tpHistorial.Controls.Add(this.label7);
            this.tpHistorial.Controls.Add(this.btnAtras);
            this.tpHistorial.Controls.Add(this.btnContinuar);
            this.tpHistorial.Location = new System.Drawing.Point(4, 22);
            this.tpHistorial.Name = "tpHistorial";
            this.tpHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tpHistorial.Size = new System.Drawing.Size(797, 545);
            this.tpHistorial.TabIndex = 1;
            this.tpHistorial.Text = "Historial";
            this.tpHistorial.Click += new System.EventHandler(this.tabHistorial_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(500, 79);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(47, 13);
            this.lblMensaje.TabIndex = 49;
            this.lblMensaje.Text = "Cálculos";
            this.lblMensaje.Visible = false;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(373, 352);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(95, 23);
            this.txtSubTotal.TabIndex = 48;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(302, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "TOTAL:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtMedidorHist
            // 
            this.txtMedidorHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedidorHist.Location = new System.Drawing.Point(84, 17);
            this.txtMedidorHist.Name = "txtMedidorHist";
            this.txtMedidorHist.Size = new System.Drawing.Size(80, 21);
            this.txtMedidorHist.TabIndex = 44;
            this.txtMedidorHist.TextChanged += new System.EventHandler(this.txtMedidorHist_TextChanged);
            // 
            // txtClienteHist
            // 
            this.txtClienteHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteHist.Location = new System.Drawing.Point(84, 44);
            this.txtClienteHist.Name = "txtClienteHist";
            this.txtClienteHist.Size = new System.Drawing.Size(274, 21);
            this.txtClienteHist.TabIndex = 43;
            this.txtClienteHist.TextChanged += new System.EventHandler(this.txtClienteHist_TextChanged);
            // 
            // dgvMedidas
            // 
            this.dgvMedidas.AllowUserToAddRows = false;
            this.dgvMedidas.AllowUserToDeleteRows = false;
            this.dgvMedidas.AllowUserToResizeColumns = false;
            this.dgvMedidas.AllowUserToResizeRows = false;
            this.dgvMedidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedidas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedidas.Location = new System.Drawing.Point(26, 79);
            this.dgvMedidas.Name = "dgvMedidas";
            this.dgvMedidas.ReadOnly = true;
            this.dgvMedidas.RowHeadersVisible = false;
            this.dgvMedidas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMedidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedidas.Size = new System.Drawing.Size(442, 267);
            this.dgvMedidas.TabIndex = 42;
            this.dgvMedidas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMedidas_CellMouseClick);
            this.dgvMedidas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvMedidas_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "Medidor:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 40;
            this.label7.Text = "Cliente:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtras.ImageIndex = 8;
            this.btnAtras.ImageList = this.imageList1;
            this.btnAtras.Location = new System.Drawing.Point(288, 399);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(79, 36);
            this.btnAtras.TabIndex = 43;
            this.btnAtras.Text = "        Atrás";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinuar.ImageIndex = 9;
            this.btnContinuar.ImageList = this.imageList1;
            this.btnContinuar.Location = new System.Drawing.Point(373, 399);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(95, 36);
            this.btnContinuar.TabIndex = 47;
            this.btnContinuar.Text = "        Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // tpFactura
            // 
            this.tpFactura.BackColor = System.Drawing.Color.White;
            this.tpFactura.Controls.Add(this.lblValores);
            this.tpFactura.Controls.Add(this.dgvSaldos);
            this.tpFactura.Controls.Add(this.lblNumeroPago);
            this.tpFactura.Controls.Add(this.lblTipoDePago);
            this.tpFactura.Controls.Add(this.rbCredito);
            this.tpFactura.Controls.Add(this.rbAbono);
            this.tpFactura.Controls.Add(this.rbFactura);
            this.tpFactura.Controls.Add(this.btnPagar);
            this.tpFactura.Controls.Add(this.dgvTotal);
            this.tpFactura.Controls.Add(this.txtMedidorFact);
            this.tpFactura.Controls.Add(this.txtClienteFact);
            this.tpFactura.Controls.Add(this.dgvPagar);
            this.tpFactura.Controls.Add(this.label9);
            this.tpFactura.Controls.Add(this.label10);
            this.tpFactura.Controls.Add(this.btnAtrasFact);
            this.tpFactura.Location = new System.Drawing.Point(4, 22);
            this.tpFactura.Name = "tpFactura";
            this.tpFactura.Size = new System.Drawing.Size(797, 545);
            this.tpFactura.TabIndex = 2;
            this.tpFactura.Text = "Factura";
            this.tpFactura.Click += new System.EventHandler(this.tpFactura_Click);
            // 
            // lblValores
            // 
            this.lblValores.AutoSize = true;
            this.lblValores.Location = new System.Drawing.Point(25, 73);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(48, 13);
            this.lblValores.TabIndex = 71;
            this.lblValores.Text = "Valores: ";
            this.lblValores.Visible = false;
            // 
            // dgvSaldos
            // 
            this.dgvSaldos.AllowUserToAddRows = false;
            this.dgvSaldos.AllowUserToDeleteRows = false;
            this.dgvSaldos.AllowUserToResizeColumns = false;
            this.dgvSaldos.AllowUserToResizeRows = false;
            this.dgvSaldos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaldos.BackgroundColor = System.Drawing.Color.White;
            this.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldos.ColumnHeadersVisible = false;
            this.dgvSaldos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvSaldos.Location = new System.Drawing.Point(311, 352);
            this.dgvSaldos.Name = "dgvSaldos";
            this.dgvSaldos.ReadOnly = true;
            this.dgvSaldos.RowHeadersVisible = false;
            this.dgvSaldos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaldos.Size = new System.Drawing.Size(181, 69);
            this.dgvSaldos.TabIndex = 70;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "total";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // lblNumeroPago
            // 
            this.lblNumeroPago.AutoSize = true;
            this.lblNumeroPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNumeroPago.Location = new System.Drawing.Point(563, 44);
            this.lblNumeroPago.Name = "lblNumeroPago";
            this.lblNumeroPago.Size = new System.Drawing.Size(96, 25);
            this.lblNumeroPago.TabIndex = 69;
            this.lblNumeroPago.Text = "0000456";
            // 
            // lblTipoDePago
            // 
            this.lblTipoDePago.AutoSize = true;
            this.lblTipoDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDePago.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoDePago.Location = new System.Drawing.Point(564, 17);
            this.lblTipoDePago.Name = "lblTipoDePago";
            this.lblTipoDePago.Size = new System.Drawing.Size(115, 20);
            this.lblTipoDePago.TabIndex = 68;
            this.lblTipoDePago.Text = "FACTURA N°";
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredito.Location = new System.Drawing.Point(328, 20);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(64, 19);
            this.rbCredito.TabIndex = 67;
            this.rbCredito.Text = "Crédito";
            this.rbCredito.UseVisualStyleBackColor = true;
            // 
            // rbAbono
            // 
            this.rbAbono.AutoSize = true;
            this.rbAbono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAbono.Location = new System.Drawing.Point(262, 20);
            this.rbAbono.Name = "rbAbono";
            this.rbAbono.Size = new System.Drawing.Size(60, 19);
            this.rbAbono.TabIndex = 66;
            this.rbAbono.Text = "Abono";
            this.rbAbono.UseVisualStyleBackColor = true;
            this.rbAbono.CheckedChanged += new System.EventHandler(this.rbAbono_CheckedChanged);
            // 
            // rbFactura
            // 
            this.rbFactura.AutoSize = true;
            this.rbFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFactura.Location = new System.Drawing.Point(182, 18);
            this.rbFactura.Name = "rbFactura";
            this.rbFactura.Size = new System.Drawing.Size(74, 21);
            this.rbFactura.TabIndex = 65;
            this.rbFactura.Text = "Factura";
            this.rbFactura.UseVisualStyleBackColor = true;
            this.rbFactura.CheckedChanged += new System.EventHandler(this.rbFactura_CheckedChanged);
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.ImageIndex = 7;
            this.btnPagar.ImageList = this.imageList1;
            this.btnPagar.Location = new System.Drawing.Point(600, 470);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(79, 36);
            this.btnPagar.TabIndex = 63;
            this.btnPagar.Text = "        Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // dgvTotal
            // 
            this.dgvTotal.AllowUserToAddRows = false;
            this.dgvTotal.AllowUserToDeleteRows = false;
            this.dgvTotal.AllowUserToResizeColumns = false;
            this.dgvTotal.AllowUserToResizeRows = false;
            this.dgvTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTotal.BackgroundColor = System.Drawing.Color.White;
            this.dgvTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotal.ColumnHeadersVisible = false;
            this.dgvTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.total});
            this.dgvTotal.Location = new System.Drawing.Point(498, 351);
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            this.dgvTotal.RowHeadersVisible = false;
            this.dgvTotal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotal.Size = new System.Drawing.Size(181, 113);
            this.dgvTotal.TabIndex = 62;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.HeaderText = "total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // txtMedidorFact
            // 
            this.txtMedidorFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedidorFact.Location = new System.Drawing.Point(84, 17);
            this.txtMedidorFact.Name = "txtMedidorFact";
            this.txtMedidorFact.Size = new System.Drawing.Size(80, 21);
            this.txtMedidorFact.TabIndex = 59;
            // 
            // txtClienteFact
            // 
            this.txtClienteFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteFact.Location = new System.Drawing.Point(84, 44);
            this.txtClienteFact.Name = "txtClienteFact";
            this.txtClienteFact.Size = new System.Drawing.Size(308, 21);
            this.txtClienteFact.TabIndex = 58;
            // 
            // dgvPagar
            // 
            this.dgvPagar.AllowUserToAddRows = false;
            this.dgvPagar.AllowUserToDeleteRows = false;
            this.dgvPagar.AllowUserToResizeColumns = false;
            this.dgvPagar.AllowUserToResizeRows = false;
            this.dgvPagar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagar.BackgroundColor = System.Drawing.Color.White;
            this.dgvPagar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.i,
            this.id,
            this.anterior,
            this.actual,
            this.cantidad,
            this.Detalle,
            this.VUnitario,
            this.VTotal});
            this.dgvPagar.Location = new System.Drawing.Point(26, 89);
            this.dgvPagar.Name = "dgvPagar";
            this.dgvPagar.ReadOnly = true;
            this.dgvPagar.RowHeadersVisible = false;
            this.dgvPagar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPagar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagar.Size = new System.Drawing.Size(653, 257);
            this.dgvPagar.TabIndex = 57;
            // 
            // i
            // 
            this.i.HeaderText = "i";
            this.i.Name = "i";
            this.i.ReadOnly = true;
            this.i.Visible = false;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // anterior
            // 
            this.anterior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.anterior.HeaderText = "L. Anterior";
            this.anterior.Name = "anterior";
            this.anterior.ReadOnly = true;
            this.anterior.Width = 80;
            // 
            // actual
            // 
            this.actual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.actual.HeaderText = "L. Actual";
            this.actual.Name = "actual";
            this.actual.ReadOnly = true;
            this.actual.Width = 74;
            // 
            // cantidad
            // 
            this.cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 74;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            // 
            // VUnitario
            // 
            this.VUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VUnitario.HeaderText = "V. Unitario";
            this.VUnitario.Name = "VUnitario";
            this.VUnitario.ReadOnly = true;
            this.VUnitario.Width = 81;
            // 
            // VTotal
            // 
            this.VTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VTotal.HeaderText = "V. Total";
            this.VTotal.Name = "VTotal";
            this.VTotal.ReadOnly = true;
            this.VTotal.Width = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 56;
            this.label9.Text = "Medidor:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 55;
            this.label10.Text = "Cliente:";
            // 
            // btnAtrasFact
            // 
            this.btnAtrasFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtrasFact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtrasFact.ImageIndex = 8;
            this.btnAtrasFact.ImageList = this.imageList1;
            this.btnAtrasFact.Location = new System.Drawing.Point(26, 461);
            this.btnAtrasFact.Name = "btnAtrasFact";
            this.btnAtrasFact.Size = new System.Drawing.Size(80, 36);
            this.btnAtrasFact.TabIndex = 51;
            this.btnAtrasFact.Text = "        Atrás";
            this.btnAtrasFact.UseVisualStyleBackColor = true;
            this.btnAtrasFact.Click += new System.EventHandler(this.btnAtrasFact_Click);
            // 
            // Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(805, 571);
            this.Controls.Add(this.tabControl1);
            this.Name = "Clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.Clientes_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpInicio.ResumeLayout(false);
            this.tpHistorial.ResumeLayout(false);
            this.tpHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidas)).EndInit();
            this.tpFactura.ResumeLayout(false);
            this.tpFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoDeUsuario;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnMedidas;
        private System.Windows.Forms.ListBox lbxMedidores;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtMedidor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpInicio;
        private System.Windows.Forms.TabPage tpHistorial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.TabPage tpFactura;
        private System.Windows.Forms.Button btnAtrasFact;
        private System.Windows.Forms.TextBox txtMedidorHist;
        private System.Windows.Forms.TextBox txtClienteHist;
        private System.Windows.Forms.DataGridView dgvMedidas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMedidorFact;
        private System.Windows.Forms.TextBox txtClienteFact;
        private System.Windows.Forms.DataGridView dgvPagar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn i;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn anterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn VUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn VTotal;
        private System.Windows.Forms.DataGridView dgvTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.RadioButton rbCredito;
        private System.Windows.Forms.RadioButton rbAbono;
        private System.Windows.Forms.RadioButton rbFactura;
        private System.Windows.Forms.Label lblNumeroPago;
        private System.Windows.Forms.Label lblTipoDePago;
        private System.Windows.Forms.DataGridView dgvSaldos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label lblValores;
    }
}