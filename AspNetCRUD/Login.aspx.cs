using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace AspNetCRUD
{   
    public partial class Login : System.Web.UI.Page
    {
        Conexao conexao = new Conexao();
        string nomeUsuario, nivelUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblmensagemerro.Visible = false;
                        
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            FazerLogin();
        }
        
        private void FazerLogin()
        {
            lblmensagemerro.Visible = false;
            if (IsValidEmail(txtemail.Text) && txtsenha.Text != "")
            {
                string sql;

                MySqlCommand cmd;
                MySqlDataReader reader;
                
                conexao.AbrirCon();
                sql = "SELECT * FROM usuarios WHERE email = @usuario AND senha = @senha";                    
                cmd = new MySqlCommand(sql, conexao.con);
                cmd.Parameters.AddWithValue("@usuario", txtemail.Text);
                cmd.Parameters.AddWithValue("@senha", txtsenha.Text);

                reader = cmd.ExecuteReader();

                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        nomeUsuario = reader["nome"].ToString();
                        nivelUsuario = reader["nivel"].ToString();
                        lblmensagemerro.Visible = true;
                        lblmensagemerro.Text = nomeUsuario + nivelUsuario;

                    }
                    string atributoNome = "nome=" + HttpUtility.UrlEncode(nomeUsuario, System.Text.Encoding.UTF8);
                    string atributoNivel = "nivel=" + HttpUtility.UrlEncode(nivelUsuario, System.Text.Encoding.UTF8);

                    string queryString = atributoNome + "&" + atributoNivel;
                    Response.Redirect("index.aspx?" + queryString);                    
                }
                else
                {
                    lblmensagemerro.Visible = true;
                    lblmensagemerro.Text = "Dados incorretos";

                    txtemail.Text = "";
                    txtsenha.Text = "";

                    txtemail.Focus();

                }

                conexao.FecharCon();
                return;

            }
            lblmensagemerro.Visible = true;
            lblmensagemerro.Text = "Credenciais estão erradas!";
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
