using System;
using JobApp.Interface;
using JobApp.Database;
using Microsoft.Data.Sqlite;
using JobSearchEmailReader.Services;
using Microsoft.Extensions.Configuration;
using JobApp.Model;
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

            JobRepository repository = new(database);

            // Call the Run method to begin the program's execution and display the menu options to the user
            Menu menu = new Menu();
            menu.Run();

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            var clientId = configuration["Outlook:ClientId"];
            var emailAddress = configuration["Outlook:EmailAddress"];

            if (string.IsNullOrWhiteSpace(clientId) ||
                string.IsNullOrWhiteSpace(emailAddress))
            {
                Console.WriteLine("Outlook configuration is missing.");
                return;
            }

            var emailService = new EmailService(
                clientId,
                emailAddress
            );

            try
            {
                var emails = await emailService.ReadInboxAsync();

                foreach (var email in emails)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"From: {email.Sender}");
                    Console.WriteLine($"Subject: {email.Subject}");
                    Console.WriteLine($"Date: {email.Date}");
                    Console.WriteLine();
                    Console.WriteLine(email.Body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
