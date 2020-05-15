using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DBEntrega
/// </summary>
public abstract class DBEntrega
{
    protected void DBInserir(Entrega entrega)
    {
        SqlCommand CommandInsert = new SqlCommand(@"INSERT INTO ENTREGA (CodigoItem, CodigoSolicitacao, Obs, DataEntrega, CodigoUsuario)
				                                                    values(@Item, @Solicitacao, @Observacao, @DataEntrega, @Usuario)", DBTools.Conn());

        CommandInsert.CommandType = CommandType.Text;

        CommandInsert.Parameters.Add("@Item", SqlDbType.Int);
        CommandInsert.Parameters.Add("@Solicitacao", SqlDbType.Int);
        CommandInsert.Parameters.Add("@Observacao", SqlDbType.VarChar, -1);
        CommandInsert.Parameters.Add("@DataEntrega", SqlDbType.DateTime);
        CommandInsert.Parameters.Add("@Usuario", SqlDbType.Int);

        CommandInsert.Parameters["@Item"].Value = entrega.Item.Codigo;
        CommandInsert.Parameters["@Solicitacao"].Value = entrega.Solicitacao.Codigo;
        CommandInsert.Parameters["@Observacao"].Value = entrega.Observacoes;
        CommandInsert.Parameters["@DataEntrega"].Value = entrega.DataHoraEntrega;
        CommandInsert.Parameters["@Usuario"].Value = entrega.Usuario.Codigo;

        CommandInsert.Connection.Open();
        CommandInsert.ExecuteNonQuery();
        CommandInsert.Connection.Close();
    }
    protected List<Entrega> DBListar(string busca)
    {
        SqlCommand CommandListar = new SqlCommand(@"SELECT e.Codigo, CodigoItem, CodigoSolicitacao, Obs, DataEntrega, CodigoUsuario
                                                    FROM ENTREGA e with(NoLock)
                                                       INNER JOIN ITEM i with(NoLock)
                                                          on i.Codigo = e.CodigoItem
                                                    Where i.Nome like '%' + @Busca + '%'", DBTools.Conn());

        CommandListar.CommandType = CommandType.Text;

        CommandListar.Parameters.Add("@Busca", SqlDbType.VarChar, 50);
        CommandListar.Parameters["@Busca"].Value = busca;

        CommandListar.Connection.Open();

        SqlDataReader DR = CommandListar.ExecuteReader();

        List<Entrega> lista = new List<Entrega>();

        while(DR.Read())
        {
            Entrega item = new Entrega();

            item.Codigo = Convert.ToInt32(DR["Codigo"]);
            item.Item = new Item(Convert.ToInt32(DR["CodigoItem"]));
            item.Solicitacao = new Solicitacao(Convert.ToInt32(DR["CodigoSolicitacao"]));
            item.Observacoes = DR["Obs"].ToString();
            item.DataHoraEntrega = Convert.ToDateTime(DR["DataEntrega"]);
            item.Usuario = new Usuario(Convert.ToInt32(DR["CodigoUsuario"]));

            lista.Add(item);
        }

        CommandListar.Connection.Close();

        return lista;
    }
}