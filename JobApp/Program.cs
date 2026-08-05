using System;
using JobApp.Interface;
using JobApp.Database;
using Microsoft.Data.Sqlite;
namespace JobApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLData database = new SQLData();

            // Initialise the database and establish a connection to it
            database.Initialise();
            database.GetConnection();

            // Call the Run method to begin the program's execution and display the menu options to the user
            Menu.Run();   
        }
    }
}
