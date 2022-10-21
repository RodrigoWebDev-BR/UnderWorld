using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace UnderWorld
{
    public partial class cad_usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder vSB = new StringBuilder();
            UnderWorldEntities vData = new UnderWorldEntities();
            List<usuario> vListaUsuario = new List<usuario>();
            vListaUsuario = vData.usuario.ToList();
            foreach (var item in vListaUsuario)
            {
                vSB.Append(
                    "<tr>" +
                    "<td>" + item.id_usuario + "</td>" +
                    "<td>" + item.nome_usuario + "</td>" +
                    "<td>" + item.email + "</td>" +
                    "<td> <span onclick=\"editarId(" + item.id_usuario + ")\" " +
                                "class=\"btn text-secondary material-icons-outlined\">edit</span> </td>" +
                    "<td><span onclick=\"deletarId(" + item.id_usuario + ")\" data-bs-toggle=\"modal\" data-bs-target=\"#exampleModal\"" +
                    " class=\"btn text-danger material-icons-outlined\">delete</span></td>" +
                    "</tr>");

                tbdData.InnerHtml = vSB.ToString();
            }

            if (!IsPostBack && Request.QueryString["id"] != null)
            {
                string vID = Request.QueryString["id"];
                usuario vUsuario = vData.usuario.Find(Convert.ToInt32(vID));
                txtUsuario.Value = vUsuario.nome_usuario;
                txtEmail.Value = vUsuario.email;
                vData = null;
                vUsuario = null;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            usuario vUsuario = new usuario();
            if (string.IsNullOrEmpty(txtEditar.Value))
            {
                string vID = Request.QueryString["id"];                
                vUsuario.nome_usuario = txtUsuario.Value;
                vUsuario.email = txtEmail.Value;
                vUsuario.senha = pswSenha.Value;
                vData.usuario.Add(vUsuario);               
            }
            else
            {
                vUsuario = vData.usuario.Find(Convert.ToInt32(txtEditar.Value));
                vUsuario.nome_usuario = txtUsuario.Value;
                vUsuario.email = txtEmail.Value;
                vUsuario.senha = pswSenha.Value;                
            }
            vData.SaveChanges();
            vData = null;
            vUsuario = null;
            Response.Redirect("cad_usuario.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string vID = txtEditar.Value;
            UnderWorldEntities vData = new UnderWorldEntities();
            usuario vUsuario = vData.usuario.Find(Convert.ToInt32(vID));
            txtUsuario.Value = vUsuario.nome_usuario;
            txtEmail.Value = vUsuario.email;
            pswSenha.Value = vUsuario.senha;
            vData = null;
            vUsuario = null;
        }

        protected void btnDeletar_Click(object sender, EventArgs e)
        {
            UnderWorldEntities vData = new UnderWorldEntities();
            usuario vUsuario = vData.usuario.Find(Convert.ToInt32(txtDeletar.Value));
            vData.usuario.Remove(vUsuario);
            vData.SaveChanges();
            vData = null;
            vUsuario = null;

            Response.Redirect("cad_usuario.aspx");
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

        protected void btnCadMusica_Click(object sender, EventArgs e)
        {
            Response.Redirect("cad_musica.aspx");
        }


    }
}