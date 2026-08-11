using System;
using System.Collections.Generic;

namespace JobApp.Interface
{
    public interface IConsole
    {
        string? ReadLine();
        void WriteLine(string? message);
    }

    public class ConsoleWrapper : IConsole
    {
        public string? ReadLine() => Console.ReadLine();
        public void WriteLine(string? message) => Console.WriteLine(message);
    }

    public enum MenuOption
    {
        Invalid = 0,
        AddApplication = 1,
        RemoveApplication = 2,
        ViewApplications = 3,
        Exit = 4
    }

    public class Menu
    {
        private readonly IConsole _console;
        private readonly Dictionary<MenuOption, Action> _actions;

        public Menu(IConsole? console = null)
        {
            _console = console ?? new ConsoleWrapper();
            _actions = new Dictionary<MenuOption, Action>
            {
                { MenuOption.AddApplication, AddApplication },
                { MenuOption.RemoveApplication, RemoveApplication },
                { MenuOption.ViewApplications, ViewApplications },
                { MenuOption.Exit, ExitApplication }
            };
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                DisplayMenu();
                MenuOption choice = ReadMenuChoice();
                running = HandleChoice(choice);
            }
        }

        private void DisplayMenu()
        {
            _console.WriteLine("Please select from the list of options below:");
            _console.WriteLine("1. Add application to list");
            _console.WriteLine("2. Remove application from list");
            _console.WriteLine("3. View applications in list");
            _console.WriteLine("4. Exit");
        }

        private MenuOption ReadMenuChoice()
        {
            while (true)
            {
                string? inputLine = _console.ReadLine();

                if (!int.TryParse(inputLine, out int numericChoice) ||
                    !Enum.IsDefined(typeof(MenuOption), numericChoice))
                {
                    _console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    continue;
                }

                return (MenuOption)numericChoice;
            }
        }

        private bool HandleChoice(MenuOption choice)
        {
            if (_actions.TryGetValue(choice, out Action action))
            {
                action();
                return choice != MenuOption.Exit;
            }

            _console.WriteLine("Invalid selection. Please try again.");
            return true;
        }

        private void AddApplication()
        {
            _console.WriteLine("You selected option 1: Add application to list");
            AddApp addApp = new AddApp();
            addApp.AddApplication();
        }

        private void RemoveApplication()
        {
            _console.WriteLine("You selected option 2: Remove application from list");
            // TODO: implement RemoveApp class and removal logic
            DeleteApp deleteApp = new DeleteApp();
            deleteApp.DeleteApplication();
        }

        private void ViewApplications()
        {
            _console.WriteLine("You selected option 3: View applications in list");
            ViewApps viewApps = new ViewApps();
            viewApps.ViewApplications();
        }

        private void ExitApplication()
        {
            _console.WriteLine("Exiting the program. Goodbye!");
        }
    }
}
