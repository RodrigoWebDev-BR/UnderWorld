using System;

namespace UnderWorld
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadMusica_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_musica.aspx");
        }

        protected void btnCadArtista_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_artista.aspx");
        }

        protected void btnCadAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_album.aspx");
        }

        protected void btnCadUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_usuario.aspx");
        }

        protected void txtLogin_Click(object sender, EventArgs e)
        {

        }

        protected void txtCriarConta_Click(object sender, EventArgs e)
        {

        }

        protected void txtLogar_Click(object sender, EventArgs e)
        {

        }
       
    }
}