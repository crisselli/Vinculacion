using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionAmbatillo
{
    class ConfigUsuarios
    {
        Conexion conexion = new Conexion();
        MySqlConnection conn;
        MySqlCommand cmd;
        
        private string _ced;
        private string _nombres;
        private string _tel_cel;
        private string _paswd;
        private string _roles;
        private string _clave;
       
        public string Ced
        {
            get
            {
                return _ced;
            }

            set
            {
                _ced = value;
            }
        }

        public string Nombres
        {
            get
            {
                return _nombres;
            }

            set
            {
                _nombres = value;
            }
        }

        public string Tel_cel
        {
            get
            {
                return _tel_cel;
            }

            set
            {
                _tel_cel = value;
            }
        }

        public string Paswd
        {
            get
            {
                return _paswd;
            }

            set
            {
                _paswd = value;
            }
        }

        public string Roles
        {
            get
            {
                return _roles;
            }

            set
            {
                _roles = value;
            }
        }

        public string Clave
        {
            get
            {
                return _clave;
            }

            set
            {
                _clave = value;
            }
        }

        public int ingresarUsuario() {
            int result = 0;
            conn = new MySqlConnection(conexion.MyConString);
            cmd = new MySqlCommand("SpInsert_Usuarios", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("ced", Ced);
            cmd.Parameters.AddWithValue("nombres", Nombres);
            cmd.Parameters.AddWithValue("tel_cel", Tel_cel);
            cmd.Parameters.AddWithValue("paswd", Paswd);
            cmd.Parameters.AddWithValue("roles", Roles);

            result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public int modificarUsuarioPw()
        {
            int result = 0;
            conn = new MySqlConnection(conexion.MyConString);
            cmd = new MySqlCommand("SpUpdate_Usuarios", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            cmd.Parameters.AddWithValue("ced", Ced);
            cmd.Parameters.AddWithValue("nombres", Nombres);
            cmd.Parameters.AddWithValue("tel_cel", Tel_cel);
            cmd.Parameters.AddWithValue("paswd", Paswd);
            cmd.Parameters.AddWithValue("roles", Roles);

            result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
        
        public int modificarUsuario()
        {
            int result = 0;
            string sql = "update usuarios set nombres = @nombres, tel_cel = @tel_cel , roles = @roles where usuarios.ced = @ced";
            conn = new MySqlConnection(conexion.MyConString);
            cmd = new MySqlCommand(sql, conn);
            
            conn.Open();

            cmd.Parameters.AddWithValue("@ced", Ced);
            cmd.Parameters.AddWithValue("@nombres", Nombres);
            cmd.Parameters.AddWithValue("@tel_cel", Tel_cel);
            cmd.Parameters.AddWithValue("@roles", Roles);

            result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }
        public int eliminarUsuario() {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(conexion.MyConString);
            MySqlCommand cmd = new MySqlCommand("SpDelete_Usuarios", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.AddWithValue("ced", Ced);
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

    }
}
