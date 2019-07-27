$(document).ready(function () {

    $("#btnLogin").click(function () {

        if (!ValidaCampos("Login"))
        {
            alert("Preencha todos os campos do formulário");
            return;
        }

        var email = $("#email_login").val();
        var senha = $("#senha_login").val();

        var json = {
            usuarioDetalhe: {
                Email: email,
                Senha: senha
            }
        };

        $.ajax({
            url: 'Autenticacao.aspx/AutenticarUsuario',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(json),
            success: function (data) {

                var result = data.d;

                if (result.Errors.length > 0) {
                    alert(result.Errors[0].Message);
                }
                else {
                    window.location.href = "Autenticado.aspx";
                }

                LimpaCampos();
            },

        });
    });


    $("#btnCadastrar").click(function () {

        if (!ValidaCampos("Cadastro")) {
            alert("Preencha todos os campos do formulário");
            return;
        }

        var nome = $("#nome_cad").val();
        var email = $("#email_cad").val();
        var senha = $("#senha_cad").val();

        var json = {
            usuarioDetalhe: {
                Nome: nome,
                Email: email,
                Senha: senha
            }
        };

        $.ajax({
            url: 'Autenticacao.aspx/InserirUsuario',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(json),
            success: function (data) {

                var result = data.d;

                if (result.Errors.length > 0) {
                    alert(result.Errors[0].Message);
                }

                LimpaCampos();
            }
        })
    });

    function LimpaCampos() {

        $("#nome_cad").val("");
        $("#email_cad").val("");
        $("#senha_cad").val("");
        $("#email_login").val("");
        $("#senha_login").val("");
    }

    function ValidaCampos(tela) {

        if (tela == "Login") {

            var email = $("#email_login").val();
            var senha = $("#senha_login").val();

            if (email == null || email == "") {
                return false;
            }

            if (senha == null || senha == "") {
                return false;
            }
        }
        else {
            var nome = $("#nome_cad").val();
            var email = $("#email_cad").val();
            var senha = $("#senha_cad").val();

            if (nome == null || nome == "") {
                return false;
            }

            if (email == null || email == "") {
                return false;
            }

            if (senha == null || senha == "") {
                return false;
            }
        }

        return true;
    }
});

  