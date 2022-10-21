<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cad_album.aspx.cs" Inherits="UnderWorld.cad_album" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Material+Icons|Material+Icons+Outlined|Material+Icons+Two+Tone|Material+Icons+Round|Material+Icons+Sharp" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css" />
    <link href="http://fonts.cdnfonts.com/css/pena-caldaria" rel="stylesheet" />  
    <link rel="stylesheet" type="text/css" href="./css/estilo.css" />
    <title>cad_album</title>
</head>
<body>
    <form id="form1" runat="server">

        <input type="hidden" id="txtEditar" runat="server" />
        <asp:Button class="d-none" ID="btnEditar" OnClick="btnEditar_Click" runat="server" />

        <div class="modal t-modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Excluir Álbum</h5>
                        <asp:Button class="btn-close" data-bs-dismiss="modal" arial-label="Close" ID="btnFechar" runat="server" />
                    </div>
                    <div class="modal-body">
                        <p>Deseja realizar a exclusão desse álbum?</p>
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
                    <asp:Button class="btnAspx" Text="Artistas" ID="btnCadArtista" OnClick="btnCadArtista_Click"  runat="server" />
                    <asp:Button class="btnAspx" Text="Álbuns" ID="btnCadAlbum" runat="server" />
                    <asp:Button class="btnAspx" Text="Músicas" ID="btnCadMusica" OnClick="btnCadMusica_Click" runat="server" />
                    <asp:Button class="btnAspx" Text="Usuários" ID="btnCadUsuario" OnClick="btnCadUsuario_Click" runat="server" />
                </div>

                <h2 class="text-center">Cadastro de álbuns</h2>

                <div class="col-12 col-md-6 mb-3 text-center">
                    <label for="txtArtista">Título:</label>
                    <input type="text" id="txtTitulo" runat="server" value="" class="form-control" />
                </div>

                <div class="col-12 col-md-6 mb-3 text-center">
                    <label for="sltArtista">Artista:</label>
                    <select class="form-select" runat="server" id="sltArtista">
                        <option type="hidden"></option>
                    </select>
                </div>

                <div class="col-12 col-md-3 mb-3 text-center">
                    <label for="dtLancamento">Ano de Lançamento:</label>
                    <input type="date" id="dtLancamento" runat="server" class="form-control" />
                </div>

                <div class="col-12 col-md-3 mb-3 text-center">
                    <label for="numQntFaixa">Quantidade de faixas:</label>
                    <input type="number" id="numQntFaixa" runat="server" value="" class="form-control" />
                </div>

                <div class="col-12 col-md-3 mb-3 text-center">
                    <label for="timeDuracao">Duração:</label>
                    <input type="time" step="1" id="timeDuracao" runat="server" value="" class="form-control" />
                </div>

                <div class="col-12 col-md-3 mb-3 text-center">
                    <label for="fileFoto">Foto:</label>
                    <asp:FileUpload ID="fileFoto" runat="server" class="form-control" />
                </div>

                <div class="col-12 col-md-12 mb-3 text-center">
                    <asp:Button class="btnAspx" OnClick="btnSalvar_Click" Text="Salvar" runat="server" ID="btnSalvar" />
                </div>

                <div class="row">
                    <div class="col-12 col-md-12 mb-3 text-center">
                        <table class="table table-hover table-responsive">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>ÁLBUM</th>
                                    <th>ARTISTA</th>
                                    <th>QUANTIDADE DE FAIXAS</th>
                                    <th>DURAÇÃO</th>
                                    <th>ANO DE LANÇAMENTO</th>
                                    <th>FOTO DE CAPA</th>
                                    <th>#</th>
                                    <th>#</th>
                                </tr>
                            </thead>
                            <tbody runat="server" id="tbdData" class="align-middle">
                            </tbody>
                        </table>
                    </div>
                </div>

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
