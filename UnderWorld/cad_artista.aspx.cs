using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace UnderWorld
{
    public partial class cad_artista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder vSB = new StringBuilder();
            UnderWorldEntities vData = new UnderWorldEntities();
            List<artista> vListaArtista = new List<artista>();
            vListaArtista = vData.artista.ToList();
            foreach (var item in vListaArtista)
            {
                vSB.Append(
                    "<tr>" +
                    "<td>" + item.id_artista + "</td>" +
                    "<td>" + item.nome_artista + "</td>" +
                    "<td> <img src=\"" + item.foto_artista + "\" alt=\"Foto Artista\" width=\"120px;\" height=\"50px;\"> </td>" +                   
                    "<td> <span onclick=\"editarId(" + item.id_artista + ")\" " +
                                "class=\"btn text-secondary material-icons-outlined\">edit</span> </td>" +
                    "<td><span onclick=\"deletarId(" + item.id_artista + ")\" data-bs-toggle=\"modal\" data-bs-target=\"#exampleModal\"" +
                    " class=\"btn text-danger material-icons-outlined\">delete</span></td>" +
                    "</tr>");
                tbdData.InnerHtml = vSB.ToString();
            }

            vData = null;
            vListaArtista = null;
            vSB = null;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            artista vArtista = new artista();
            if (string.IsNullOrEmpty(txtEditar.Value))
            {
                string vID = Request.QueryString["id"];                
                string caminhoImagem = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"] + @"\" + fileFoto.PostedFile.FileName;
                fileFoto.SaveAs(caminhoImagem);
                vArtista.nome_artista = txtArtista.Value;
                vArtista.foto_artista = System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"].Replace(@"\", "/") + fileFoto.PostedFile.FileName;
                vData.artista.Add(vArtista);                               
            }
            else
            {
                vArtista = vData.artista.Find(Convert.ToInt32(txtEditar.Value));
                string caminhoImagem = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"] + @"\" + fileFoto.PostedFile.FileName;
                fileFoto.SaveAs(caminhoImagem);
                vArtista.nome_artista = txtArtista.Value;
                vArtista.foto_artista = System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"].Replace(@"\", "/") + fileFoto.PostedFile.FileName;               
                
            }
            vData.SaveChanges();
            vData = null;
            vArtista = null;
            Response.Redirect("cad_artista.aspx");
        }

        protected void btnEditarClick(object sender, EventArgs e)
        {
            string vID = txtEditar.Value;
            UnderWorldEntities vData = new UnderWorldEntities();
            artista vArtista = vData.artista.Find(Convert.ToInt32(vID));
            txtArtista.Value = vArtista.nome_artista;
            System.Configuration.ConfigurationManager.AppSettings["caminhoImagem"] = "/assets/img/" + vArtista.foto_artista;
            vData = null;
            vArtista = null;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnCadAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_album.aspx");
        }

        protected void btnCadMusica_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_musica.aspx");
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            artista vArtista = vData.artista.Find(Convert.ToInt32(txtDeletar.Value));
            vData.artista.Remove(vArtista);
            vData.SaveChanges();
            vData = null;
            vArtista = null;

            Response.Redirect("cad_artista.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {

        }

        protected void btnCadUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_usuario.aspx");
        }
    }

}