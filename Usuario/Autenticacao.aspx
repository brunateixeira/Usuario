<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Autenticacao.aspx.cs" Inherits="Usuario.Autenticacao" %>

<!DOCTYPE html>
<head>
    <link href="css/usuario.css" rel="stylesheet" />
    <script src="scripts/jquery.js" type="text/javascript"></script>
    <script src="scripts/jquery-ui.js" type="text/javascript"></script>
    <script src="scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="scripts/app/usuario.js" type="text/javascript"></script>
    <meta charset="UTF-8" />
    <title>Formulário de Login e Registro de Usuário</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"> 
</head>
<body>
  <div class="container" >
    <a class="links" id="paracadastro"></a>
    <a class="links" id="paralogin"></a>
     
    <div class="content">      
      <!--FORMULÁRIO DE LOGIN-->
      <div id="login">
        <form method="post" action=""> 
          <h1>Login</h1> 
          <p> 
            <label for="email_login">E-mail</label>
            <input id="email_login" name="email_login" type="text" placeholder="ex. contato@outlook.com"/>
          </p>
           
          <p> 
            <label for="senha_login">Senha</label>
            <input id="senha_login" name="senha_login" type="password" /> 
          </p>
           
          <p> 
            <input id="btnLogin" name="btnLogin" type="button" value="Logar" /> 
          </p>
           
          <p class="link">
            Ainda não tem conta?
            <a href="#paracadastro">Cadastre-se</a>
          </p>
        </form>
      </div>
 
      <!--FORMULÁRIO DE CADASTRO-->
      <div id="cadastro">
        <form method="post" action=""> 
          <h1>Cadastro</h1> 
           
          <p> 
            <label for="nome_cad">Nome</label>
            <input id="nome_cad" name="nome_cad" type="text" placeholder="nome" />
          </p>
           
          <p> 
            <label for="email_cad">E-mail</label>
            <input id="email_cad" name="email_cad" type="email" placeholder="contato@outlook.com"/> 
          </p>
           
          <p> 
            <label for="senha_cad">Senha</label>
            <input id="senha_cad" name="senha_cad" type="password"/>
          </p>
           
          <p> 
            <input id="btnCadastrar" name="btnCadastrar" type="button" value="Cadastrar"/> 
          </p>
           
          <p class="link">  
            Já tem conta?
            <a href="#paralogin"> Ir para Login </a>
          </p>
        </form>
      </div>
    </div>
  </div>  
</body>