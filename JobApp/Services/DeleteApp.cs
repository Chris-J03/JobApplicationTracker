using Microsoft.Data.Sqlite;

namespace JobApp
{
    public class DeleteApp
    {
        // Method to delete a job application from the database
        public void DeleteApplication()
        {
            Console.WriteLine("Deleting application from the list...");
            // Logic to delete application goes here
            // Make this step asynchronous to prevent user waiting for the operation to complete
            // For example, you can use Task.Run to run the database operation in a separate thread
            Console.WriteLine("Please enter the ID of the application you want to delete:");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                DeleteApplicationFromDatabase(id);
                Console.WriteLine("Application deleted successfully!");
            }
            else
            {
                Console.WriteLine("Error: Invalid ID. Please try again.");
            }
        }

        //Remove the application from the database based on the provided ID
        private void DeleteApplicationFromDatabase(int id)
        {
            using SqliteConnection connection = new SqliteConnection("Data Source=Database/Jobs.db");
            connection.Open();

            string sql = @"
                DELETE FROM Jobs
                WHERE Id = @Id;";

            using SqliteCommand command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}