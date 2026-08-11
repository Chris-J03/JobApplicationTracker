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

            List<Model.Job> jobs = new();

            while (reader.Read())
            {
                jobs.Add(new Model.Job
                {
                    Id = reader.GetInt32(0),
                    Company = reader.GetString(1),
                    Position = reader.GetString(2),
                    Status = reader.GetString(3)
                });
            }

            foreach (Model.Job job in jobs)
            {
                Console.WriteLine($"ID: {job.Id}");
                Console.WriteLine($"Position: {job.Position}");
                Console.WriteLine($"Company: {job.Company}");
                Console.WriteLine($"Status: {job.Status}");
                Console.WriteLine("----------------------");
                System.Threading.Thread.Sleep(4000);
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}