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

    protected void DBInserir(Usuario usuario, string senha)
    {
        SqlCommand CommandInsert = new SqlCommand(@"insert into Usuario (Nome, Cpf, DataNascimento, Funcao, Email, Senha) 
                                                                 values(@Nome, @Cpf, @DataNascimento, @Funcao, @Email, @Senha)", DBTools.Conn());

        CommandInsert.CommandType = CommandType.Text;

        CommandInsert.Parameters.Add("@Nome", SqlDbType.VarChar, 50);
        CommandInsert.Parameters.Add("@Cpf", SqlDbType.VarChar, 11);
        CommandInsert.Parameters.Add("@DataNascimento", SqlDbType.Date);
        CommandInsert.Parameters.Add("@Funcao", SqlDbType.VarChar, 15);
        CommandInsert.Parameters.Add("@Email", SqlDbType.VarChar, 100);
        CommandInsert.Parameters.Add("@Senha", SqlDbType.VarChar, -1);

        CommandInsert.Parameters["@Nome"].Value = usuario.Nome;
        CommandInsert.Parameters["@Cpf"].Value = usuario.Cpf;
        CommandInsert.Parameters["@DataNascimento"].Value = usuario.DataNascimento;
        CommandInsert.Parameters["@Funcao"].Value = usuario.Funcao;
        CommandInsert.Parameters["@Email"].Value = usuario.Email;
        CommandInsert.Parameters["@Senha"].Value = senha;

        CommandInsert.Connection.Open();
        CommandInsert.ExecuteNonQuery();
        CommandInsert.Connection.Close();
    }

    protected bool DBVerificarExistencia(string cpf)
    {
        SqlCommand CommandSelecionar = new SqlCommand(@"select count(1)
                                                        from Usuario with(NoLock)
                                                        where Cpf = @Cpf", DBTools.Conn());

        CommandSelecionar.CommandType = CommandType.Text;

        CommandSelecionar.Parameters.Add("@Cpf", SqlDbType.VarChar, 11);
        CommandSelecionar.Parameters["@Cpf"].Value = cpf;

        CommandSelecionar.Connection.Open();
        bool existe = Convert.ToInt32(CommandSelecionar.ExecuteScalar()) > 0;
        CommandSelecionar.Connection.Close();

        return existe;
    }
}