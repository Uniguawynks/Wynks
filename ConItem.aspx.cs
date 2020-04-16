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

        lbtCadastrarOk.Visible = true;

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

    protected void lbtBuscar_Click(object sender, EventArgs e)
    {
        rptItens.DataSource = new Item().Listar(tbBusca.Text);
        rptItens.DataBind();
    }

    protected void rptItens_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Item item = e.Item.DataItem as Item;

            LinkButton lbtDetalhar = e.Item.FindControl("lbtDetalhar") as LinkButton;

            lbtDetalhar.Attributes.Add("onclick", "return DetalharItem('" + item.Codigo + "');");
        }
    }

    protected void hfDetalharItem_ValueChanged(object sender, EventArgs e)
    {
        if(hfDetalharItem.Value != "0")
        {
            Item item = new Item(Convert.ToInt32(hfDetalharItem.Value));

            tbDataEncontrado.Text = item.DataHoraEncontrado.ToShortDateString();
            tbDescricaoItem.Text = item.Descricao;
            tbLocalEncontrado.Text = item.LocalEncontrado;
            tbNomeItem.Text = item.Nome;

            lbtCadastrarOk.Visible = false;

            ExecScriptManager("$('#modalCadastro').modal('show');");

            hfDetalharItem.Value = "0";
        }
    }
}