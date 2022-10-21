<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cad_usuario.aspx.cs" Inherits="UnderWorld.cad_usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Material+Icons|Material+Icons+Outlined|Material+Icons+Two+Tone|Material+Icons+Round|Material+Icons+Sharp" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />
    <link href="http://fonts.cdnfonts.com/css/pena-caldaria" rel="stylesheet" />  
    <link rel="stylesheet" type="text/css" href="./css/estilo.css" />
    <title>cad_usuario</title>
</head>
<body>
    <form id="form1" runat="server">

        <input type="hidden" id="txtEditar" runat="server" />
        <asp:Button class="d-none" Text="btnClick" ID="btnEditar" OnClick="btnEditar_Click" runat="server" />

        <div class="modal t-modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Excluir Música</h5>
                        <asp:Button class="btn-close" data-bs-dismiss="modal" arial-label="Close" ID="btnFechar" runat="server" />
                    </div>
                    <div class="modal-body">
                        <p>Deseja realizar a exclusão desse usuário?</p>
                        <p>Essa ação não pode ser desfeita.</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button class="btnAspx" data-bs-dismiss="modal" runat="server" ID="btnSair" OnClick="btnSair_Click" Text="NÃO " />
                        <asp:Button class="btnAspxDeletar" runat="server" ID="btnDeletar" OnClick="btnDeletar_Click" Text="SIM" />
                        <input type="hidden" runat="server" id="txtDeletar" />
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div class="row mt-3">
               
                <div class="col-12 col-md-6 mb-3 text-center">
                    <img src="https://fontmeme.com/permalink/210915/10165e967f5f1fe77f03d1a78e1065f1.png" />
                </div>
                <div class="col-12 col-md-6 mb-3 text-center">
                    <asp:Button class="btnAspx" Text="Home" ID="btnHome" OnClick="btnHome_Click" runat="server" />
                    <asp:Button class="btnAspx" Text="Artistas" ID="btnCadArtista" OnClick="btnCadArtista_Click" runat="server" />
                    <asp:Button class="btnAspx" Text="Álbuns" ID="btnCadAlbum" OnClick="btnCadAlbum_Click" runat="server" />
                    <asp:Button class="btnAspx" Text="Músicas" ID="btnCadMusica" OnClick="btnCadMusica_Click" runat="server" />
                    <asp:Button class="btnAspx" Text="Usuários" ID="btnCadUsuario" runat="server" />
                </div>


                <div class="col-10">
                    <div class="row">
                        <h2 class="text-center">Cadastro de usuários</h2>

                        <div class="col-12 col-12 mb-3 text-center">
                            <label for="txtUsuario">Nome do Usuário:</label>
                            <input type="text" id="txtUsuario" runat="server" value="" class="form-control" />
                        </div>

                        <div class="col-12 col-md-6 mb-3 text-center">
                            <label for="txtEmail">E-Mail:</label>
                            <input type="text" id="txtEmail" runat="server" value="" class="form-control" />
                        </div>

                        <div class="col-3 col-md-6 mb-3 text-center">
                            <label for="pswSenha">Senha:</label>
                            <input type="password" id="pswSenha" runat="server" value="" class="form-control" />
                        </div>

                        <div class="col-12 col-md-12 mb-3 text-center">
                            <asp:Button class="btnAspx" ID="btnSalvar" OnClick="btnSalvar_Click" Text="Salvar" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="col-2">
                    <div class="row">
                        <div class="col-12">
                            <img src="./assets/img/18-183734_yugioh-bakura.png" style="width: 200px; height: 200px; border-radius: 50%; cursor: pointer;" alt="Foto Usuario" id="fileFoto" runat="server" />
                        </div>
                        <div class="col-12">
                            <input type="file" id="fileImg" runat="server" />
                        </div>
                    </div>
                </div>



                <div class="row">
                    <div class="col-md-3">
                    </div>
                </div>
            </div>
            <div class="col-12 col-md-12 mb-3 text-center">
                <table class="table table-hover table-responsive">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>USUÁRIO</th>
                            <th>E-MAIL</th>
                            <th>#</th>
                            <th>#</th>
                        </tr>
                    </thead>
                    <tbody runat="server" id="tbdData" class="align-middle">
                    </tbody>
                </table>
            </div>

        </div>

    </form>
</body>
<script>
    function editarId(id) {
        document.getElementById('txtEditar').value = id
        document.getElementById('btnEditar').click()
    }
    function deletarId(id) {
        document.getElementById('txtDeletar').value = id
    }
</script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
</html>
