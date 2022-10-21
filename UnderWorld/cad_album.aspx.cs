using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace UnderWorld
{
    public partial class cad_album : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder vSB = new StringBuilder();
            UnderWorldEntities vData = new UnderWorldEntities();
            List<album> vListaAlbum = new List<album>();
            vListaAlbum = vData.album.ToList();
            foreach (var item in vListaAlbum)
            {
                vSB.Append(
                    "<tr>" +
                    "<td>" + item.id_album + "</td>" +
                    "<td>" + item.titulo + "</td>" +
                    "<td> <img src=\"" + item.artista.foto_artista + "\" alt=\"Foto Artista\" width=\"120px;\" height=\"50px;\"> </td>" +                    
                    "<td>" + item.qnt_faixa + "</td>" +
                    "<td>" + item.duracao + "</td>" +
                    "<td>" + item.lancamento.Year + "</td>" +
                    "<td> <img src=\"" + item.foto_album + "\" alt=\"Foto Album\" width=\"70px;\" height=\"70px;\"> </td>" +
                    "<td> <span onclick=\"editarId(" + item.id_album + ")\" " +
                                "class=\"btn text-secondary material-icons-outlined\">edit</span> </td>" +
                    "<td><span onclick=\"deletarId(" + item.id_album + ")\" data-bs-toggle=\"modal\" data-bs-target=\"#exampleModal\"" +
                    " class=\"btn text-danger material-icons-outlined\">delete</span></td>" +
                    "</tr>");
            }
            tbdData.InnerHtml = vSB.ToString();

            if (!IsPostBack)
            {
                List<artista> vListaArtista = vData.artista.ToList<artista>();
                foreach (var item in vListaArtista)
                {
                    sltArtista.Items.Add(new ListItem(item.nome_artista, item.id_artista.ToString()));
                }
                vListaArtista = null;
            }
            vData = null;
            vListaAlbum = null;
            vSB = null;

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            album vAlbum = new album();
            if (string.IsNullOrEmpty(txtEditar.Value))
            {
                string vID = Request.QueryString["id"];               
                string caminhoImagem = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"] + @"\" + fileFoto.PostedFile.FileName;
                fileFoto.SaveAs(caminhoImagem);
                vAlbum.titulo = txtTitulo.Value;
                vAlbum.id_artista = Convert.ToInt32(sltArtista.Value);
                vAlbum.lancamento = Convert.ToDateTime(dtLancamento.Value);
                vAlbum.qnt_faixa = Convert.ToInt32(numQntFaixa.Value);
                vAlbum.duracao = TimeSpan.Parse(timeDuracao.Value);
                vAlbum.foto_album = System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"].Replace(@"\", "/") + fileFoto.PostedFile.FileName;
                vData.album.Add(vAlbum);               
                
            }
            else
            {
                
                vAlbum = vData.album.Find(Convert.ToInt32(txtEditar.Value));
                string caminhoImagem = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"] + @"\" + fileFoto.PostedFile.FileName;
                fileFoto.SaveAs(caminhoImagem);
                vAlbum.titulo = txtTitulo.Value;
                vAlbum.id_artista = Convert.ToInt32(sltArtista.Value);
                vAlbum.lancamento = Convert.ToDateTime(dtLancamento.Value);
                vAlbum.qnt_faixa = Convert.ToInt32(numQntFaixa.Value);
                vAlbum.duracao = TimeSpan.Parse(timeDuracao.Value);
                vAlbum.foto_album = System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"].Replace(@"\", "/") + fileFoto.PostedFile.FileName;              
                
            }
            vData.SaveChanges();
            vData = null;
            vAlbum = null;
            Response.Redirect("cad_album.aspx");
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string vID = txtEditar.Value;
            UnderWorldEntities vData = new UnderWorldEntities();
            album vAlbum = vData.album.Find(Convert.ToInt32(vID));
            txtTitulo.Value = vAlbum.titulo;
            sltArtista.Value = vAlbum.id_artista.ToString();
            dtLancamento.Value = vAlbum.lancamento.ToString();
            numQntFaixa.Value = vAlbum.qnt_faixa.ToString();
            timeDuracao.Value = vAlbum.duracao.ToString();
            System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"] = "/assets/img/" + vAlbum.foto_album;
            vData = null;
            vAlbum = null;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnCadArtista_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_artista.aspx");
        }

        protected void btnCadMusica_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_musica.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            album vAlbum = vData.album.Find(Convert.ToInt32(txtDeletar.Value));
            vData.album.Remove(vAlbum);
            vData.SaveChanges();
            vData = null;
            vAlbum = null;

            Response.Redirect("cad_album.aspx");
        }

        protected void btnCadUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_usuario.aspx");
        }
    }
}