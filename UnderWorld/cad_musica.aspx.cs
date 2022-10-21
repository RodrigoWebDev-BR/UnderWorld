using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace UnderWorld
{
    public partial class cad_musica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder vSB = new StringBuilder();
            UnderWorldEntities vData = new UnderWorldEntities();
            List<musica> vListaMusica = new List<musica>();
            vListaMusica = vData.musica.ToList<musica>();
            foreach (var item in vListaMusica)
            {
                vSB.Append(
                    "<tr>" +
                    "<td>" + item.id_musica + "</td>" +  
                    "<td>" + item.nome_faixa + "</td>" +
                    "<td> <audio controls=\"controls\"> " +
                            "<source src=\"" + item.audio + "\" type=\"audio/mp3\" />" +
                    "</audio> </td>" +                    
                    "<td>" + item.duracao + "</td>" +
                    "<td> <img src=\"" + item.artista.foto_artista + "\" alt=\"Foto Artista\" width=\"120px;\" height=\"50px;\"> </td>" +
                    "<td> <img src=\"" + item.album.foto_album + "\" alt=\"Foto Album\" width=\"30px;\" height=\"30px;\"> " +
                    "<br>" + item.album.titulo + "</td>" +
                    "<td> <span onclick=\"editarId(" + item.id_musica + ")\" " +
                                "class=\"btn text-secondary material-icons-outlined\">edit</span> </td>" +
                    "<td><span onclick=\"deletarId(" + item.id_musica + ")\" data-bs-toggle=\"modal\" data-bs-target=\"#exampleModal\"" +
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
            
                List<album> vListaAlbum = vData.album.ToList<album>();
                foreach (var item in vListaAlbum)
                {
                    sltAlbum.Items.Add(new ListItem(item.titulo, item.id_album.ToString()));
                }
            }
            
            vData = null;
            vListaMusica = null;
            vSB = null;

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            musica vMusica = new musica();
            if (string.IsNullOrEmpty(txtEditar.Value))
            {
                string vID = Request.QueryString["ID"];         
                string caminhoAudio = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoAudio"] + @"\" + fileAudio.PostedFile.FileName;
                fileAudio.PostedFile.SaveAs(caminhoAudio);
                vMusica.nome_faixa = txtMusica.Value;
                vMusica.id_artista = Convert.ToInt32(sltArtista.SelectedValue);
                vMusica.id_album = Convert.ToInt32(sltAlbum.Value);
                vMusica.duracao = TimeSpan.Parse(timeDuracao.Value);
                vMusica.audio = System.Configuration.ConfigurationManager.AppSettings["caminhoAudio"].Replace(@"\", "/") + fileAudio.PostedFile.FileName;
                vData.musica.Add(vMusica);                
            }
            else
            {
                vMusica = vData.musica.Find(Convert.ToInt32(txtEditar.Value));
                string caminhoAudio = AppDomain.CurrentDomain.BaseDirectory + System.Configuration.ConfigurationManager.AppSettings["caminhoAudio"] + @"\" + fileAudio.PostedFile.FileName;
                fileAudio.PostedFile.SaveAs(caminhoAudio);
                vMusica.nome_faixa = txtMusica.Value;
                vMusica.id_artista = Convert.ToInt32(sltArtista.SelectedValue);
                vMusica.id_album = Convert.ToInt32(sltAlbum.Value);
                vMusica.duracao = TimeSpan.Parse(timeDuracao.Value);
                vMusica.audio = System.Configuration.ConfigurationManager.AppSettings["caminhoAudio"].Replace(@"\", "/") + fileAudio.PostedFile.FileName;
                
            }
            vData.SaveChanges();            
            vData = null;
            vMusica = null;
            Response.Redirect("cad_musica.aspx");

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string vID = txtEditar.Value;
            UnderWorldEntities vData = new UnderWorldEntities();
            musica vMusica = vData.musica.Find(Convert.ToInt32(vID));
            txtMusica.Value = vMusica.nome_faixa;
            sltArtista.SelectedValue = vMusica.id_artista.ToString();
            sltAlbum.Value = vMusica.id_album.ToString();
            timeDuracao.Value = vMusica.duracao.ToString();
            System.Configuration.ConfigurationManager.AppSettings["caminhoAudio"] = "/assets/audio/" + vMusica.audio;            
            vData = null;
            vMusica = null;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btnCadArtista_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_artista.aspx");
        }

        protected void btnCadAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_album.aspx");
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            musica vMusica = vData.musica.Find(Convert.ToInt32(txtDeletar.Value));
            vData.musica.Remove(vMusica);
            vData.SaveChanges();
            vData = null;
            vMusica = null;

            Response.Redirect("cad_musica.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {

        }

        protected void btnCadUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_usuario.aspx");
        }

        protected void sltArtista_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            List<album> vListaAlbum = vData.album.ToList<album>();
            sltAlbum.Items.Clear();
            sltAlbum.Items.Add(new ListItem(""));
            foreach (var item in vListaAlbum)
            {
                if (item.id_artista.ToString() == sltArtista.SelectedValue)
                    sltAlbum.Items.Add(new ListItem(item.titulo, item.id_album.ToString()));
            }
        }

        protected void sltAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            List<artista> vListaArtista = vData.artista.ToList<artista>();
            foreach (var item in vListaArtista)
            {
                sltArtista.Items.Add(new ListItem(item.nome_artista, item.id_artista.ToString()));
            }
            vListaArtista = null;
        }
    }
}