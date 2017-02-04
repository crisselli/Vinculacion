using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionAmbatillo
{
    public partial class AgregarRubros : Form
    {
        MetodosGenerales metodo = new MetodosGenerales();

        public AgregarRubros()
        {
            InitializeComponent();
            metodo.llenarGridSP(dgvRubros, "SpSelectRubros");
            //dgvRubros.Rows[0].Visible = false;
            //dgvRubros.Rows[1].Visible = false;
            dgvRubros.Rows.RemoveAt(1);
            dgvRubros.Rows.RemoveAt(0);
            dgvRubros.Columns[1].Visible = false;
            dgvRubros.Columns[4].Visible = false;
            
            dgvRubros.Columns[2].HeaderText = "Rubro";
            dgvRubros.Columns[3].HeaderText = "V.Unitario";
            dgvRubros.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRubros.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
        }

        public int[] nuevoValor;
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))//Columna de checks
                {
                    i++;
                }
            }
            nuevoValor = new int[i];
            int j = 0;
            foreach (DataGridViewRow row in dgvRubros.Rows)
            {
                
                if (Convert.ToBoolean(row.Cells[0].Value))//Columna de checks
                {
                    nuevoValor[j] = Convert.ToInt32(row.Cells[1].Value);
                    j++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            foreach(DataGridViewRow row in dgvRubros.Rows)
            {

                if (Convert.ToBoolean(row.Cells[0].Value))//Columna de checks
                {
                    label1.Text += row.Cells[1].Value.ToString();

                }
            }
        }
    }
}
