using System;
using System.Data.SqlClient;
using Dapper;

namespace login.Models;

static public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Dream Match; trusted_connection=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}