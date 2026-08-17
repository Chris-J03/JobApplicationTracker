using System;
using JobApp.Interface;
using JobApp.Database;
using Microsoft.Data.Sqlite;
using JobSearchEmailReader.Services;
namespace JobApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SQLData database = new SQLData();

            // Initialise the database and establish a connection to it
            database.Initialise();
            database.GetConnection();

            // Call the Run method to begin the program's execution and display the menu options to the user
            Menu menu = new Menu();
            menu.Run();

            

        const string clientId = "";
        const string emailAddress = "chris.j031@outlook.com";

        var emailService = new EmailService(
            clientId,
            emailAddress
        );

        try
        {
            await emailService.TestConnectionAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong:");
            Console.WriteLine(ex.Message);
        }
        }
    }
}
