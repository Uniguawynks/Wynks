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
        SqlCommand CommandListar = new SqlCommand(@"select Codigo, CpfAluno, RgAluno, ItemNome, ItemDescricao, LocalPerda,
                                                       NomeAluno, EmailAluno, FoneAluno, ExtensaoArquivoImagem,
                                                       DataHoraPerda, Atendido, UsuarioAtendimento, DataAtendimento
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
            item.NomeItem = DR["ItemNome"].ToString();
            item.DescricaoItem = DR["ItemDescricao"].ToString();
            item.NomeAluno = DR["NomeAluno"].ToString();
            item.EmailAluno = DR["EmailAluno"].ToString();
            item.FoneAluno = DR["FoneAluno"].ToString();
            item.DataHoraPerda = Convert.ToDateTime(DR["DataHoraPerda"]);
            item.LocalPerda = DR["LocalPerda"].ToString();
            item.ExtensaoArquivoImagem = DR["ExtensaoArquivoImagem"].ToString();
            item.Atendido = Convert.ToInt32(DR["Atendido"]) == 1;
            
            if(item.Atendido)
            {
                item.DataAtendimento = Convert.ToDateTime(DR["DataAtendimento"]);
                item.UsuarioAtendimento = new Usuario(Convert.ToInt32(DR["UsuarioAtendimento"]));
            }

            lista.Add(item);
        }

        CommandListar.Connection.Close();

        return lista;
    }

    protected void DBSelecionar(Solicitacao solicitacao)
    {
        SqlCommand CommandSelecionar = new SqlCommand(@"select CpfAluno, RgAluno, ItemNome, ItemDescricao, LocalPerda,
                                                            NomeAluno, EmailAluno, FoneAluno, ExtensaoArquivoImagem,
                                                            DataHoraPerda, Atendido, UsuarioAtendimento, DataAtendimento
                                                        from SOLICITACAO with(NoLock)
                                                        where Codigo = @Codigo", DBTools.Conn());

        CommandSelecionar.CommandType = CommandType.Text;

        CommandSelecionar.Parameters.Add("@Codigo", SqlDbType.Int);
        CommandSelecionar.Parameters["@Codigo"].Value = solicitacao.Codigo;

        CommandSelecionar.Connection.Open();

        SqlDataReader DR = CommandSelecionar.ExecuteReader();

        List<Solicitacao> lista = new List<Solicitacao>();

        if (DR.Read())
        {
            solicitacao.CpfAluno = DR["CpfAluno"].ToString();
            solicitacao.RgAluno = DR["RgAluno"].ToString();
            solicitacao.NomeItem = DR["ItemNome"].ToString();
            solicitacao.DescricaoItem = DR["ItemDescricao"].ToString();
            solicitacao.NomeAluno = DR["NomeAluno"].ToString();
            solicitacao.EmailAluno = DR["EmailAluno"].ToString();
            solicitacao.FoneAluno = DR["FoneAluno"].ToString();
            solicitacao.DataHoraPerda = Convert.ToDateTime(DR["DataHoraPerda"]);
            solicitacao.LocalPerda = DR["LocalPerda"].ToString();
            solicitacao.ExtensaoArquivoImagem = DR["ExtensaoArquivoImagem"].ToString();

            solicitacao.Atendido = Convert.ToInt32(DR["Atendido"]) == 1;

            if (solicitacao.Atendido)
            {
                solicitacao.DataAtendimento = Convert.ToDateTime(DR["DataAtendimento"]);
                solicitacao.UsuarioAtendimento = new Usuario(Convert.ToInt32(DR["UsuarioAtendimento"]));
            }
        }

        CommandSelecionar.Connection.Close();
    }

    protected int DBInserir(Solicitacao solicitacao)
    {
        SqlCommand CommandInsert = new SqlCommand(@"insert into SOLICITACAO (NomeAluno,  CpfAluno,  RgAluno,  EmailAluno,  FoneAluno,  ItemNome,  ItemDescricao,  LocalPerda,  DataHoraPerda, ExtensaoArquivoImagem)
                                                                     values(@NomeAluno, @CpfAluno, @RgAluno, @EmailAluno, @FoneAluno, @ItemNome, @ItemDescricao, @LocalPerda, @DataHoraPerda, @ExtensaoArquivoImagem)

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
        CommandInsert.Parameters.Add("@ExtensaoArquivoImagem", SqlDbType.VarChar, 10);

        CommandInsert.Parameters["@NomeAluno"].Value = solicitacao.NomeAluno;
        CommandInsert.Parameters["@CpfAluno"].Value = solicitacao.CpfAluno;
        CommandInsert.Parameters["@RgAluno"].Value = solicitacao.RgAluno;
        CommandInsert.Parameters["@EmailAluno"].Value = solicitacao.EmailAluno;
        CommandInsert.Parameters["@FoneAluno"].Value = solicitacao.FoneAluno;
        CommandInsert.Parameters["@ItemNome"].Value = solicitacao.NomeItem;
        CommandInsert.Parameters["@ItemDescricao"].Value = solicitacao.DescricaoItem;
        CommandInsert.Parameters["@ExtensaoArquivoImagem"].Value = solicitacao.ExtensaoArquivoImagem;

        if (solicitacao.DataHoraPerda == new DateTime())
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

    protected void DBAtender(Solicitacao solicitacao, Usuario usuario)
    {
        SqlCommand CommandAtender = new SqlCommand(@"update SOLICITACAO
                                                     set Atendido = 1,
                                                         UsuarioAtendimento = @Usuario,
                                                         DataAtendimento = getdate()
                                                     where Codigo = @Codigo", DBTools.Conn());

        CommandAtender.CommandType = CommandType.Text;

        CommandAtender.Parameters.Add("@Usuario", SqlDbType.Int);
        CommandAtender.Parameters.Add("@Codigo", SqlDbType.Int);

        CommandAtender.Parameters["@Usuario"].Value = usuario.Codigo;
        CommandAtender.Parameters["@Codigo"].Value = solicitacao.Codigo;

        CommandAtender.Connection.Open();
        CommandAtender.ExecuteNonQuery();
        CommandAtender.Connection.Close();
    }
}