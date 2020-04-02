using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CadChamado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnEnviar_Click(object sender, EventArgs e)
    {        
        DateTime dataPerda = new DateTime();

        try
        {
            dataPerda = Convert.ToDateTime(tbData.Text);
        }
        catch
        {
            dataPerda = new DateTime();
        }

        string mensagem = new Solicitacao().ValidarInsercao(tbNomeAluno.Text, tbCPF.Text, tbRG.Text, tbNomeItem.Text, tbDescricao.Text, dataPerda, tbLocal.Text, tbTelefone.Text, tbEmail.Text);

        if (mensagem.Substring(0, 7) == "Codigo:")
        {
            string nomeArquivo = mensagem.Substring(6);

            //fuImagem.SaveAs(DBTools.URLImagem() + nomeArquivo + fuImagem.FileName.Substring(fuImagem.FileName.LastIndexOf('.')));

            ExecScriptManager("alert('Cadastrado com sucesso! Código: " + mensagem + "');");
        }
        else
        {
            ExecScriptManager("alert('" + mensagem + "');");
        }
    }
    private void ExecScriptManager(string comando)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "cadastrachamado", comando, true);
    }
}