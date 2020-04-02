using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DBTools
/// </summary>
public static class DBTools
{
    public static SqlConnection Conn()
    {
        return new SqlConnection("Server=tcp:kolodabr.database.windows.net,1433;Initial Catalog=Projeto;Persist Security Info=False;User ID=arthur.koloda;Password=@BeXx0805;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
    public static string URLImagem()
    {
        return "~/Chamados/";
    }
}