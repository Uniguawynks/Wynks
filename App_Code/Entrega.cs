using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Entrega
/// </summary>
public class Entrega
{
    #region Variaveis Privadas
    private int _codigo;
    private Item _item;
    private Usuario _usuario;
    private Solicitacao _solicitacao;
    private string _observacoes;
    private DateTime _dataHoraEntrega;
    #endregion
    public Entrega()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
    #region Variaveis Publicas
    public int Codigo { get => _codigo; set => _codigo = value; }
    public Item Item { get => _item; set => _item = value; }
    public Usuario Usuario { get => _usuario; set => _usuario = value; }
    public Solicitacao Solicitacao { get => _solicitacao; set => _solicitacao = value; }
    public string Observacoes { get => _observacoes; set => _observacoes = value; }
    public DateTime DataHoraEntrega { get => _dataHoraEntrega; set => _dataHoraEntrega = value; }
    #endregion
}