using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var lista = new List<string>() { "vanessa", "arthur", "gui", "lucas" };

        usuarios.DataSource = lista;
        usuarios.DataBind();
    }

    protected void lbtAdd_Click(object sender, EventArgs e)
    {
        tbConfirmarSenha.Text = "";
        tbSenha.Text = "";
        tbUsuario.Text = "";
        tbCPF.Text = "";
        tbDataNascimento.Text = "";
        tbEmail.Text = "";
        ddlFuncao.SelectedIndex = 0;

        ExecScriptManager("$('#modalCadastroUsuario').modal('show');");
    }
    protected void ExecScriptManager(string script)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "comandoJS", script, true);
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();

        usuario.Cpf = tbCPF.Text;
        usuario.DataNascimento = Convert.ToDateTime(tbDataNascimento.Text);
        usuario.Email = tbEmail.Text;
        usuario.Funcao = ddlFuncao.SelectedValue;
        usuario.Nome = tbUsuario.Text;

        ExecScriptManager("alert('" + usuario.Validar(tbSenha.Text, tbConfirmarSenha.Text) + "');");
    }
}