using System;
using System.Collections.Generic;
using System.Text;
namespace JobApp.Interface
{
    static class Menu
    {
        // Method to run the menu loop and handle user input
        public static void Run()
        {
            bool running = true;
            while (running)
            {
                DisplayMenu();
                int input = takeInput();
                running = handleInput(input);
            }
        }
        // Method to display the menu options to the user
        static void DisplayMenu()
        {
            // Options menu for the application list management program
            Console.WriteLine("Please select from the list of options below:");

            Console.WriteLine("1. Add application to list");
            Console.WriteLine("2. Remove application from list");
            Console.WriteLine("3. View applications in list");
            Console.WriteLine("4. Exit");
        }

        public static int takeInput()
        {
            string? inputLine = Console.ReadLine();
            if (!int.TryParse(inputLine, out int input))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                return -1;
            }
            return input;
        }
        // Method to handle the user's input and perform the corresponding action
        static bool handleInput(int input)
        {
            switch (input)
            {
                case 1:
                    Console.WriteLine("You selected option 1: Add application to list");
                    // Call method to add application
                    break;
                case 2:
                    Console.WriteLine("You selected option 2: Remove application from list");
                    // Call method to remove application
                    break;
                case 3:
                    Console.WriteLine("You selected option 3: View applications in list");
                    // Call method to view applications
                    break;
                case 4:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return false; // Exit the loop and terminate the program
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
            return true; // Continue running the menu
        }
    }
}
