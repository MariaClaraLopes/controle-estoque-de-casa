using System;
using System.Web;
using MySql.Data.MySqlClient;

namespace AspNetCRUD
{
    public class Conexao
    {
        //Atributo que faz conectar-se ao servidor MySQL, utilizando os parâmetros de conexão: host-localhost(Anfitrião local), port(porta), database(base de dados), pwd(senha); 
        public string connect = "Server=localhost; Port=8889; Database=asp_controle_estoque; Uid=root; Pwd=root;";

        public MySqlConnection con = null;
        
        /// <summary>
        /// Este método abre uma conexão com o banco de dados MySql.        
        /// </summary>
        public void AbrirCon()
        {            
            try
            {
                con = new MySqlConnection(connect);
                if (!con.Ping())
                {
                    con.Open();
                }                                
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Falha de conexão" + ex);
            }
        }

        /// <summary>
        /// Este método fecha uma conexão com o banco de dados MySql.
        /// </summary>
        public void FecharCon()
        {
            try
            {
                con = new MySqlConnection(connect);
                con.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Falha de conexão" + ex);
            }
        }
    }
}
