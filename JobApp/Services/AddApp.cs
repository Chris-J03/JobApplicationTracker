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
        }
        
        
    
    }
}