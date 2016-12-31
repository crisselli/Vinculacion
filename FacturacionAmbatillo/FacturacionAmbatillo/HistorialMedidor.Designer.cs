namespace FacturacionAmbatillo
{
    partial class HistorialMedidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialMedidor));
            this.panelPagos = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbono = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtMedidor = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvMedidas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnContinuar = new System.Windows.Forms.Button();
            this.txtAbonoActual = new System.Windows.Forms.TextBox();
            this.lblAbonoActual = new System.Windows.Forms.Label();
            this.txtSaldoAnterior = new System.Windows.Forms.TextBox();
            this.lblSaldoAnterior = new System.Windows.Forms.Label();
            this.lblNumeroPago = new System.Windows.Forms.Label();
            this.lblTipoDePago = new System.Windows.Forms.Label();
            this.txtSaldoActual = new System.Windows.Forms.TextBox();
            this.lblSaldoActual = new System.Windows.Forms.Label();
            this.txtRecibi = new System.Windows.Forms.TextBox();
            this.lblRecibi = new System.Windows.Forms.Label();
            this.panelSaldo = new System.Windows.Forms.Panel();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.txtRecibi2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCambio2 = new System.Windows.Forms.TextBox();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.panelPagos.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidas)).BeginInit();
            this.panelSaldo.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPagos
            // 
            this.panelPagos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPagos.Controls.Add(this.menuStrip1);
            this.panelPagos.Location = new System.Drawing.Point(310, 387);
            this.panelPagos.Name = "panelPagos";
            this.panelPagos.Size = new System.Drawing.Size(64, 46);
            this.panelPagos.TabIndex = 43;
            this.panelPagos.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFactura,
            this.tsmiAbono});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(64, 44);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // tsmiFactura
            // 
            this.tsmiFactura.Name = "tsmiFactura";
            this.tsmiFactura.Size = new System.Drawing.Size(51, 19);
            this.tsmiFactura.Text = "Factura";
            this.tsmiFactura.Click += new System.EventHandler(this.tsmiFactura_Click);
            // 
            // tsmiAbono
            // 
            this.tsmiAbono.Name = "tsmiAbono";
            this.tsmiAbono.Size = new System.Drawing.Size(51, 19);
            this.tsmiAbono.Text = "Abono";
            this.tsmiAbono.Click += new System.EventHandler(this.tsmiAbono_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotal.Location = new System.Drawing.Point(97, 387);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(54, 17);
            this.lblTotal.TabIndex = 42;
            this.lblTotal.Text = "$ 3.40";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(26, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 41;
            this.label3.Text = "TOTAL:";
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.ImageIndex = 0;
            this.btnPagar.Location = new System.Drawing.Point(378, 386);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(51, 36);
            this.btnPagar.TabIndex = 40;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtMedidor
            // 
            this.txtMedidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedidor.Location = new System.Drawing.Point(105, 56);
            this.txtMedidor.Name = "txtMedidor";
            this.txtMedidor.Size = new System.Drawing.Size(80, 21);
            this.txtMedidor.TabIndex = 39;
            this.txtMedidor.Text = "002-084";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(105, 23);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(274, 21);
            this.txtNombre.TabIndex = 38;
            this.txtNombre.Text = "TORRES BUSTOS MARIO ELIECER";
            // 
            // dgvMedidas
            // 
            this.dgvMedidas.AllowUserToAddRows = false;
            this.dgvMedidas.AllowUserToDeleteRows = false;
            this.dgvMedidas.AllowUserToResizeColumns = false;
            this.dgvMedidas.AllowUserToResizeRows = false;
            this.dgvMedidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedidas.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvMedidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedidas.Location = new System.Drawing.Point(26, 96);
            this.dgvMedidas.Name = "dgvMedidas";
            this.dgvMedidas.ReadOnly = true;
            this.dgvMedidas.RowHeadersVisible = false;
            this.dgvMedidas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMedidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedidas.Size = new System.Drawing.Size(400, 267);
            this.dgvMedidas.TabIndex = 37;
            this.dgvMedidas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedidas_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "MEDIDOR:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "CLIENTE:";
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtras.ImageIndex = 0;
            this.btnAtras.ImageList = this.imageList1;
            this.btnAtras.Location = new System.Drawing.Point(446, 386);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(70, 36);
            this.btnAtras.TabIndex = 42;
            this.btnAtras.Text = "Atrás";
            this.btnAtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Visible = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "atras.png");
            this.imageList1.Images.SetKeyName(1, "pago.png");
            // 
            // btnContinuar
            // 
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinuar.ImageIndex = 1;
            this.btnContinuar.ImageList = this.imageList1;
            this.btnContinuar.Location = new System.Drawing.Point(522, 386);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(95, 36);
            this.btnContinuar.TabIndex = 41;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinuar.UseVisualStyleBackColor = true;
            // 
            // txtAbonoActual
            // 
            this.txtAbonoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAbonoActual.Location = new System.Drawing.Point(117, 34);
            this.txtAbonoActual.Name = "txtAbonoActual";
            this.txtAbonoActual.Size = new System.Drawing.Size(80, 23);
            this.txtAbonoActual.TabIndex = 40;
            this.txtAbonoActual.Text = "2.41";
            this.txtAbonoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAbonoActual
            // 
            this.lblAbonoActual.AutoSize = true;
            this.lblAbonoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbonoActual.Location = new System.Drawing.Point(15, 36);
            this.lblAbonoActual.Name = "lblAbonoActual";
            this.lblAbonoActual.Size = new System.Drawing.Size(96, 17);
            this.lblAbonoActual.TabIndex = 39;
            this.lblAbonoActual.Text = "Abono Actual:";
            // 
            // txtSaldoAnterior
            // 
            this.txtSaldoAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSaldoAnterior.Location = new System.Drawing.Point(117, 9);
            this.txtSaldoAnterior.Name = "txtSaldoAnterior";
            this.txtSaldoAnterior.Size = new System.Drawing.Size(80, 23);
            this.txtSaldoAnterior.TabIndex = 38;
            this.txtSaldoAnterior.Text = "10.00";
            this.txtSaldoAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSaldoAnterior
            // 
            this.lblSaldoAnterior.AutoSize = true;
            this.lblSaldoAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoAnterior.Location = new System.Drawing.Point(9, 12);
            this.lblSaldoAnterior.Name = "lblSaldoAnterior";
            this.lblSaldoAnterior.Size = new System.Drawing.Size(102, 17);
            this.lblSaldoAnterior.TabIndex = 37;
            this.lblSaldoAnterior.Text = "Saldo Anterior:";
            // 
            // lblNumeroPago
            // 
            this.lblNumeroPago.AutoSize = true;
            this.lblNumeroPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNumeroPago.Location = new System.Drawing.Point(515, 47);
            this.lblNumeroPago.Name = "lblNumeroPago";
            this.lblNumeroPago.Size = new System.Drawing.Size(79, 20);
            this.lblNumeroPago.TabIndex = 36;
            this.lblNumeroPago.Text = "0000456";
            // 
            // lblTipoDePago
            // 
            this.lblTipoDePago.AutoSize = true;
            this.lblTipoDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDePago.ForeColor = System.Drawing.Color.Navy;
            this.lblTipoDePago.Location = new System.Drawing.Point(515, 27);
            this.lblTipoDePago.Name = "lblTipoDePago";
            this.lblTipoDePago.Size = new System.Drawing.Size(115, 20);
            this.lblTipoDePago.TabIndex = 35;
            this.lblTipoDePago.Text = "FACTURA N°";
            // 
            // txtSaldoActual
            // 
            this.txtSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSaldoActual.Location = new System.Drawing.Point(117, 59);
            this.txtSaldoActual.Name = "txtSaldoActual";
            this.txtSaldoActual.Size = new System.Drawing.Size(80, 23);
            this.txtSaldoActual.TabIndex = 47;
            this.txtSaldoActual.Text = "2.41";
            this.txtSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSaldoActual
            // 
            this.lblSaldoActual.AutoSize = true;
            this.lblSaldoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoActual.Location = new System.Drawing.Point(7, 62);
            this.lblSaldoActual.Name = "lblSaldoActual";
            this.lblSaldoActual.Size = new System.Drawing.Size(104, 17);
            this.lblSaldoActual.TabIndex = 46;
            this.lblSaldoActual.Text = "Saldo Actual:";
            // 
            // txtRecibi
            // 
            this.txtRecibi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtRecibi.Location = new System.Drawing.Point(117, 84);
            this.txtRecibi.Name = "txtRecibi";
            this.txtRecibi.Size = new System.Drawing.Size(80, 23);
            this.txtRecibi.TabIndex = 45;
            this.txtRecibi.Text = "10.00";
            this.txtRecibi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRecibi
            // 
            this.lblRecibi.AutoSize = true;
            this.lblRecibi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecibi.Location = new System.Drawing.Point(60, 87);
            this.lblRecibi.Name = "lblRecibi";
            this.lblRecibi.Size = new System.Drawing.Size(51, 17);
            this.lblRecibi.TabIndex = 44;
            this.lblRecibi.Text = "Recibí:";
            // 
            // panelSaldo
            // 
            this.panelSaldo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelSaldo.Controls.Add(this.txtCambio);
            this.panelSaldo.Controls.Add(this.lblCambio);
            this.panelSaldo.Controls.Add(this.txtRecibi);
            this.panelSaldo.Controls.Add(this.txtSaldoActual);
            this.panelSaldo.Controls.Add(this.lblSaldoAnterior);
            this.panelSaldo.Controls.Add(this.lblSaldoActual);
            this.panelSaldo.Controls.Add(this.txtSaldoAnterior);
            this.panelSaldo.Controls.Add(this.lblAbonoActual);
            this.panelSaldo.Controls.Add(this.lblRecibi);
            this.panelSaldo.Controls.Add(this.txtAbonoActual);
            this.panelSaldo.Location = new System.Drawing.Point(33, 420);
            this.panelSaldo.Name = "panelSaldo";
            this.panelSaldo.Size = new System.Drawing.Size(215, 140);
            this.panelSaldo.TabIndex = 51;
            this.panelSaldo.Visible = false;
            // 
            // txtCambio
            // 
            this.txtCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCambio.Location = new System.Drawing.Point(117, 109);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(80, 23);
            this.txtCambio.TabIndex = 49;
            this.txtCambio.Text = "10.00";
            this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(33, 112);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(78, 17);
            this.lblCambio.TabIndex = 48;
            this.lblCambio.Text = "Su cambio:";
            // 
            // txtRecibi2
            // 
            this.txtRecibi2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtRecibi2.Location = new System.Drawing.Point(104, 36);
            this.txtRecibi2.Name = "txtRecibi2";
            this.txtRecibi2.Size = new System.Drawing.Size(80, 23);
            this.txtRecibi2.TabIndex = 40;
            this.txtRecibi2.Text = "2.41";
            this.txtRecibi2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Recibí:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTotal.Location = new System.Drawing.Point(104, 11);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(80, 23);
            this.txtTotal.TabIndex = 38;
            this.txtTotal.Text = "10.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "Su cambio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "TOTAL:";
            // 
            // txtCambio2
            // 
            this.txtCambio2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCambio2.Location = new System.Drawing.Point(104, 61);
            this.txtCambio2.Name = "txtCambio2";
            this.txtCambio2.Size = new System.Drawing.Size(80, 23);
            this.txtCambio2.TabIndex = 47;
            this.txtCambio2.Text = "2.41";
            this.txtCambio2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelTotal.Controls.Add(this.txtCambio2);
            this.panelTotal.Controls.Add(this.label5);
            this.panelTotal.Controls.Add(this.label6);
            this.panelTotal.Controls.Add(this.txtTotal);
            this.panelTotal.Controls.Add(this.label7);
            this.panelTotal.Controls.Add(this.txtRecibi2);
            this.panelTotal.Location = new System.Drawing.Point(254, 463);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(203, 97);
            this.panelTotal.TabIndex = 50;
            this.panelTotal.Visible = false;
            // 
            // HistorialMedidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(648, 576);
            this.Controls.Add(this.panelTotal);
            this.Controls.Add(this.panelSaldo);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.panelPagos);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.txtMedidor);
            this.Controls.Add(this.lblNumeroPago);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTipoDePago);
            this.Controls.Add(this.dgvMedidas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HistorialMedidor";
            this.Text = "Historial de Medidor";
            this.Load += new System.EventHandler(this.HistorialMedidor_Load);
            this.panelPagos.ResumeLayout(false);
            this.panelPagos.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedidas)).EndInit();
            this.panelSaldo.ResumeLayout(false);
            this.panelSaldo.PerformLayout();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPagos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFactura;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbono;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TextBox txtMedidor;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvMedidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.TextBox txtAbonoActual;
        private System.Windows.Forms.Label lblAbonoActual;
        private System.Windows.Forms.TextBox txtSaldoAnterior;
        private System.Windows.Forms.Label lblSaldoAnterior;
        private System.Windows.Forms.Label lblNumeroPago;
        private System.Windows.Forms.Label lblTipoDePago;
        private System.Windows.Forms.TextBox txtSaldoActual;
        private System.Windows.Forms.Label lblSaldoActual;
        private System.Windows.Forms.TextBox txtRecibi;
        private System.Windows.Forms.Label lblRecibi;
        private System.Windows.Forms.Panel panelSaldo;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.TextBox txtRecibi2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCambio2;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.ImageList imageList1;
    }
}