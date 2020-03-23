using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DBUsuario
/// </summary>
public abstract class DBUsuario
{
    protected bool DBLogar(Usuario usuario, string senha)
    {
        SqlCommand CommandLogar = new SqlCommand(@"select count(1)[
                                                   from USUARIO with(NoLock)
                                                    where Email = @Login
                                                        and Senha = @Senha", DBTools.Conn());

        CommandLogar.CommandType = CommandType.Text;

        CommandLogar.Parameters.Add("@Login", SqlDbType.VarChar, 30);
        CommandLogar.Parameters.Add("@Senha", SqlDbType.VarChar, -1);

        CommandLogar.Parameters["@Login"].Value = usuario.Email;
        CommandLogar.Parameters["@Senha"].Value = senha;

        CommandLogar.Connection.Open();

        bool correto = Convert.ToInt32(CommandLogar.ExecuteScalar()) > 0;

        CommandLogar.Connection.Close();

        return correto;
    }
}