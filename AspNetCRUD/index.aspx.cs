// ASP.NET de extensão .aspx.cs do tipo C#  

using System;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Data;
using System.Web.UI.WebControls;

namespace AspNetCRUD
{
    /// <summary>
    /// Este método é um método reservado para a criação de uma pagina de web.
    /// </summary>
    public partial class index : System.Web.UI.Page
    {
        //Instânciando o objeto conexao do tipo Conexao.
        Conexao conexao = new Conexao();

        // criamos uma variavél id do tipo Int32(inteiro de 32 bit)
        Int32 id;


        string nomeUsuario;
        string nivelUsuario;


        /// <summary>
        /// Este método carrega a página e atualiza os dados.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {            
            nomeUsuario = HttpContext.Current.Request.QueryString["nome"];
            nivelUsuario = HttpContext.Current.Request.QueryString["nivel"];

            if (nomeUsuario == null)
            {
                Response.Redirect("~/Login.aspx");
            }            

            LimparMensagens();
            Listar();
            CarregarCategorias();
            CalcularQuantidade();
            
           
        }

        /// <summary>
        /// Este método é responsável por acessar no banco de dados os dados da tabela produtos, concatenar com a tabela categorias e fornecedores, listando as informações que o usuário digitar.
        /// </summary>
        private void Listar()
        {
            // criamos uma variavél sql do tipo string;
            string sql;

            // criamos um obejeto cmd do tipo MySqlCommand;
            MySqlCommand cmd;

            // instânciamos um objeto dataAdapter do tipo MySqlDataAdapter;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

            // instânciamos um objeto dataTable do tipo DataTable;
            DataTable dataTable = new DataTable();

            // o objeto conexao do tipo Conexao acessa(.) o método AbrirCon() que abre conexão com o banco;
            conexao.AbrirCon();

            // atribuimos na variavél sql as informações que vai buscar no banco de dados os dados da tabela produtos e concatenar nela a tabela categorias e fornecedores e vai ordenar os nomes desses dados em ordem alfabetica;
            sql = "SELECT * FROM produtos AS P " +
                "INNER JOIN categorias AS C ON P.id_categoria = C.id " +
                "ORDER BY nome asc";

            //instânciamos o objeto cmd do tipo MySqlCommand passando 2 parâmetros: sql e o objeto conexao do tipo Conexao, acessando(.) o objeto con do tipo MySqlConnection;
            cmd = new MySqlCommand(sql, conexao.con);

            // atribuimos o objeto cmd no objeto dataAdapter que é um objeto que ajuda adaptar e preencher e é do tipo MySqlDataAdapter que acessa(.) o SelectCommand que é um objeto de comando que recupera dados da fonte de dados(MySql);
            dataAdapter.SelectCommand = cmd;

            // utilizamos o dataAdapter para acessar(.) o método Fill que usa como argumento um objeto DataTable que será preenchido com os resultados do SelectCommand;
            dataAdapter.Fill(dataTable);


            // criamos uma condição para entrar nela somente se a quantidade de linhas for menor que zero; 
            if (dataTable.Rows.Count <= 0)
            {
                // atribui falso na visualização da tabela;
                grid.Visible = false;

                // mostrará uma mensagem pro usuário 
                lblmensagemok.Text = "Não possui produtos cadastrados!";

            }

            // caso a condição não seja satisfeita em "se", vai cair na "se não" e ; 
            else
            {
                
                // atribui verdadeiro na visualização da tabela;
                grid.Visible = true;

                dataTable.Columns.Add("tempoDuracao", typeof(string));

                double totalCompra = 0;
                foreach (DataRow dr in dataTable.Rows) 
                {
                    DateTime dataCompra = (DateTime)dr["tempo"];                    
                    dr["tempoDuracao"] = dataCompra.AddDays((int)dr["quantidade"]).ToString("dd/MM/yyyy");

                    totalCompra += Convert.ToDouble(dr["valor"]);
                }

                lbltotalcompra.Text = " Total da Lista de Compra R$ " + totalCompra.ToString();

                grid.DataSource = dataTable;
                grid.DataBind();
            }

            // o objeto conexao do tipo Conexao acessa(.) o método FecharCon() que fecha conexão com o banco;
            conexao.FecharCon();
        }

