﻿using System;
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
        SqlCommand CommandLogar = new SqlCommand(@"select count(1)
                                                   from USUARIO with(NoLock)
                                                    where Email = @Login
                                                        and Senha = @Senha
                                                        and Ativo = 1", DBTools.Conn());

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

    protected void DBSelecionar(Usuario usuario)
    {
        SqlCommand CommandSelecionar = new SqlCommand(@"select Nome, Cpf, DataNascimento, Funcao, Email, Ativo
                                                        from USUARIO with(NoLock)
                                                        where Codigo = @Codigo", DBTools.Conn());

        CommandSelecionar.CommandType = CommandType.Text;

        CommandSelecionar.Parameters.Add("@Codigo", SqlDbType.Int);
        CommandSelecionar.Parameters["@Codigo"].Value = usuario.Codigo;

        CommandSelecionar.Connection.Open();

        SqlDataReader DR = CommandSelecionar.ExecuteReader();

        if (DR.Read())
        {
            usuario.Nome = DR["Nome"].ToString();
            usuario.Cpf = DR["Cpf"].ToString();
            usuario.DataNascimento = Convert.ToDateTime(DR["DataNascimento"]);
            usuario.Funcao = DR["Funcao"].ToString();
            usuario.Email = DR["Email"].ToString();
            usuario.Ativo = Convert.ToBoolean(DR["Ativo"]);
        }

        CommandSelecionar.Connection.Close();
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
        CommandInsert.Parameters.Add("@Email", SqlDbType.VarChar, 255);
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

    protected void DBAtualizar(Usuario usuario)
    {
        SqlCommand CommandUpdate = new SqlCommand(@"update USUARIO
                                                    set Nome = @Nome, 
                                                        Cpf = @Cpf, 
                                                        DataNascimento = @DataNascimento, 
                                                        Funcao = @Funcao, 
                                                        Email = @Email", DBTools.Conn());

        CommandUpdate.CommandType = CommandType.Text;

        CommandUpdate.Parameters.Add("@Nome", SqlDbType.VarChar, 50);
        CommandUpdate.Parameters.Add("@Cpf", SqlDbType.VarChar, 11);
        CommandUpdate.Parameters.Add("@DataNascimento", SqlDbType.Date);
        CommandUpdate.Parameters.Add("@Funcao", SqlDbType.VarChar, 15);
        CommandUpdate.Parameters.Add("@Email", SqlDbType.VarChar, 255);

        CommandUpdate.Parameters["@Nome"].Value = usuario.Nome;
        CommandUpdate.Parameters["@Cpf"].Value = usuario.Cpf;
        CommandUpdate.Parameters["@DataNascimento"].Value = usuario.DataNascimento;
        CommandUpdate.Parameters["@Funcao"].Value = usuario.Funcao;
        CommandUpdate.Parameters["@Email"].Value = usuario.Email;

        CommandUpdate.Connection.Open();
        CommandUpdate.ExecuteNonQuery();
        CommandUpdate.Connection.Close();
    }

    protected List<Usuario> DBListar(string busca)
    {
        SqlCommand CommandListar = new SqlCommand(@"select Codigo, Nome, Cpf, DataNascimento, Funcao, Email, Ativo
                                                    from USUARIO with(NoLock)
                                                    where Nome like '%' + @Busca + '%'
                                                       or Cpf like @Busca + '%'", DBTools.Conn());

        CommandListar.CommandType = CommandType.Text;

        CommandListar.Parameters.Add("@Busca", SqlDbType.VarChar, 50);
        CommandListar.Parameters["@Busca"].Value = busca;

        CommandListar.Connection.Open();

        SqlDataReader DR = CommandListar.ExecuteReader();

        List<Usuario> lista = new List<Usuario>();

        while (DR.Read())
        {
            Usuario item = new Usuario();

            item.Codigo = Convert.ToInt32(DR["Codigo"]);
            item.Nome = DR["Nome"].ToString();
            item.Cpf = DR["Cpf"].ToString();
            item.DataNascimento = Convert.ToDateTime(DR["DataNascimento"]);
            item.Funcao = DR["Funcao"].ToString();
            item.Email = DR["Email"].ToString();
            item.Ativo = Convert.ToBoolean(DR["Ativo"]);

            lista.Add(item);
        }

        CommandListar.Connection.Close();

        return lista;
    }
    protected void DBDesativar(Usuario usuario)
    {
        SqlCommand CommandDesativar = new SqlCommand(@"update USUARIO
                                                        set Ativo = 0
                                                        where Codigo = @Codigo", DBTools.Conn());

        CommandDesativar.CommandType = CommandType.Text;

        CommandDesativar.Parameters.Add("@Codigo", SqlDbType.Int);
        CommandDesativar.Parameters["@Codigo"].Value = usuario.Codigo;

        CommandDesativar.Connection.Open();
        CommandDesativar.ExecuteNonQuery();
        CommandDesativar.Connection.Close();
    }
}