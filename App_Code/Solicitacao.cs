using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Solicitacao
/// </summary>
public class Solicitacao : DBSolicitacao
{
    private int _codigo;
    private string _cpfAluno;
    private string _rgAluno;
    private string _nomeItem;
    private string _descricaoItem;
    private string _nomeAluno;
    private string _emailAluno;
    private string _foneAluno;
    private string _localPerda;
    private DateTime _dataHoraPerda;
    private string _extensaoArquivoImagem;
    public Solicitacao()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public int Codigo { get => _codigo; set => _codigo = value; }
    public string CpfAluno { get => _cpfAluno; set => _cpfAluno = value; }
    public string RgAluno { get => _rgAluno; set => _rgAluno = value; }
    public string NomeItem { get => _nomeItem; set => _nomeItem = value; }
    public string DescricaoItem { get => _descricaoItem; set => _descricaoItem = value; }
    public string LocalPerda { get => _localPerda; set => _localPerda = value; }
    public DateTime DataHoraPerda { get => _dataHoraPerda; set => _dataHoraPerda = value; }
    public string NomeAluno { get => _nomeAluno; set => _nomeAluno = value; }
    public string EmailAluno { get => _emailAluno; set => _emailAluno = value; }
    public string FoneAluno { get => _foneAluno; set => _foneAluno = value; }
    public string ExtensaoArquivoImagem { get => _extensaoArquivoImagem; set => _extensaoArquivoImagem = value; }

    public List<Solicitacao> Listar(string busca)
    {
        return base.DBListar(busca);
    }
    public string ValidarInsercao(string nomeAluno, string cpf, string rg, string nomeItem, string descricaoItem, DateTime dataPerda, string localPerda, string telefone, string email, string extensao)
    {
        this.NomeAluno = nomeAluno;
        this.CpfAluno = cpf;
        this.RgAluno = rg;
        this.NomeItem = nomeItem;
        this.DescricaoItem = descricaoItem;
        this.DataHoraPerda = dataPerda;
        this.LocalPerda = localPerda;
        this.FoneAluno = telefone;
        this.EmailAluno = email;
        this.ExtensaoArquivoImagem = extensao;

        if (string.IsNullOrEmpty(this.CpfAluno))
        {
            return "Preencha corretamente o CPF!";
        }

        this.CpfAluno = this.CpfAluno.Replace(".", "").Replace("-", "");

        if(this.CpfAluno.Length != 11)
        {
            return "Preencha o CPF corretamente!";
        }

        if(string.IsNullOrEmpty(this.EmailAluno))
        {
            return "Preencha o e-mail corretamente!";
        }
        else
        {
            if(this.EmailAluno.Length < 8)
            {
                return "Preencha o e-mail corretamente!";
            }
            else
            {
                if(!this.EmailAluno.Contains("@") || !this.EmailAluno.Contains("."))
                {
                    return "Preencha o e-mail corretamente!";
                }
            }
        }

        if(string.IsNullOrEmpty(this.FoneAluno))
        {
            return "Preencha o telefone corretamente!";
        }
        else
        {
            if(this.FoneAluno.Length <= 7)
            {
                return "Preencha corretamente o telefone!";
            }
        }

        if(string.IsNullOrEmpty(this.NomeAluno))
        {
            return "Preencha o nome do aluno!";
        }

        if(string.IsNullOrEmpty(this.RgAluno))
        {
            return "Preencha corretamente o RG!";
        }
        else if(this.RgAluno.Length < 6)
        {
            return "Preencha corretamente o RG!";
        }

        try
        {
            int codigo = base.DBInserir(this);

            return "Codigo:" + codigo.ToString();
        }
        catch (Exception ex)
        {
            return "Os dados estão corretos, porém houve um problema ao inserí-los no banco de dados, verifique!";
        }
    }
}