        /// <summary>
        /// Este método busca as informações do método Buscar() para executar o comando assim que o evento do botão acontecer
        /// </summary>
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            lblmensagemerro.Text = "";
            Buscar();
            txtbuscar.Text = "";
        }


        private void Buscar()
        {
            // criamos uma variavél sql do tipo string;
            string sql;

            // criamos um obejeto cmd do tipo MySqlCommand;
            MySqlCommand cmd;

            // instânciamos um objeto dataAdapter do tipo MySqlDataAdapter;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();

            // instânciamos um objeto dataTable do tipo DataTable;
            DataTable dataTable = new DataTable();

            // criamos uma condição para entrar nela somente se o campo buscar estiver preenchido 
            if (txtbuscar.Text != "")
            {
                // o objeto conexao do tipo Conexao acessa(.) o método AbrirCon() que abre conexão com o banco;
                conexao.AbrirCon();

                sql = "SELECT * FROM produtos AS P " +
                    "INNER JOIN categorias AS C ON P.id_categoria = C.id " +
                    "WHERE nome LIKE @nome";
                cmd = new MySqlCommand(sql, conexao.con);
                cmd.Parameters.AddWithValue("@nome", "%" + txtbuscar.Text + "%");
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count <= 0)
                {                    
                    lblmensagemerro.Text = "Não foram encontrados produtos com esse nome!";
                    Listar();
                }
                else
                {
                    grid.Visible = true;
                    grid.DataSource = dataTable;
                    grid.DataBind();
                    
                }

                conexao.FecharCon();
            }

            // caso a condição não seja satisfeita em "se", vai cair na "se não" e mostrará uma mensagem pro usuário 
            else
            {
                lblmensagemerro.Text = "O campo buscar não pode estar vazio!";
            }

        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtnome.Text == "")
            {
                lblmensagemerro.Text = "Nome do produto é obrigatório!";
                txtnome.Focus();
                return;
            }

            if (txtvalor.Text == "")
            {
                lblmensagemerro.Text = "Valor do produto é obrigatório!";
                txtvalor.Focus();
                return;
            }

            if (txtquantidade.Text == "")
            {
                lblmensagemerro.Text = "Quantidade do produto é obrigatória!";
                txtquantidade.Focus();
                return;
            }
            if (txttempo.Text == "")
            {
                lblmensagemerro.Text = "O tempo de retorno ao mercado é obrigatório!";
                txttempo.Focus();
                return;
            }


            SalvarInfo();
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtnome.Text == "")
            {
                lblmensagemerro.Text = "Nome do produto é obrigatório!";
                txtnome.Focus();
                return;
            }

            if (txtvalor.Text == "")
            {
                lblmensagemerro.Text = "Valor do produto é obrigatório!";
                txtvalor.Focus();
                return;
            }

            if (txtquantidade.Text == "")
            {
                lblmensagemerro.Text = "Quantidade do produto é obrigatória!";
                txtquantidade.Focus();
                return;
            }
            if (txttempo.Text == "")
            {
                lblmensagemerro.Text = "O tempo de retorno ao mercado é obrigatório!";
                txttempo.Focus();
                return;
            }

            try
            {                
                if (Int32.Parse(idproduto.Value) != 0)
                {
                    EditarInfo();
                }

            }
            catch
            {
                lblmensagemerro.Text = "Não foi possível editar o elemento";
            }                     
        }
        
        private void EditarInfo()
        {            
            string sql = "UPDATE produtos SET nome = @nome, descricao = @descricao, valor = @valor, quantidade = @quantidade, tempo = @tempo, id_categoria = @categoria, fornecedor = @fornecedor WHERE id = @id";
            MySqlCommand cmd;

            conexao.AbrirCon();
            cmd = new MySqlCommand(sql, conexao.con);
            cmd.Parameters.AddWithValue("@nome", txtnome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtdescricao.Text);
            cmd.Parameters.AddWithValue("@valor", txtvalor.Text);
            cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text);
            cmd.Parameters.AddWithValue("@tempo", DateTime.Parse(txttempo.Text, new CultureInfo("pt-PT")));
            cmd.Parameters.AddWithValue("@fornecedor", txtfornecedor.Text);
            cmd.Parameters.AddWithValue("@id", idproduto.Value);
            cmd.Parameters.AddWithValue("@categoria", ddcategoria.SelectedValue);
            

            cmd.ExecuteNonQuery();
            lblmensagemok.Text = "Dados editados com sucesso!";            
            
            conexao.FecharCon();
            LimparDados();
            Listar();
            
        }

        protected void BtnDeletar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM produtos WHERE id = @id";
            MySqlCommand cmd;            

            conexao.AbrirCon();
            cmd = new MySqlCommand(sql, conexao.con);            
            cmd.Parameters.AddWithValue("@id", idproduto.Value);

            cmd.ExecuteNonQuery();
            lblmensagemok.Text = "Dados excluídos com sucesso!";

            conexao.FecharCon();
            LimparDados();
            Listar();
        }        

        protected void BtnSelecionar_Click(object sender, EventArgs e)
        {           
            id = Int32.Parse((sender as Button).CommandArgument);

            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            DataTable dataTable = new DataTable();

            conexao.AbrirCon();
            sql = "SELECT * FROM produtos WHERE id = @id";
            cmd = new MySqlCommand(sql, conexao.con);
            cmd.Parameters.AddWithValue("@id",  id);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);            

            idproduto.Value = dataTable.Rows[0][0].ToString();
            txtnome.Text = dataTable.Rows[0][1].ToString();
            txtdescricao.Text = dataTable.Rows[0][2].ToString();
            txtvalor.Text = dataTable.Rows[0][3].ToString();
            txtquantidade.Text = dataTable.Rows[0][4].ToString();
            txttempo.Text = ((DateTime)dataTable.Rows[0][5]).ToString("dd/MM/yyyy");
            txtfornecedor.Text = dataTable.Rows[0][7].ToString();
            

            try
            {                
                ddcategoria.SelectedValue = dataTable.Rows[0][6].ToString();
            }
            catch
            {
                ddcategoria.SelectedValue = "0";
            }


            conexao.FecharCon();
        }        

        protected void TxtProduto_TextChanged(object sender, EventArgs e)
        {
            LimparMensagens();
        }

        private void SalvarInfo()
        {
            string sql = "INSERT INTO produtos (nome, descricao, valor, quantidade, tempo, id_categoria, fornecedor) VALUES (@nome, @descricao, @valor, @quantidade, @tempo, @categoria, @fornecedor)";
            MySqlCommand cmd;
            
            conexao.AbrirCon();
            cmd = new MySqlCommand(sql, conexao.con);
            cmd.Parameters.AddWithValue("@nome", txtnome.Text);
            cmd.Parameters.AddWithValue("@descricao", txtdescricao.Text);
            cmd.Parameters.AddWithValue("@valor", txtvalor.Text);
            cmd.Parameters.AddWithValue("@quantidade", txtquantidade.Text);            
            cmd.Parameters.AddWithValue("@tempo", DateTime.Parse(txttempo.Text, new CultureInfo("pt-PT")));
            cmd.Parameters.AddWithValue("@fornecedor", txtfornecedor.Text);
            cmd.Parameters.AddWithValue("@categoria", ddcategoria.SelectedValue);

            cmd.ExecuteNonQuery();
            lblmensagemok.Text = "Dados salvos com sucesso!";
            LimparDados();

            conexao.FecharCon();
            Listar();
        }

        private void LimparMensagens()
        {
            lblmensagemerro.Text = "";
            lblmensagemok.Text = "";
        }

        private void LimparDados()
        {
            txtnome.Text = "";
            txtdescricao.Text = "";
            txtvalor.Text = "";
            txtquantidade.Text = "";
            txttempo.Text = "";
            txtfornecedor.Text = "";

        }

        private void CarregarCategorias()
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            DataTable dataTable = new DataTable();

            conexao.AbrirCon();
            sql = "SELECT * FROM categorias order by categoria asc";
            cmd = new MySqlCommand(sql, conexao.con);
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count <= 0)
            {
                lblmensagemok.Text = "Não possui produtos cadastrados!";

            }
            else
            {
                ddcategoria.DataSource = dataTable;
                ddcategoria.DataTextField = "categoria";
                ddcategoria.DataValueField = "id";
                ddcategoria.DataBind();
            }

            conexao.FecharCon();
        }

        protected void DdCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CalcularQuantidade()
        {
            
        }


    }
}
