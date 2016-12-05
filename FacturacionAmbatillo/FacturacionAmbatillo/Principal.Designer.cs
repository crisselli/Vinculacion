namespace FacturacionAmbatillo
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pbConfiguracion = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblReportes = new System.Windows.Forms.Label();
            this.lblLecturas = new System.Windows.Forms.Label();
            this.lblPagos = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbConfiguracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.splitContainer1.Panel1.Controls.Add(this.lblTitulo);
            this.splitContainer1.Panel1.Controls.Add(this.pbConfiguracion);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(998, 581);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTitulo.Location = new System.Drawing.Point(361, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(211, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "CLIENTES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbConfiguracion
            // 
            this.pbConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbConfiguracion.Image = global::FacturacionAmbatillo.Properties.Resources.configurar;
            this.pbConfiguracion.Location = new System.Drawing.Point(954, 5);
            this.pbConfiguracion.Name = "pbConfiguracion";
            this.pbConfiguracion.Size = new System.Drawing.Size(30, 30);
            this.pbConfiguracion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbConfiguracion.TabIndex = 2;
            this.pbConfiguracion.TabStop = false;
            this.pbConfiguracion.Click += new System.EventHandler(this.pbConfiguracion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.splitContainer2.Panel1.Controls.Add(this.lblReportes);
            this.splitContainer2.Panel1.Controls.Add(this.lblLecturas);
            this.splitContainer2.Panel1.Controls.Add(this.lblPagos);
            this.splitContainer2.Panel1.Controls.Add(this.lblClientes);
            this.splitContainer2.Size = new System.Drawing.Size(998, 534);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // lblReportes
            // 
            this.lblReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblReportes.Image = global::FacturacionAmbatillo.Properties.Resources.reportes1;
            this.lblReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReportes.Location = new System.Drawing.Point(0, 120);
            this.lblReportes.Name = "lblReportes";
            this.lblReportes.Size = new System.Drawing.Size(166, 40);
            this.lblReportes.TabIndex = 3;
            this.lblReportes.Text = "            Reportes";
            this.lblReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReportes.Visible = false;
            this.lblReportes.Click += new System.EventHandler(this.lblReportes_Click);
            // 
            // lblLecturas
            // 
            this.lblLecturas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLecturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLecturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecturas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblLecturas.Image = global::FacturacionAmbatillo.Properties.Resources.lecturas1;
            this.lblLecturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLecturas.Location = new System.Drawing.Point(0, 80);
            this.lblLecturas.Name = "lblLecturas";
            this.lblLecturas.Size = new System.Drawing.Size(166, 40);
            this.lblLecturas.TabIndex = 2;
            this.lblLecturas.Text = "            Lecturas";
            this.lblLecturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLecturas.Click += new System.EventHandler(this.lblLecturas_Click);
            // 
            // lblPagos
            // 
            this.lblPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblPagos.Image = global::FacturacionAmbatillo.Properties.Resources.factura1;
            this.lblPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPagos.Location = new System.Drawing.Point(0, 40);
            this.lblPagos.Name = "lblPagos";
            this.lblPagos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPagos.Size = new System.Drawing.Size(166, 40);
            this.lblPagos.TabIndex = 0;
            this.lblPagos.Text = "            Pagos";
            this.lblPagos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPagos.Click += new System.EventHandler(this.lblPagos_Click);
            // 
            // lblClientes
            // 
            this.lblClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblClientes.Image = ((System.Drawing.Image)(resources.GetObject("lblClientes.Image")));
            this.lblClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClientes.Location = new System.Drawing.Point(0, 0);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(166, 40);
            this.lblClientes.TabIndex = 1;
            this.lblClientes.Text = "            Clientes";
            this.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClientes.Click += new System.EventHandler(this.lblClientes_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 581);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbConfiguracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbConfiguracion;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblPagos;
        private System.Windows.Forms.Label lblReportes;
        private System.Windows.Forms.Label lblLecturas;
        private System.Windows.Forms.Label lblClientes;

    }
}