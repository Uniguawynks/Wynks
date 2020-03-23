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
        return new SqlConnection();
    }
}