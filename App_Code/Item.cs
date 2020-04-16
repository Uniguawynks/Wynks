using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Item
/// </summary>
public class Item : DBItem
{
    private int _codigo;
    private string _nome;
    private string _descricao;
    private DateTime _dataHoraEncontrado;
    private string _localEncontrado;
    private string _imagemUrl;
    private Usuario _cadastrante;
    private string _nomeAlunoEncontrou;
    public Item()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
    public Item(int codigo)
    {
        this.Codigo = codigo;
        base.DBSelecionar(this);
    }

    public int Codigo { get => _codigo; set => _codigo = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Descricao { get => _descricao; set => _descricao = value; }
    public DateTime DataHoraEncontrado { get => _dataHoraEncontrado; set => _dataHoraEncontrado = value; }
    public string LocalEncontrado { get => _localEncontrado; set => _localEncontrado = value; }
    public string ImagemUrl { get => _imagemUrl; set => _imagemUrl = value; }
    public Usuario Cadastrante { get => _cadastrante; set => _cadastrante = value; }
    public string NomeAlunoEncontrou { get => _nomeAlunoEncontrou; set => _nomeAlunoEncontrou = value; }
    public string Validar(string nome, string data, string local)
    {
        if(string.IsNullOrEmpty(nome))
        {
            return "Preencha corretamente o nome do item!";
        }

        try
        {
            if(Convert.ToDateTime(data) == new DateTime())
            {
                throw new Exception();
            }
        }
        catch
        {
            return "Coloque uma data válida para o dia em que encontrou o item";
        }

        if(string.IsNullOrEmpty(local))
        {
            return "Especifique o local onde encontrou o item!";
        }

        return "";
    }
    public string Inserir(string nome, string descricao, string local, string data, Usuario cadastrante)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        this.LocalEncontrado = local;
        this.DataHoraEncontrado = Convert.ToDateTime(data);

        try
        {
            base.DBInserir(this);
        }
        catch
        {
            return "Os parâmetros estão certos, mas houve um problema ao gravar os dados no banco, verifique!";
        }

        return "";
    }
    public List<Item> Listar(string busca)
    {
        return base.DBListar(busca);
    } 
}