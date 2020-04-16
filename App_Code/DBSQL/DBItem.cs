using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DBItem
/// </summary>
public abstract class DBItem
{
    protected void DBInserir(Item item)
    {
        SqlCommand CommandInserir = new SqlCommand(@"insert into ITEM (Nome, Descricao, DataHoraEncontrado, Local, CodigoUsuarioCadastrante)
                                                                values(@Nome, @Descricao, @Data, @Local, @Cadastrante)", DBTools.Conn());

        CommandInserir.CommandType = CommandType.Text;

        CommandInserir.Parameters.Add("@Nome", SqlDbType.VarChar, 50);
        CommandInserir.Parameters.Add("@Descricao", SqlDbType.VarChar, -1);
        CommandInserir.Parameters.Add("@Data", SqlDbType.DateTime);
        CommandInserir.Parameters.Add("@Local", SqlDbType.VarChar, 50);
        CommandInserir.Parameters.Add("@Cadastrante", SqlDbType.Int);

        CommandInserir.Parameters["@Nome"].Value = item.Nome;
        CommandInserir.Parameters["@Descricao"].Value = item.Descricao;
        CommandInserir.Parameters["@Data"].Value = item.DataHoraEncontrado;
        CommandInserir.Parameters["@Local"].Value = item.LocalEncontrado;
        CommandInserir.Parameters["@Cadastrante"].Value = item.Cadastrante.Codigo;

        CommandInserir.Connection.Open();
        CommandInserir.ExecuteNonQuery();
        CommandInserir.Connection.Close();
    }

    protected void DBSelecionar(Item item)
    {
        SqlCommand CommandSelecionar = new SqlCommand(@"select Nome, Descricao, DataHoraEncontrado, Local, CodigoUsuarioCadastrante
                                                        from ITEM with(NoLock)
                                                        where Codigo = @Codigo", DBTools.Conn());

        CommandSelecionar.CommandType = CommandType.Text;

        CommandSelecionar.Parameters.Add("@Codigo", SqlDbType.Int);
        CommandSelecionar.Parameters["@Codigo"].Value = item.Codigo;

        CommandSelecionar.Connection.Open();

        SqlDataReader DR = CommandSelecionar.ExecuteReader();

        if(DR.Read())
        {
            item.Nome = DR["Nome"].ToString();
            item.Descricao = DR["Descricao"].ToString();
            item.DataHoraEncontrado = Convert.ToDateTime(DR["DataHoraEncontrado"]);
            item.LocalEncontrado = DR["Local"].ToString();
            item.Cadastrante = new Usuario(Convert.ToInt32(DR["CodigoUsuarioCadastrante"]));
        }

        CommandSelecionar.Connection.Close();
    }

    protected List<Item> DBListar(string busca)
    {
        SqlCommand CommandListar = new SqlCommand(@"select Codigo, Nome, Descricao, DataHoraEncontrado, Local, CodigoUsuarioCadastrante
                                                    from ITEM with(NoLock)
                                                    where Nome like '%' + @Busca + '%'
                                                        and Local like '%' + @Busca + '%'", DBTools.Conn());

        CommandListar.CommandType = CommandType.Text;

        CommandListar.Parameters.Add("@Busca", SqlDbType.VarChar, 50);
        CommandListar.Parameters["@Busca"].Value = busca;

        CommandListar.Connection.Open();

        SqlDataReader DR = CommandListar.ExecuteReader();

        List<Item> lista = new List<Item>();

        while (DR.Read())
        {
            Item item = new Item();

            item.Codigo = Convert.ToInt32(DR["Codigo"]);
            item.Nome = DR["Nome"].ToString();
            item.Descricao = DR["Descricao"].ToString();
            item.DataHoraEncontrado = Convert.ToDateTime(DR["DataHoraEncontrado"]);
            item.LocalEncontrado = DR["Local"].ToString();
            item.Cadastrante = new Usuario(Convert.ToInt32(DR["CodigoUsuarioCadastrante"]));

            lista.Add(item);
        }

        CommandListar.Connection.Close();

        return lista;
    }
}