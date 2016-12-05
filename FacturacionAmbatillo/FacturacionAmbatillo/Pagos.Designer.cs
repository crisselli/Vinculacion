namespace FacturacionAmbatillo
{
    partial class Pagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagos));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.clbTipoDePago = new System.Windows.Forms.CheckedListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnAnularPago = new System.Windows.Forms.Button();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.btnDetalles);
            this.splitContainer1.Panel2.Controls.Add(this.btnAnularPago);
            this.splitContainer1.Panel2.Controls.Add(this.dgvPagos);
            this.splitContainer1.Size = new System.Drawing.Size(804, 506);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.clbTipoDePago);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dtpHasta);
            this.groupBox2.Controls.Add(this.dtpDesde);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnLimpiar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(804, 111);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BÚSQUEDA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(537, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 17);
            this.label9.TabIndex = 58;
            this.label9.Text = "Tipo de Pago:";
            // 
            // clbTipoDePago
            // 
            this.clbTipoDePago.CheckOnClick = true;
            this.clbTipoDePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTipoDePago.FormattingEnabled = true;
            this.clbTipoDePago.Items.AddRange(new object[] {
            "Facturas",
            "Recibos",
            "Abonos"});
            this.clbTipoDePago.Location = new System.Drawing.Point(540, 47);
            this.clbTipoDePago.Name = "clbTipoDePago";
            this.clbTipoDePago.Size = new System.Drawing.Size(107, 58);
            this.clbTipoDePago.TabIndex = 57;
            this.clbTipoDePago.SelectedIndexChanged += new System.EventHandler(this.clbTipoDePago_SelectedIndexChanged);
            this.clbTipoDePago.DoubleClick += new System.EventHandler(this.clbTipoDePago_DoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "Desde";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(288, 80);
            this.dtpHasta.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtpHasta.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(126, 22);
            this.dtpHasta.TabIndex = 50;
            this.dtpHasta.Value = new System.DateTime(2016, 8, 13, 0, 0, 0, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Checked = false;
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(83, 80);
            this.dtpDesde.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtpDesde.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(126, 22);
            this.dtpDesde.TabIndex = 49;
            this.dtpDesde.Value = new System.DateTime(2016, 6, 20, 0, 0, 0, 0);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(238, 81);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(45, 17);
            this.label32.TabIndex = 48;
            this.label32.Text = "Hasta";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(83, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(331, 22);
            this.txtNombre.TabIndex = 43;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombrePagos_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(23, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 17);
            this.label13.TabIndex = 44;
            this.label13.Text = "Nombre";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.ImageIndex = 0;
            this.btnLimpiar.ImageList = this.imageList1;
            this.btnLimpiar.Location = new System.Drawing.Point(440, 39);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(84, 31);
            this.btnLimpiar.TabIndex = 22;
            this.btnLimpiar.Tag = "HOLI";
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiarPagos_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "limpar.png");
            this.imageList1.Images.SetKeyName(1, "cancelar.png");
            this.imageList1.Images.SetKeyName(2, "historial.png");
            // 
            // btnDetalles
            // 
            this.btnDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalles.ImageIndex = 2;
            this.btnDetalles.ImageList = this.imageList1;
            this.btnDetalles.Location = new System.Drawing.Point(12, 300);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(84, 31);
            this.btnDetalles.TabIndex = 25;
            this.btnDetalles.Tag = "HOLI";
            this.btnDetalles.Text = "Detalles";
            this.btnDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Visible = false;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // btnAnularPago
            // 
            this.btnAnularPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnularPago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnularPago.ImageIndex = 1;
            this.btnAnularPago.ImageList = this.imageList1;
            this.btnAnularPago.Location = new System.Drawing.Point(111, 300);
            this.btnAnularPago.Name = "btnAnularPago";
            this.btnAnularPago.Size = new System.Drawing.Size(84, 31);
            this.btnAnularPago.TabIndex = 24;
            this.btnAnularPago.Tag = "HOLI";
            this.btnAnularPago.Text = "Anular";
            this.btnAnularPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnularPago.UseVisualStyleBackColor = true;
            this.btnAnularPago.Visible = false;
            this.btnAnularPago.Click += new System.EventHandler(this.btnAnularPago_Click);
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPagos.Location = new System.Drawing.Point(0, 0);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.RowHeadersVisible = false;
            this.dgvPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagos.Size = new System.Drawing.Size(804, 283);
            this.dgvPagos.TabIndex = 19;
            this.dgvPagos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPagos_MouseClick);
            // 
            // Pagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 506);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Pagos";
            this.Text = "Pagos";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox clbTipoDePago;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvPagos;
        private System.Windows.Forms.Button btnAnularPago;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnDetalles;
    }
}