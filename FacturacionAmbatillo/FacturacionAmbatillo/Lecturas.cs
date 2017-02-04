using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FacturacionAmbatillo
{
    public partial class Lecturas : Form
    {
        //cambiar cadena de conexion

        // cadena de conexion al fids 
        //string myConnectionString = "server=tesisfids.com;uid=tesisfid_aguas;" +
        //          "pwd=Mysql007008%;database=tesisfid_agua;";
        // cadena de conexion local 

        Conexion conn = new Conexion();
        string myConnectionString;
        DataTable ddt;
        int id1;

        public Lecturas()
        {
            InitializeComponent();
            myConnectionString = conn.MyConString;
            label1.Text = "Fecha: "+DateTime.Now.ToLongDateString();
            
            dataGridView1.DataSource = selectAll();
            controlDatagridView();
            label2.Text = "Filas Insertadas: ";
            control();
                  
        }

        private void openDialog()
        {
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
                    insert(nuevo.Trim());
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error,no se puede leer el archivo" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

       
        public bool insert(string path)
        {
            bool correcto = true;
            MySqlConnection conn = null;
            int result = 0;
            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                //comando sql que permite importar un archivo cvs a mysql
                string sql = "LOAD DATA LOCAL INFILE \'" + path + "\' INTO TABLE lecturas " +
  " FIELDS TERMINATED BY ';' " +
    " LINES TERMINATED BY '\r\n' " +
    " IGNORE 1 LINES " +
    " ( id_med_p , lec_act ) ";
                //en el caso de Fields termined by puede ser por (, o ;) depede de la version del excel
                // entre parentesis van el nombre de las columnas que se van a introducir en la tabla
                cmd.CommandText = sql;
                cmd.Prepare();

                 result=cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Las lecturas del  "+DateTime.Now.ToShortDateString() + " fueron insertas correctamente, filas insertadas: " + result, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    correcto = true;
                    dataGridView1.DataSource = selectAll();
                    control();
                    label2.Text = "Filas Insertadas: " + result;

                }
                else
                {
                    correcto = false;
                    MessageBox.Show("Las lecturas de este mes " +
                        DateTime.Now.ToShortDateString() + " ya fueron insertadas, revise la tabla y verifique las fechas y los valores porfavor... ","Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.DataSource = selectAll();
                    label2.Text = "Filas Insertadas: " + result;
                }
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message +" filas agregadas: "+ result, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        public int countProblems()
        {
            int filasMalas = 0;
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();

                string stm = "SELECT id_lect,id_med_p,lec_ant,lec_act,cant_total,nombre,estado,observ " +
"from lecturas, categorias " +
"where fecha like concat('%', Date_format(now(), '%Y-%m-%d'), '%') " +
"and cod_cat = codigo "+
" and cant_total <=0 ; ";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        filasMalas++;
                    }
                }
                rdr.Close();
            }
            catch (MySqlException ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                conn.Close();

            }
            return filasMalas;
        }

        public DataTable selectAll()
        {
           
            MySqlConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();

                string stm = "SELECT id_lect,id_med_p,lec_ant,lec_act,cant_total,nombre,estado,observ "+
"from lecturas, categorias "+
"where fecha like concat('%', Date_format(now(), '%Y-%m-%d'), '%') "+
"and cod_cat = codigo; ";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (MySqlException ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                conn.Close();

            }
            return dt;
          
        }

        public DataTable selectErrores()
        {
            List<Lectura> lista = new List<Lectura>();
            MySqlConnection conn = null;
            MySqlDataReader rdr = null;
            DataTable dt = new DataTable();
            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
               
                string stm = "SELECT id_lect,id_med_p,lec_ant,lec_act,cant_total,nombre,estado,observ " +
"from lecturas, categorias " +
"where fecha like concat('%', Date_format(now(), '%Y-%m-%d'), '%') " +
"and cod_cat = codigo " +
" and cant_total <=0 ; ";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd); 
                adapter.Fill(dt);
               
                
            }
            catch (MySqlException ex)
            {
                //Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                conn.Close();

            }
            return dt;
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            openDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void control()
        {
            int filas = countProblems();
            if (filas>0)
            {
                btnPloblem.Enabled = true;
                btnPloblem.Text = "Problemas (" + filas+ ")";

            }
            else
            {
                btnPloblem.Enabled = false;
                btnPloblem.Text = "Problemas (" + filas + ")";
            }
        }
        private void btnPloblem_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource= selectErrores();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Lectura lectura = new Lectura();
            string id;
            id =  dataGridView1.Rows[e.RowIndex].Cells["id_lect"].Value.ToString();
            if (id != "")
            {
                
                lectura.Id= Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells["id_lect"].Value.ToString());
                lectura.Lec_ant= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["lec_ant"].Value.ToString());
                lectura.Lec_act = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["lec_act"].Value.ToString());
                int result = update(lectura);
                
                if (result>0)
                {
                    lblmsj.ForeColor = Color.Green;
                    lblmsj.Text = "Se actualizo correctamente .!";
                    control();
                    dataGridView1.DataSource= selectAll();
                  
                    int cantidad = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["cant_total"].Value.ToString());
                    if (cantidad<= 0)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        cell.ErrorText = "valor no valido";
                    }
                    controlDatagridView();

                }
                else
                {
                    lblmsj.ForeColor = Color.Red;
                    lblmsj.Text = "Ninguna fila selecionada.!";
                    control();
                    ddt = new DataTable();
                    dataGridView1.DataSource = selectAll();
                    controlDatagridView();
                }



            }
            
        }

        private int update(Lectura lectura)
        {
            int resultado=0;
            try
            {
                MySqlConnection cnn = new MySqlConnection(myConnectionString);
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SpUpdateLecturas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_lect", lectura.Id);
                cmd.Parameters.AddWithValue("lec_ant", lectura.Lec_ant);
                cmd.Parameters.AddWithValue("lec_act", lectura.Lec_act);
                resultado = cmd.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            


            return resultado;
        }

        private void insertGrid(string medidor,string lectura)
        {
            int resultado = 0;
            try
            {
                MySqlConnection cnn = new MySqlConnection(myConnectionString);
                cnn.Open();

               


                    string sql = "insert into lecturas(id_med_p,lec_act) values(@id_med_p,@lec_act); ";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_med_p", medidor);
                    cmd.Parameters.AddWithValue("@lec_act", Convert.ToInt32(lectura));

                    resultado = cmd.ExecuteNonQuery();
                    if (resultado > 0)
                    {

                        dataGridView1.DataSource = selectAll();
                        control();
                        lblmsj.ForeColor = Color.Green;
                        lblmsj.Text = "Inserción correcta";

                    }
                    else
                    {

                        dataGridView1.DataSource = selectAll();
                        lblmsj.ForeColor = Color.Red;
                        lblmsj.Text = "Inserción incorrecta ";
                    }
               
                cnn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void delete(string id)
        {
            int resultado = 0;
            try
            {
                MySqlConnection cnn = new MySqlConnection(myConnectionString);
                cnn.Open();




                string sql = "delete from lecturas where lecturas.id_lect=@id_lect; ";
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@id_lect", Convert.ToInt32(id));

                resultado = cmd.ExecuteNonQuery();
                

                if (resultado > 0)
                {

                    dataGridView1.DataSource = selectAll();
                    control();
                    lblmsj.ForeColor = Color.Green;
                    lblmsj.Text = "Borrado correcto";

                }
                else
                {

                    dataGridView1.DataSource = selectAll();
                    lblmsj.ForeColor = Color.Red;
                    lblmsj.Text = "Borrado Incorrecto..! ";
                }

                cnn.Close();
            }
            catch (Exception e)
            {

                MessageBox.Show("Mensaje: "+e.Message, "Error ",MessageBoxButtons.OK,MessageBoxIcon.Error );

            }

        }
        
            
        private void controlDatagridView()
        {

            dataGridView1.Columns["id_lect"].ReadOnly = true;
            dataGridView1.Columns["id_med_p"].ReadOnly = false;
            dataGridView1.Columns["lec_ant"].ReadOnly = true;
            dataGridView1.Columns["lec_act"].ReadOnly = false;
            dataGridView1.Columns["cant_total"].ReadOnly = true;
            dataGridView1.Columns["nombre"].ReadOnly = true;
            dataGridView1.Columns["estado"].ReadOnly = true;
            dataGridView1.Columns["observ"].ReadOnly = true;

        }

        private void lblPath_Click(object sender, EventArgs e)
        {

        }

        private void actualizarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
            
           
            dataGridView1.Columns["lec_ant"].ReadOnly = false;
            dataGridView1.Columns["lec_act"].ReadOnly = false;
            int currentRow = dataGridView1.CurrentCell.RowIndex;
            //code to execute
            dataGridView1.Rows[currentRow].Selected = true;
            dataGridView1.CurrentCell = dataGridView1.Rows[currentRow].Cells[3];
            dataGridView1.BeginEdit(true);
        }

        

      
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int currentRow = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows[currentRow].Selected = true;
                string id = dataGridView1.Rows[currentRow].Cells["id_lect"].Value.ToString();


                if (e.KeyData == Keys.Back || e.KeyCode == Keys.Delete)
                {
                    DialogResult d = MessageBox.Show("Seguro que desea borrar?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (d == DialogResult.OK)
                    {
                        delete(id);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Mensaje: "+ ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentRow = dataGridView1.CurrentCell.RowIndex;
            //code to execute
            dataGridView1.Rows[currentRow].Selected = true;
            try
            {
                string medidor = dataGridView1.Rows[currentRow].Cells["id_med_p"].Value.ToString();
                string lecturas = dataGridView1.Rows[currentRow].Cells["lec_act"].Value.ToString();
                if (medidor != "" && lecturas != "")
                {
                    insertGrid(medidor, lecturas);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Mensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dataGridView1.Rows[e.RowIndex].ErrorText = "";
                int newInteger;
                if (dataGridView1.Rows[e.RowIndex].IsNewRow)
                    return;
                if (!int.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    dataGridView1.Rows[e.RowIndex].ErrorText = "La Lectura Actual debe ser un número entero!.";
                }
            }
        }
    }
}
