<!-- ASP.NET de extensão .aspx do tipo HTML : 
É responsavél pelo esqueleto da página, contendo 2 elementos principais, head e body -->

<%@ Page Language="C#" Inherits="AspNetCRUD.index" %>
<!DOCTYPE html>
<html>
    
<!-- Head : É a cabeça, contém todas as informações para que a página funcione como o esperado.
É usado para receber metatags, como título do documento e links para arquivos externos -->    
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>    
    <title>Controle De Estoque</title>
    <script runat="server">
    
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
    
<!-- Body : É o corpo, contém todo conteúdo da página que será efetivamente exibido.
Nesse caso incluimos todos os títulos(HeaderText), os rótulos(Label), o campo que recebe um texto(TextBox), o botão(Button),
a tabela(GridView) associada a um campo que vincula(BoundField) de um dado oculto que nomeamos(DataField) para um título que aparecerá para o usuário(HeaderText) e a barra de busca "navbar"-->        
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar navbar-dark bg-dark">
          <a class="navbar-brand" href="#">
            <img src="logo.png" width="30" height="30" class="d-inline-block align-top" alt="" loading="lazy">
            Controle de Estoque
          </a>
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>

          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
              <li class="nav-item active">
                <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
              </li>
              <li class="nav-item active">                
                <asp:LinkButton class="nav-link" Text="Sair" ID="btnsair" runat="server" PostBackUrl="~/Login.aspx" />
              </li>
            </ul>
            
            <div class="form-inline my-2 my-lg-0">
              <asp:TextBox class="form-control mr-sm-2" ID="txtbuscar" placeholder="buscar produto" aria-label="Buscar" runat="server" />
              <asp:Button class="btn btn-outline-light my-2 my-sm-0" Text="Buscar" ID="BtnBuscar" OnClick="BtnBuscar_Click" runat="server" />
            </div>
                    
          </div>
        </nav>
        
        <div>
            <asp:HiddenField ID="idproduto" runat="server" />
            <table ID="formtable">  
                <tr>
                   <td>
                           <asp:Label Text="Produto" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtnome" AutoPostBack="true" placeholder="nome do produto" OnTextChanged="TxtProduto_TextChanged" runat="server" /> 
                    </td>
                </tr>  
                    
                <tr>
                   <td>
                           <asp:Label Text="Descrição" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtdescricao" placeholder="observação" runat="server" /> 
                    </td>
                </tr>
                    
                <tr>
                   <td>
                           <asp:Label Text="Valor (R$)" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtvalor" placeholder="valor médio" runat="server" /> 
                    </td>
                </tr>
                    
                <tr>
                   <td>
                           <asp:Label Text="Qtd Total (g)" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtquantidade" placeholder="consumo família(mês)" runat="server" /> 
                    </td>
                </tr>
                
                <tr>
                   <td>
                           <asp:Label Text="Data da Compra" runat="server" /> 
                    </td>
                    <td colspan="2">                                                                                                                                  
                            <asp:TextBox ID="txttempo" placeholder="Ex: 22/06/2020" runat="server" />
                    </td>
                </tr>
                    
                <tr>
                    <td>
                           <asp:Label Text="Fornecedor" class="text-dark" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtfornecedor" placeholder="nome do local" runat="server"/>
                    </td>
                </tr>
                    
                <tr>
                    <td>
                           <asp:Label Text="Categoria" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:DropDownList class="btn btn-dark" ID="ddcategoria" OnSelectedIndexChanged="DdCategoria_SelectedIndexChanged" runat="server">
                           </asp:DropDownList>
                          
                    </td>
                </tr>
                    
                <tr>
                   <td colspan="3">
                           
                           <asp:Button class="btn btn-dark" Text="Salvar" ID="BtnSalvar" OnClick="BtnSalvar_Click"  runat="server" /> 
                           <asp:Button class="btn btn-dark"Text="Editar" ID="btneditar" OnClick="BtnEditar_Click" runat="server" />
                           <asp:Button class="btn btn-dark" Text="Deletar" ID="btndeletar" OnClick="BtnDeletar_Click" runat="server" />
                    </td>
                </tr>
                
                <tr>
                   <td colspan="3">
                           <asp:Label Text="" ID="lblmensagemok" runat="server" ForeColor="Green" />
                    </td>
                </tr>
                 
                <tr>
                   <td colspan="3">
                           <asp:Label Text="" ID="lblmensagemerro" runat="server" ForeColor="Red" /> 
                    </td>
                </tr>
                
            </table>  
            <table class="table">
                <asp:GridView ID="grid" class="btn table-info" runat="server" AutoGenerateColumns="false" >
                    <Columns>
                            <asp:BoundField DataField="nome" HeaderText="Nome do Produto"/>                       
                            <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                            <asp:BoundField DataField="valor" HeaderText="Valor (R$)"/>
                            <asp:BoundField DataField="quantidade" HeaderText="Quantidade Gasta por Mês" />
                            <asp:BoundField DataField="tempo" DataFormatString = "{0:dd/MM/yyyy}" HeaderText="Data da Compra" />
                            <asp:BoundField DataField="categoria" HeaderText="Categoria" />
                            <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor" />
                            <asp:BoundField HeaderText="Precisa comprar (g)"/>
                            
                                                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button Text="Selecionar" ID="BtnSelecionar" OnClick="BtnSelecionar_Click" CommandArgument='<%# Eval("id") %>' class="btn btn-info" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </table>
        </div> 
    </form>
</body>
</html>
