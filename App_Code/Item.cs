using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Item
/// </summary>
public class Item
{
    private int _codigo;
    private string _nome;
    private string _descricao;
    private DateTime _dataHoraEncontrado;
    private Local _localEncontrado;
    private string _imagemUrl;
    private Usuario _cadastrante;
    private string _nomeAlunoEncontrou;
    public Item()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public int Codigo { get => _codigo; set => _codigo = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Descricao { get => _descricao; set => _descricao = value; }
    public DateTime DataHoraEncontrado { get => _dataHoraEncontrado; set => _dataHoraEncontrado = value; }
    public Local LocalEncontrado { get => _localEncontrado; set => _localEncontrado = value; }
    public string ImagemUrl { get => _imagemUrl; set => _imagemUrl = value; }
    public Usuario Cadastrante { get => _cadastrante; set => _cadastrante = value; }
    public string NomeAlunoEncontrou { get => _nomeAlunoEncontrou; set => _nomeAlunoEncontrou = value; }
}