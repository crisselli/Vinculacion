namespace FacturacionAmbatillo
{
    partial class Lecturas
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnseleccionar = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.dgvLecturas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturas)).BeginInit();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.lblPath);
            this.splitContainer1.Panel1.Controls.Add(this.btnseleccionar);
            this.splitContainer1.Panel1.Controls.Add(this.label34);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox3);
            this.splitContainer1.Panel1.Controls.Add(this.label31);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.btnImprimir);
            this.splitContainer1.Panel2.Controls.Add(this.dgvLecturas);
            this.splitContainer1.Size = new System.Drawing.Size(804, 506);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(105, 30);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(89, 13);
            this.lblPath.TabIndex = 19;
            this.lblPath.Text = "No se selecciono";
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseleccionar.Location = new System.Drawing.Point(12, 24);
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.Size = new System.Drawing.Size(87, 23);
            this.btnseleccionar.TabIndex = 18;
            this.btnseleccionar.Text = "Seleccionar";
            this.btnseleccionar.UseVisualStyleBackColor = true;
            this.btnseleccionar.Click += new System.EventHandler(this.btnseleccionar_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(423, 57);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(99, 20);
            this.label34.TabIndex = 17;
            this.label34.Text = "31/07/2016";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Centro",
            "Esperanza",
            "Floresta",
            "Pasochoa",
            "Palama",
            "Providencia",
            "Rosario",
            "La Y"});
            this.comboBox3.Location = new System.Drawing.Point(108, 65);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(183, 21);
            this.comboBox3.TabIndex = 16;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(34, 68);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(55, 13);
            this.label31.TabIndex = 15;
            this.label31.Text = "BARRIOS";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.ImageIndex = 4;
            this.btnImprimir.Location = new System.Drawing.Point(14, 355);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(98, 36);
            this.btnImprimir.TabIndex = 43;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.button9_Click);
            // 
            // dgvLecturas
            // 
            this.dgvLecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLecturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLecturas.Location = new System.Drawing.Point(0, 0);
            this.dgvLecturas.Name = "dgvLecturas";
            this.dgvLecturas.RowHeadersVisible = false;
            this.dgvLecturas.Size = new System.Drawing.Size(804, 342);
            this.dgvLecturas.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Lecturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 506);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Lecturas";
            this.Text = "Lecturas";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridView dgvLecturas;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnseleccionar;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button1;
    }
}