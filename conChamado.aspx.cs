using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class conChamado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtBuscar_Click(sender, e);
    }

    protected void lbtBuscar_Click(object sender, EventArgs e)
    {
        rptChamado.DataSource = new Solicitacao().Listar(tbBusca.Text);
        rptChamado.DataBind();
    }

    protected void rptChamado_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            LinkButton lbtDetalhar = e.Item.FindControl("lbtDetalhar") as LinkButton;
            LinkButton lbtAtender = e.Item.FindControl("lbtAtender") as LinkButton;
            Image imgChamado = e.Item.FindControl("imgChamado") as Image;
            HtmlGenericControl h5Nome = e.Item.FindControl("h5Nome") as HtmlGenericControl;

            Solicitacao solicitacao = e.Item.DataItem as Solicitacao;

            lbtDetalhar.Attributes.Add("onclick", "return Detalhar('" + solicitacao.Codigo + "');");
            lbtAtender.Attributes.Add("onclick", "return Atender('" + solicitacao.Codigo + "');");

            if(solicitacao.ExtensaoArquivoImagem != "")
            {
                imgChamado.ImageUrl = DBTools.URLImagemChamadoCurto() + solicitacao.Codigo.ToString() + solicitacao.ExtensaoArquivoImagem;
            }

            if(solicitacao.Atendido)
            {
                h5Nome.Style.Add("color", "green");
                lbtAtender.Visible = false;
            }
        }
    }

    protected void hfDetalhar_ValueChanged(object sender, EventArgs e)
    {
        if(hfDetalhar.Value != "0")
        {
            Solicitacao chamado = new Solicitacao(Convert.ToInt32(hfDetalhar.Value));
            tbNomeAluno.Text = chamado.NomeAluno;
            tbCPF.Text = DBTools.FormatarCPF(chamado.CpfAluno);
            tbData.Text = chamado.DataHoraPerda.ToShortDateString();
            tbDescricao.Text = chamado.DescricaoItem;
            tbEmail.Text = chamado.EmailAluno;
            tbLocal.Text = chamado.LocalPerda;
            tbNomeItem.Text = chamado.NomeItem;
            tbRG.Text = chamado.RgAluno;
            tbTelefone.Text = chamado.FoneAluno;

            if(chamado.Atendido)
            {
                lbAtendidoPor.Visible = true;
                lbDataAtendimento.Visible = true;
                tbDataAtendimento.Visible = true;
                tbAtendidoPor.Visible = true;

                tbAtendidoPor.Text = chamado.UsuarioAtendimento.Nome;
                tbDataAtendimento.Text = chamado.DataAtendimento.ToShortDateString();
            }
            else
            {
                lbAtendidoPor.Visible = false;
                lbDataAtendimento.Visible = false;
                tbDataAtendimento.Visible = false;
                tbAtendidoPor.Visible = false;
            }

            ExecScriptManager("$('#modalDetalhar').modal('show');");

            hfDetalhar.Value = "0";
        }
    }

    protected void hfAtender_ValueChanged(object sender, EventArgs e)
    {
        if(hfAtender.Value != "0")
        {
            Solicitacao chamado = new Solicitacao(Convert.ToInt32(hfAtender.Value));

            Session["_chamadoAtender"] = chamado;

            ExecScriptManager("$('#modalAtender').modal('show');");

            hfAtender.Value = "0";
        }
    }
    private void ExecScriptManager(string comando)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "amdc", comando, true);
    }

    protected void lbtAtenderOk_Click(object sender, EventArgs e)
    {
        Solicitacao chamado = Session["_chamadoAtender"] as Solicitacao;

        chamado.Atender(Session["Usuario"] as Usuario);

        ExecScriptManager("$('#modalAtender').modal('hide');");

        lbtBuscar_Click(sender, e);
    }
}