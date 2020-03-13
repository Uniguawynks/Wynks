using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Solicitacao
/// </summary>
public class Solicitacao
{
    private int _codigo;
    private string _cpfAluno;
    private string _rgAluno;
    private string _item;
    private string _descricaoItem;
    private Local _localPerda;
    private DateTime _dataHoraPerda;
    public Solicitacao()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public int Codigo { get => _codigo; set => _codigo = value; }
    public string CpfAluno { get => _cpfAluno; set => _cpfAluno = value; }
    public string RgAluno { get => _rgAluno; set => _rgAluno = value; }
    public string Item { get => _item; set => _item = value; }
    public string DescricaoItem { get => _descricaoItem; set => _descricaoItem = value; }
    public Local LocalPerda { get => _localPerda; set => _localPerda = value; }
    public DateTime DataHoraPerda { get => _dataHoraPerda; set => _dataHoraPerda = value; }
}