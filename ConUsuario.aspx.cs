using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ConUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var lista = new List<string>() { "vanessa", "arthur", "gui", "lucas" };

        rptUsuarios.DataSource = new Usuario().Listar("");
        rptUsuarios.DataBind();
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

        divConfirmarSenha.Visible = true;
        divSenha.Visible = true;

        Session["_usuario"] = null;

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

        if(Session["_usuario"] == null)
        {
            ExecScriptManager("alert('" + usuario.ValidarInsercao(tbSenha.Text, tbConfirmarSenha.Text) + "');");
        }
        else
        {
            ExecScriptManager("alert('" + usuario.ValidarAlteracao() + "');");
        }
        

        ExecScriptManager("$('#modalCadastroUsuario').modal('hide');");

        rptUsuarios.DataSource = new Usuario().Listar("");
        rptUsuarios.DataBind();
    }

    protected void btnSalvarExclusao_Click(object sender, EventArgs e)
    {
        Usuario usuario = Session["_usuario"] as Usuario;

        usuario.Desativar();

        rptUsuarios.DataSource = new Usuario().Listar("");
        rptUsuarios.DataBind();
    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        LinkButton botao = sender as LinkButton;

        int codigo = Convert.ToInt32(botao.CommandArgument);

        Usuario usuario = new Usuario(codigo);

        Session["_usuario"] = usuario;

        ExecScriptManager("$('#modalExclusao').modal('show');");
    }

    protected void rptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton btnEditar = e.Item.FindControl("btnEditar") as LinkButton;

            Usuario usuario = e.Item.DataItem as Usuario;

            btnEditar.Attributes.Add("onclick", "return EditarUsuario('" + usuario.Codigo + "');");

            if(e.Item.ItemIndex %2 != 0)
            {
                HtmlGenericControl liUsuario = e.Item.FindControl("liUsuario") as HtmlGenericControl;

                liUsuario.Style.Add("background-color", "#EEE");
            }
        }
    }

    protected void hfEditarUsuario_ValueChanged(object sender, EventArgs e)
    {
        if(hfEditarUsuario.Value != "0")
        {
            Usuario usuario = new Usuario(Convert.ToInt32(hfEditarUsuario.Value));

            tbConfirmarSenha.Text = "";
            tbSenha.Text = "";

            divConfirmarSenha.Visible = false;
            divSenha.Visible = false;

            tbUsuario.Text = usuario.Nome;
            tbCPF.Text = usuario.CpfFormatado;
            tbDataNascimento.Text = usuario.DataNascimento.ToShortDateString();
            tbEmail.Text = usuario.Email;
            ddlFuncao.SelectedValue = usuario.Funcao;

            Session["_usuario"] = usuario;

            ExecScriptManager("$('#modalCadastroUsuario').modal('show');");

            hfEditarUsuario.Value = "0";
        }
    }
}