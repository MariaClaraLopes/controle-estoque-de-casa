<!-- ASP.NET de extensão .aspx do tipo HTML : 
É responsavél pelo esqueleto da página, contendo 2 elementos principais, head e body -->

<%@ Page Language="C#" Inherits="AspNetCRUD.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous" />
    <link rel="stylesheet" href="~/Login.css" />
	<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>Login</title>
</head>
        
<body>
    <div class="wrapper fadeInDown">
        <div id="formContent">            
            <!-- Icon -->
            <div class="fadeIn first">
              <!-- url imagem: https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSbC-MPND_TK3g-u9FONBuu6q6aRR4lvMZFVOSfZGKpSOKJh0W2&usqp=CAU -->
              <img src="~/carrinho.png" id="icon" alt="Login" />
            </div>

            <!-- Login Form -->
            <form id="form1" runat="server">      
              <asp:TextBox type="email" class="fadeIn second" id="txtemail" aria-describedby="emailHelp" placeholder="Digite o seu email" runat="server" />
              <asp:TextBox type="password" class="fadeIn third" id="txtsenha" placeholder="Digite a sua senha" runat="server" />            
              <asp:Button Text="Entrar" class="fadeIn fourth" ID="btnentrar" OnClick="BtnEntrar_Click" runat="server" />
              <br>              
              <div>
                <asp:Label class="alert alert-danger" role="alert" Text="" ID="lblmensagemerro" runat="server" ForeColor="Red" /> 
              </div>
            </form>      
        </div>
    </div>
</body>
</html>