using System;
using System.Collections.Generic;
using System.Text;
namespace JobApp.Database;
using Microsoft.Data.Sqlite;

public class SQLData
{
    private readonly string connectionString = "Data Source=jobs.db";

    public SqliteConnection GetConnection()
    {
        return new SqliteConnection(connectionString);
    }

    public void Initialise()
    {
        using SqliteConnection connection = GetConnection();

        connection.Open();

        string sql =
        @"
        CREATE TABLE IF NOT EXISTS Jobs
        (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Company TEXT NOT NULL,
            Position TEXT NOT NULL,
            Status TEXT NOT NULL
        );
        ";

        using SqliteCommand command = new SqliteCommand(sql, connection);

        command.ExecuteNonQuery();
    }
}