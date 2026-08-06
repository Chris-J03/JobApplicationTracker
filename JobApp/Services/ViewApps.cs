using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Runtime.Serialization;
namespace JobApp
{
    public class ViewApps
    {
        // Method to view all job applications in the database
        public void ViewApplications()
        {
            Console.WriteLine("Viewing all applications...");

            using SqliteConnection connection = new SqliteConnection("Data Source=Database/Jobs.db");
            connection.Open();
            
            string sql = @"
                SELECT Id, Company, Position, Status
                FROM Jobs;";

            using SqliteCommand command = new SqliteCommand(sql, connection);
            using SqliteDataReader reader = command.ExecuteReader();

            List<JobApp.Model.Job> jobs = new();

            while (reader.Read())
            {
                jobs.Add(new JobApp.Model.Job
                {
                    Id = reader.GetInt32(0),
                    JobName = reader.GetString(1),
                    Company = reader.GetString(2),
                    Status = reader.GetString(3)
                });
            }
        }
    }
}