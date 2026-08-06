using Microsoft.Data.Sqlite;

namespace JobApp
{
    public class AddApp
    {
        // Method to add a new job application to the database
        public void AddApplication()
        {
            Console.WriteLine("Adding application to the list...");
            // Logic to add application goes here
            // Make this step asynchronous to prevent user waiting for the operation to complete
            // For example, you can use Task.Run to run the database operation in a separate thread
            //Company, position, and status are required fields for adding a new job application
            Console.WriteLine("Please enter the company name:");
            string? company = Console.ReadLine();
            Console.WriteLine("Please enter the position:");
            string? position = Console.ReadLine();
            Console.WriteLine("Please enter the status:");
            string? status = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(company) || string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(status))
            {
                Console.WriteLine("Error: Company, position, and status are required fields. Please try again.");
                return;
            }
            AddApplicationToDatabase(company ?? "", position ?? "", status ?? "");
            Console.WriteLine("Application added successfully!");

        }
        
        public void AddApplicationToDatabase(string company, string position, string status)
        {
            using SqliteConnection connection = new SqliteConnection("Data Source=Database/Jobs.db");
            connection.Open();

            string sql = @"
                INSERT INTO Jobs (Company, Position, Status)
                VALUES (@Company, @Position, @Status);";

            using SqliteCommand command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Company", company);
            command.Parameters.AddWithValue("@Position", position);
            command.Parameters.AddWithValue("@Status", status);

            command.ExecuteNonQuery();
        }
    
    }
}