using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void logar_Click(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();

        usuario.Email = tbUsuario.Text;

        if(usuario.Logar(tbSenha.Text))
        {
            Response.Redirect("~/menuAdmin.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "login", "alert('E-mail ou senha incorretos!');", true);
        }
    }
}