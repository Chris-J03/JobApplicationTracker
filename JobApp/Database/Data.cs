using System;
using System.Collections.Generic;
using System.Text;
namespace JobApp.Database;
using Microsoft.Data.Sqlite;

public class Database
{
    private readonly string connectionString =
        "Data Source=jobs.db";

    public SqliteConnection GetConnection()
    {
        return new SqliteConnection(connectionString);
    }
}