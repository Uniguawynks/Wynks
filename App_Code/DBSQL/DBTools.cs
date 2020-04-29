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
        return new SqlConnection("Server=localhost;Database=Wynks;Trusted_Connection=True;Connection Timeout=30;");
    }
    public static string URLImagemChamado()
    {
        return "C:/Users/Arthur/Desktop/Wynks2/Chamados/";
    }
    public static string URLImagemItem()
    {
        return "C:/Users/Arthur/Desktop/Wynks2/Itens/";
    }
    public static string URLImagemItemCurto()
    {
        return "~/Itens/";
    }
}