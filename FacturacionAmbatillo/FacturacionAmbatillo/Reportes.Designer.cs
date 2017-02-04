namespace FacturacionAmbatillo
{
    partial class Reportes
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tesisfid_aguaDataSetDiario = new FacturacionAmbatillo.tesisfid_aguaDataSetDiario();
            this.SpReporteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnDiario = new System.Windows.Forms.Button();
            this.btnMensual = new System.Windows.Forms.Button();
            this.dataTable1TableAdapter1 = new FacturacionAmbatillo.tesisfid_aguaDataSetDiarioTableAdapters.DataTable1TableAdapter();
            this.rvDiario = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.rvMensual = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SpReporteTableAdapter = new FacturacionAmbatillo.tesisfid_aguaDataSetDiarioTableAdapters.SpReporteTableAdapter();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable1TableAdapter = new FacturacionAmbatillo.tesisfid_aguaDataSetDiarioTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tesisfid_aguaDataSetDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpReporteBindingSource)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable1";
            this.DataTable2BindingSource.DataSource = this.tesisfid_aguaDataSetDiario;
            // 
            // tesisfid_aguaDataSetDiario
            // 
            this.tesisfid_aguaDataSetDiario.DataSetName = "tesisfid_aguaDataSetDiario";
            this.tesisfid_aguaDataSetDiario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SpReporteBindingSource
            // 
            this.SpReporteBindingSource.DataMember = "SpReporte";
            this.SpReporteBindingSource.DataSource = this.tesisfid_aguaDataSetDiario;
            // 
            // btnDiario
            // 
            this.btnDiario.Location = new System.Drawing.Point(94, 12);
            this.btnDiario.Name = "btnDiario";
            this.btnDiario.Size = new System.Drawing.Size(174, 39);
            this.btnDiario.TabIndex = 2;
            this.btnDiario.Text = "Reporte Diario";
            this.btnDiario.UseVisualStyleBackColor = true;
            this.btnDiario.Click += new System.EventHandler(this.btnDiario_Click);
            // 
            // btnMensual
            // 
            this.btnMensual.Location = new System.Drawing.Point(412, 12);
            this.btnMensual.Name = "btnMensual";
            this.btnMensual.Size = new System.Drawing.Size(174, 39);
            this.btnMensual.TabIndex = 3;
            this.btnMensual.Text = "Reporte Mensual";
            this.btnMensual.UseVisualStyleBackColor = true;
            this.btnMensual.Click += new System.EventHandler(this.btnMensual_Click);
            // 
            // dataTable1TableAdapter1
            // 
            this.dataTable1TableAdapter1.ClearBeforeFill = true;
            // 
            // rvDiario
            // 
            reportDataSource1.Name = "DataSetDiario";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.rvDiario.LocalReport.DataSources.Add(reportDataSource1);
            this.rvDiario.LocalReport.ReportEmbeddedResource = "FacturacionAmbatillo.ReporteDiario.rdlc";
            this.rvDiario.Location = new System.Drawing.Point(12, 172);
            this.rvDiario.Name = "rvDiario";
            this.rvDiario.Size = new System.Drawing.Size(723, 365);
            this.rvDiario.TabIndex = 4;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.btnGenerar);
            this.panel.Controls.Add(this.dtpFecha2);
            this.panel.Controls.Add(this.dtpFecha1);
            this.panel.Location = new System.Drawing.Point(12, 57);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(669, 97);
            this.panel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleccionar el rango de fechas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Desde";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(287, 58);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(123, 36);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Location = new System.Drawing.Point(374, 32);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha2.TabIndex = 1;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Location = new System.Drawing.Point(99, 32);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha1.TabIndex = 0;
            // 
            // rvMensual
            // 
            reportDataSource2.Name = "Mensual";
            reportDataSource2.Value = this.SpReporteBindingSource;
            this.rvMensual.LocalReport.DataSources.Add(reportDataSource2);
            this.rvMensual.LocalReport.ReportEmbeddedResource = "FacturacionAmbatillo.ReporteMensual.rdlc";
            this.rvMensual.Location = new System.Drawing.Point(13, 197);
            this.rvMensual.Name = "rvMensual";
            this.rvMensual.Size = new System.Drawing.Size(722, 340);
            this.rvMensual.TabIndex = 6;
            // 
            // SpReporteTableAdapter
            // 
            this.SpReporteTableAdapter.ClearBeforeFill = true;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.tesisfid_aguaDataSetDiario;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 549);
            this.Controls.Add(this.rvMensual);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.rvDiario);
            this.Controls.Add(this.btnMensual);
            this.Controls.Add(this.btnDiario);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Reportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tesisfid_aguaDataSetDiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpReporteBindingSource)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDiario;
        private System.Windows.Forms.Button btnMensual;
        private tesisfid_aguaDataSetDiario tesisfid_aguaDataSetDiario;
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
        private tesisfid_aguaDataSetDiarioTableAdapters.DataTable1TableAdapter dataTable1TableAdapter1;
        private Microsoft.Reporting.WinForms.ReportViewer rvDiario;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private Microsoft.Reporting.WinForms.ReportViewer rvMensual;
        private System.Windows.Forms.BindingSource SpReporteBindingSource;
        private tesisfid_aguaDataSetDiarioTableAdapters.SpReporteTableAdapter SpReporteTableAdapter;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private tesisfid_aguaDataSetDiarioTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;



    }
}