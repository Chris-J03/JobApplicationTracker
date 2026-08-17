using Microsoft.Data.Sqlite;
using JobApp.Model;

namespace JobApp.Database;

public class JobRepository
{
    private readonly SQLData _database;

    public JobRepository(SQLData database)
    {
        _database = database;
    }

    public void AddJob(Job job)
    {
        using SqliteConnection connection = _database.GetConnection();

        connection.Open();

        string sql =
        """
        INSERT INTO Jobs
            (Company, Position, Status, EmailId)
        VALUES
            ($company, $position, $status, $emailId);
        """;

        using SqliteCommand command = new(sql, connection);

        command.Parameters.AddWithValue(
            "$company",
            job.Company
        );

        command.Parameters.AddWithValue(
            "$position",
            job.Position
        );

        command.Parameters.AddWithValue(
            "$status",
            job.Status
        );

        command.Parameters.AddWithValue(
            "$emailId",
            job.EmailId
        );

        command.ExecuteNonQuery();
    }
}