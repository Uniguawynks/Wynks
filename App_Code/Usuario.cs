using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Usuario
/// </summary>
public class Usuario : DBUsuario
{
    private int _codigo;
    private string _nome;
    private string _cpf;
    private DateTime _dataNascimento;
    private string _funcao;
    private string _email;
    public Usuario()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public int Codigo { get => _codigo; set => _codigo = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Cpf { get => _cpf; set => _cpf = value; }
    public DateTime DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
    public string Funcao { get => _funcao; set => _funcao = value; }
    public string Email { get => _email; set => _email = value; }

    public string Validar(string nome, string cpf, DateTime dataNascimento, string funcao)
    {
        if (string.IsNullOrEmpty(nome))
        {
            return "Nome inválido!";
        }

        if (string.IsNullOrEmpty(cpf))
        {
            return "Preencha corretamente o CPF!";
        }
        else
        {
            if(cpf.Length != 11)
            {
                return "Um CPF precisa ter 11 dígitos, verifique!";
            }
        }

        if(dataNascimento == new DateTime())
        {
            return "Data de nascimento inválida!";
        }

        if(string.IsNullOrEmpty(funcao))
        {
            return "Função inválida";
        }

        return "";
    }
    public bool Logar(string senha)
    {
        return base.DBLogar(this, senha);
    }
}