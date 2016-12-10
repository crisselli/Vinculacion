using MySql.Data.MySqlClient;
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
    public partial class Lecturas : Form
    {
        Conexion conexion = new Conexion();
        MySqlConnection conn;
        //cambiar cadena de conexion 
        //string myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=prueba;";

        public Lecturas()
        {
            InitializeComponent();
        }

        private void btnseleccionar_Click(object sender, EventArgs e)
        {
            // Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //propiedades del openDialogo prar subir  archivos filtrados
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Files (*.csv)|*.csv";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string dir = openFileDialog1.FileName;

                    string nuevo = dir;

                    //Console.WriteLine("Original string: \"{0}\"", dir);
                    //del path tomado remplazamos el \ por / para que sea legible desde mysql
                    nuevo = dir.Replace('\\', '/');
                    lblPath.Text = nuevo;
                    //usando el insert para la importacion de los datos 
                    if (insert(nuevo.Trim()))
                    {
                        MessageBox.Show("Lecturas ingresadas");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        //metodo para la insercion 

        public bool insert(string path)
        {
            bool correcto = true;
            MySqlConnection conn = null;
            try
            {   conn = new MySqlConnection(conexion.MyConString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                //comando sql que permite importar un archivo cvs a mysql
                string sql = "LOAD DATA LOCAL INFILE \'" + path + "\' INTO TABLE lecturas " +
                  " FIELDS TERMINATED BY ';' " +
                    " LINES TERMINATED BY '\r\n' " +
                    " IGNORE 1 LINES " +
                    "(codigo_medidor,lectura,observacion,codigo_categoria) ";

                //en el caso de Fields termined by puede ser por (, o ;) depede de la version del excel
                // entre parentesis van el nombre de las columnas que se van a introducir en la tabla
                cmd.CommandText = sql;
                cmd.Prepare();

                cmd.ExecuteNonQuery();
                correcto = true;
            }
            catch (Exception ex)
            {
                correcto = false;

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    correcto = true;

                }

            }
            return correcto;



        }
    }
}
