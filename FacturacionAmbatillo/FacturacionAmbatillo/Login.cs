﻿using MySql.Data.MySqlClient;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Conexion conexion = new Conexion();
        
        private void validarUser(string ced,string pass)
        {
            //string user = null;
            try
            {
                MySqlConnection cnn = new MySqlConnection(conexion.MyConString);
                MySqlCommand cmd = new MySqlCommand("SpLoginUsuarios", cnn);
                cnn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ced", ced.Trim());
                cmd.Parameters.AddWithValue("pass", pass.Trim());
                
                MySqlDataReader myreader = cmd.ExecuteReader();
                myreader.Read();

                if (myreader.HasRows)
                {
                    this.Hide();
                    Principal pr = new Principal(ced, myreader["nombres"].ToString(), pass);
                    //Principal pr = new Principal();
                    //pr.pass = txtClave.Text;
                    ConfigUsuarios cu = new ConfigUsuarios();
                    cu.Ced = ced;
                    cu.Clave = pass; // txtClave.Text;
                    pr.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblErrorPass.Visible = true;
                }
                cnn.Close();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            validarUser(txtUsuario.Text.Trim(), txtClave.Text);
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validarUser(txtUsuario.Text.Trim(), txtClave.Text);
                
            }
        }

        private void txtClave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validarUser(txtUsuario.Text.Trim(), txtClave.Text);
            }
        }


    }
}
