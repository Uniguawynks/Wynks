using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DBSolicitacao
/// </summary>
public abstract class DBSolicitacao
{
    protected List<Solicitacao> DBListar(string busca)
    {
        SqlCommand CommandListar = new SqlCommand(@"select Codigo, CpfAluno, RgAluno, ItemNome, ItemDescricao,
                                                       NomeAluno, EmailAluno, FoneAluno
                                                       LocalPerda, DataHoraPerda
                                                    from SOLICITACAO with(NoLock)
                                                    where SOLICITACAO.ItemNome like '%' + @Busca + '%'
                                                       or SOLICITACAO.NomeAluno like '%' + @Busca + '%'", DBTools.Conn());

        CommandListar.CommandType = CommandType.Text;

        CommandListar.Parameters.Add("@Busca", SqlDbType.VarChar, 100);
        CommandListar.Parameters["@Busca"].Value = busca;

        CommandListar.Connection.Open();

        SqlDataReader DR = CommandListar.ExecuteReader();

        List<Solicitacao> lista = new List<Solicitacao>();

        while (DR.Read())
        {
            Solicitacao item = new Solicitacao();

            item.Codigo = Convert.ToInt32(DR["Codigo"]);
            item.CpfAluno = DR["CpfAluno"].ToString();
            item.RgAluno = DR["RgAluno"].ToString();
            item.NomeItem = DR["ItmeNome"].ToString();
            item.DescricaoItem = DR["ItemDescricao"].ToString();
            item.NomeAluno = DR["NomeAluno"].ToString();
            item.EmailAluno = DR["EmailAluno"].ToString();
            item.FoneAluno = DR["FoneAluno"].ToString();
            item.DataHoraPerda = Convert.ToDateTime(DR["DataHoraPerda"]);
            item.LocalPerda = DR["LocalPerda"].ToString();

            lista.Add(item);
        }

        CommandListar.Connection.Close();

        return lista;
    }
    protected int DBInserir(Solicitacao solicitacao)
    {
        SqlCommand CommandInsert = new SqlCommand(@"insert into SOLICITACAO (NomeAluno,  CpfAluno,  RgAluno,  EmailAluno,  FoneAluno,  ItemNome,  ItemDescricao,  LocalPerda,  DataHoraPerda)
                                                                     values(@NomeAluno, @CpfAluno, @RgAluno, @EmailAluno, @FoneAluno, @ItemNome, @ItemDescricao, @LocalPerda, @DataHoraPerda)

                                                    select max(Codigo) from SOLICITACAO with(Nolock)", DBTools.Conn());

        CommandInsert.CommandType = CommandType.Text;

        CommandInsert.Parameters.Add("@NomeAluno", SqlDbType.VarChar, 50);
        CommandInsert.Parameters.Add("@CpfAluno", SqlDbType.VarChar, 11);
        CommandInsert.Parameters.Add("@RgAluno", SqlDbType.VarChar, 10);
        CommandInsert.Parameters.Add("@EmailAluno", SqlDbType.VarChar, 1024);
        CommandInsert.Parameters.Add("@FoneAluno", SqlDbType.VarChar, 50);
        CommandInsert.Parameters.Add("@ItemNome", SqlDbType.VarChar, 100);
        CommandInsert.Parameters.Add("@ItemDescricao", SqlDbType.VarChar, -1);
        CommandInsert.Parameters.Add("@DataHoraPerda", SqlDbType.DateTime);
        CommandInsert.Parameters.Add("@LocalPerda", SqlDbType.VarChar, 100);

        CommandInsert.Parameters["@NomeAluno"].Value = solicitacao.NomeAluno;
        CommandInsert.Parameters["@CpfAluno"].Value = solicitacao.CpfAluno;
        CommandInsert.Parameters["@RgAluno"].Value = solicitacao.RgAluno;
        CommandInsert.Parameters["@EmailAluno"].Value = solicitacao.EmailAluno;
        CommandInsert.Parameters["@FoneAluno"].Value = solicitacao.FoneAluno;
        CommandInsert.Parameters["@ItemNome"].Value = solicitacao.NomeItem;
        CommandInsert.Parameters["@ItemDescricao"].Value = solicitacao.DescricaoItem;

        if(solicitacao.DataHoraPerda == new DateTime())
        {
            CommandInsert.Parameters["@DataHoraPerda"].Value = DBNull.Value;
        }
        else
        {
            CommandInsert.Parameters["@DataHoraPerda"].Value = solicitacao.DataHoraPerda;
        }

        if(string.IsNullOrEmpty(solicitacao.LocalPerda))
        {
            CommandInsert.Parameters["@LocalPerda"].Value = DBNull.Value;
        }
        else
        {
            CommandInsert.Parameters["@LocalPerda"].Value = solicitacao.LocalPerda;
        }

        CommandInsert.Connection.Open();
        int codigo = Convert.ToInt32(CommandInsert.ExecuteScalar());
        CommandInsert.Connection.Close();

        return codigo;
    }


}