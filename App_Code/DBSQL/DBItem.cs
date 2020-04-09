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
        CommandInserir.Parameters["Data"].Value = item.DataHoraEncontrado;
        CommandInserir.Parameters["@Local"].Value = item.LocalEncontrado;
        CommandInserir.Parameters["@Cadastrante"].Value = item.Cadastrante.Codigo;

        CommandInserir.Connection.Open();
        CommandInserir.ExecuteNonQuery();
        CommandInserir.Connection.Close();
    }
}