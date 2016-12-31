using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

        MetodosGenerales metodo = new MetodosGenerales();
        DataTable dtt;

        public Lecturas()
        {
            InitializeComponent();
            string sql = "select * from lecturas";
            llenarGrid(dgvLecturas, sql);
        }

        private void llenarGrid(DataGridView gv, string select)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void LLenarGrid(string archivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";

            //esta cadena es para archivos excel 2007 y 2010
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            //para archivos de 97-2003 usar la siguiente cadena
            //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
                    dgvLecturas.DataSource = dataSet.Tables[0]; //le asignamos al DataGridView el contenido del dataSet
                    conexion.Close();//cerramos la conexion
                    dgvLecturas.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox
                label34.Text = dialog.FileName;
                //hoja = txtHoja.Text; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                LLenarGrid(label34.Text, "Sheet1"); //se manda a llamar al metodo

                dgvLecturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las
                //columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
            }
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

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            importarExcel(dgvLecturas, "Sheet1");
        }

        OleDbConnection connect;
        OleDbDataAdapter MyDataAdapter;
        DataTable dt;


        public void importarExcel(DataGridView dgv, String nombreHoja)
        {
            String ruta = "";
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files |*.xlsx";
                openfile1.Title = "Seleccione el archivo de Excel";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }
                }

                connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                MyDataAdapter = new OleDbDataAdapter("Select * from [" + nombreHoja + "$]", connect);
                dt = new DataTable();
                MyDataAdapter.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
