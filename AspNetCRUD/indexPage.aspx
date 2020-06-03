<%@ Page Language="C#" Inherits="AspNetCRUD.indexPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>index</title>
    <script runat="server">
    
    </script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="idproduto" runat="server" />
            <table>
                <tr>
                   <td>
                           <asp:Label Text="Produto" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtnome" runat="server" /> 
                    </td>
                </tr>  
                    
                <tr>
                   <td>
                           <asp:Label Text="Descrição" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtdescricao" runat="server" /> 
                    </td>
                </tr>
                    
                <tr>
                   <td>
                           <asp:Label Text="Valor" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtvalor" runat="server" /> 
                    </td>
                </tr>
                    
                <tr>
                   <td>
                           <asp:Label Text="Quantidade" runat="server" /> 
                    </td>
                    <td colspan="2">
                           <asp:TextBox ID="txtquantidade" runat="server" /> 
                    </td>
                </tr>
                    
                <tr>
                   <td colspan="3">
                           <asp:Button Text="Salvar" ID="btnsalvar" runat="server" /> 
                           <asp:Button Text="Editar" ID="btneditar" runat="server" />
                           <asp:Button Text="Deletar" ID="btndeletar" runat="server" />
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
        </div>
    </form>
</body>
</html>
