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
    public string CpfFormatado
    {
        get
        {
            return this.Cpf.Substring(0, 3) + "." +
                this.Cpf.Substring(3, 3) + "." +
                this.Cpf.Substring(6, 3) + "-" +
                this.Cpf.Substring(9, 2);
        }
    }

    public string Validar(string senha, string confirmacaoSenha)
    {
        if (string.IsNullOrEmpty(this.Nome))
        {
            return "Nome inválido!";
        }

        if (string.IsNullOrEmpty(this.Cpf))
        {
            return "Preencha corretamente o CPF!";
        }
        else
        {
            this.Cpf = this.Cpf.Replace(".", "").Replace("-", "");

            if(this.Cpf.Length != 11)
            {
                return "Um CPF precisa ter 11 dígitos, verifique!";
            }
        }

        if(this.DataNascimento == new DateTime())
        {
            return "Data de nascimento inválida!";
        }

        if(string.IsNullOrEmpty(this.Funcao))
        {
            return "Função inválida";
        }

        if(!senha.Equals(confirmacaoSenha))
        {
            return "A confirmação de senha está diferente da senha!";
        }

        if (VerificarExistencia(this.Cpf))
        {
            return "Já existe um usuário cadastrado para este CPF!";
        }

        try
        {
            this.Inserir(senha);
        }
        catch
        {
            return "Os dados estão corretos, porém houve um erro na gravação do banco de dados, o usuário não foi inserido!";
        }

        return "Usuário cadastrado com sucesso!";
    }
    public bool Logar(string senha)
    {
        return base.DBLogar(this, senha);
    }
    public void Inserir(string senha)
    {
        base.DBInserir(this, senha);
    }
    public bool VerificarExistencia(string cpf)
    {
        return base.DBVerificarExistencia(cpf);
    }
}