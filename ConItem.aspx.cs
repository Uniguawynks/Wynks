using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ConItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtBuscar_Click(sender, e);
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
            string extensao = "";

            try
            {
                extensao = fuImagem.FileName.Substring(fuImagem.FileName.LastIndexOf('.'));
            }
            catch
            {
                extensao = "";
            }

            string insercao = new Item().Inserir(tbNomeItem.Text, tbDescricaoItem.Text, tbLocalEncontrado.Text, tbDataEncontrado.Text, Session["Usuario"] as Usuario, extensao);

            if(insercao.Substring(0, 7) != "Codigo:")
            {
                ExecScriptManager("alert('" + insercao + "');");
            }
            else
            {
                fuImagem.SaveAs(DBTools.URLImagemItem() + insercao.Substring(7) + fuImagem.FileName.Substring(fuImagem.FileName.LastIndexOf('.')));

                ExecScriptManager("alert('Item cadastrado com sucesso!');");

                ExecScriptManager("$('#modalCadastro').modal('hide');");

                lbtBuscar_Click(sender, e);
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
            LinkButton lbtEntregar = e.Item.FindControl("lbtEntregar") as LinkButton;

            lbtDetalhar.Attributes.Add("onclick", "return DetalharItem('" + item.Codigo + "');");
            lbtEntregar.Attributes.Add("onclick", "return EntregarItem('" + item.Codigo + "');");

            Image imgItem = e.Item.FindControl("imgItem") as Image;

            if(item.ExtensaoArquivoImagem.Length > 0)
            {
                imgItem.ImageUrl = DBTools.URLImagemItemCurto() + item.Codigo + item.ExtensaoArquivoImagem;
            }
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

    protected void hfEntregarItem_ValueChanged(object sender, EventArgs e)
    {
        if(hfEntregarItem.Value != "0")
        {
            Session["_itemEntrega"] = hfEntregarItem.Value;

            rptEntregaSolicitacao.DataSource = new Solicitacao().Listar("");
            rptEntregaSolicitacao.DataBind();

            ExecScriptManager("$('#modalEntrega').modal('show');");
        }
    }

    protected void rptEntregaSolicitacao_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            HtmlGenericControl liSolicitacao = e.Item.FindControl("liSolicitacao") as HtmlGenericControl;

            Solicitacao solicitacao = e.Item.DataItem as Solicitacao;

            liSolicitacao.Attributes.Add("onclick", "return Entregar('" + solicitacao.Codigo + "');");

            if(e.Item.ItemIndex %2 != 0)
            {
                liSolicitacao.Style.Add("background-color", "#EEE");
            }
        }
    }

    protected void hfRealizarEntrega_ValueChanged(object sender, EventArgs e)
    {
        if(hfRealizarEntrega.Value != "0")
        {
            new Entrega().Inserir(Convert.ToInt32(Session["_itemEntrega"]), Convert.ToInt32(hfRealizarEntrega.Value), "", DateTime.Now, Session["Usuario"] as Usuario);

            lbtBuscar_Click(sender, e);

            ExecScriptManager("$('#modalEntrega').modal('hide');");

            hfRealizarEntrega.Value = "0";
        }
    }
}