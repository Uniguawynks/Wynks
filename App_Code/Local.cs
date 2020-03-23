using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Local
/// </summary>
public class Local
{
    private int _codigo;
    private string _nome;
    private string _descricao;
    public Local()
    {
        
    }

    public int Codigo { get => _codigo; set => _codigo = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Descricao { get => _descricao; set => _descricao = value; }
    public void Inserir(string nome, string descricao)
    {

    }
    public void Validar(string nome, string descricao)
    {

    }
}