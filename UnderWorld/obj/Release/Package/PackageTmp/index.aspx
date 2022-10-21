<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UnderWorld.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Material+Icons|Material+Icons+Outlined|Material+Icons+Two+Tone|Material+Icons+Round|Material+Icons+Sharp" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />
    <link href="http://fonts.cdnfonts.com/css/pena-caldaria" rel="stylesheet" />  
    <link rel="stylesheet" type="text/css" href="./css/estilo.css" />
    <title>index</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row mt-3">

            <input type="hidden" id="txtLogin" runat="server" />


            <div class="modal t-modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Modal title</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                            <p>Modal body text goes here.</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button class="btnAspx" runat="server" ID="txtLogar" OnClick="txtLogar_Click" Text="Logar" />
                            <asp:Button class="btnAspx" data-bs-dismiss="modal" runat="server" ID="txtCriarConta" OnClick="txtCriarConta_Click" Text="Criar Conta" />

                        </div>
                    </div>
                </div>
            </div>

            <!--
            <div class="col-12 col-md-6 mb-3 text-center">
                <nav class="navbar fixed-top navbar">
                    <div class="container-fluid">
                        <h1>UnderWorld</h1>
                        <input type="text" id="txtBusca" runat="server" />
                        <asp:Button ID="btnLogin" OnClick="txtLogin_Click" Text="Login" runat="server" />
                    </div>
                </nav>
            </div>
            -->
            <div class="col-12 col-md-6 mb-3 text-center">
                <asp:Button class="btnAspx" Text="Home" ID="btnHome" runat="server" />
                <asp:Button class="btnAspx" Text="Artistas" ID="btnCadArtista" OnClick="btnCadArtista_Click" runat="server" />
                <asp:Button class="btnAspx" Text="Álbuns" ID="btnCadAlbum" OnClick="btnCadAlbum_Click" runat="server" />
                <asp:Button class="btnAspx" Text="Músicas" ID="btnCadMusica" OnClick="btnCadMusica_Click" runat="server" />
                <asp:Button class="btnAspx" Text="Usuários" ID="btnCadUsuario" OnClick="btnCadUsuario_Click" runat="server" />
            </div>

            <h2 class="text-center">Bem vindo!</h2>
        </div>
    </form>
</body>
<script>
    function logar(id) {
        document.getElementById('txtLogin').value = id
    }
</script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
</html>
