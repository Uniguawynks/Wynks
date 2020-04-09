using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbtCadastrar_Click(object sender, EventArgs e)
    {
        tbDataEncontrado.Text = "";
        tbDescricaoItem.Text = "";
        tbLocalEncontrado.Text = "";
        tbNomeItem.Text = "";

        ExecScriptManager("$('#modalCadastro').modal('show');");
    }
    private void ExecScriptManager(string script)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "cadastraritem", script, true);
    }

    protected void lbtCadastrarOk_Click(object sender, EventArgs e)
    {
        string validacao = new Item().Validar(tbNomeItem.Text, tbDataEncontrado.Text, tbLocalEncontrado.Text);

        if(validacao != "")
        {
            ExecScriptManager("alert('" + validacao + "');");
        }
        else
        {
            string insercao = new Item().Inserir(tbNomeItem.Text, tbDescricaoItem.Text, tbLocalEncontrado.Text, tbDataEncontrado.Text, Session["Usuario"] as Usuario);

            if(insercao != "")
            {
                ExecScriptManager("alert('" + insercao + "');");
            }
            else
            {
                ExecScriptManager("alert('Item cadastrado com sucesso!');");

                ExecScriptManager("$('#modalCadastro').modal('hide');");
            }
        }
    }
}