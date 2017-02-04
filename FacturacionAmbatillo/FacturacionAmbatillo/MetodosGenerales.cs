using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionAmbatillo
{
    class MetodosGenerales
    {

        Conexion conexion = new Conexion();

        /* 
         * Método para llenar comboBox mediante stored procedures
         * cb - Nombre de la variable comboBox a llenar
         * selectProcedure - Nombre del procedimiento
         * mostrar - Nombre del valor a mostrar
         * valor - ID del valor a mostrar
         */
        public void llenarCombo(ComboBox cb, string selectProcedure, string mostrar, string valor)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand(selectProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);

                cb.DataSource = dataTable;
                cb.ValueMember = valor;
                cb.DisplayMember = mostrar;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        /* 
         * Metodo para llenar dataGridView mediante stored procedures
         * gv - Nombre de la variable dataGridView a llenar
         * selectedProcedure - Nombre del procedimiento
         */
        public void llenarGridSP(DataGridView gv, string selectProcedure)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand(selectProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);
                gv.DataSource = dataTable;
                conn.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }

        }

        /*
         *Método para llenar dataGridView mediante consulta sin Stored Procedures  
         */
        public void llenarGrid(DataGridView gv, string select)
        {
            MySqlConnection conn = new MySqlConnection(conexion.MyConString);
            MySqlCommand cmd = new MySqlCommand(select, conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);     
            gv.DataSource = dataTable;
            conn.Close();
        }

        /* 
         * Metodo para enviar una consulta idividual sin stored procedures
         * sql - Consulta preparada para enviar a la base
         */
        public DataTable consultarDatos(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            };

            return dt;
        }

        /* 
         * Metodo para enviar una consulta mediante stored procedures
         * selectedProcedure - Nombre del procedimiento
         */

        public DataTable consultarDatosSP(string selectProcedure)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlConnection conn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand(selectProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            };

            return dt;
        }

        /*
         * Método para incluir texto como marca de agua en textbox
         */
        public void hint(TextBox textbox, String Mensaje)
        {
            SendMessage(textbox.Handle, 0x1501, 1, Mensaje);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

    }
}
