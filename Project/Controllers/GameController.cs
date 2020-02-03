using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

    public class GameController : IGameController
    {
        private GameService _gameService { get; set; } = new GameService();
        private bool _creeping = true;

        //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
        public void Run()
        {
            // _gameService.PrintMenu();
            Console.WriteLine("Enter your name.");
            string playerName = Console.ReadLine();
            _gameService.Setup(playerName);
            while (_creeping)
            {
                PrintMessages();
                GetUserInput();
            }
            Console.Clear();
            Console.WriteLine("Okay, bye.");
        }

        //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
        public void GetUserInput()
        {
            Console.WriteLine("What would you like to do? Type 'help' for options.");
            string input = Console.ReadLine().ToLower() + " ";
            string command = input.Substring(0, input.IndexOf(" "));
            string option = input.Substring(input.IndexOf(" ") + 1).Trim();
            //NOTE this will take the user input and parse it into a command and option.
            //IE: take silver key => command = "take" option = "silver key"
            //commands = quit, inventory, look
            Console.Clear();
            switch (command)
            {
                case "quit":
                    _creeping = false;
                    break;
                case "look":
                    _gameService.Look();
                    break;
                case "inventory":
                    _gameService.Inventory();
                    break;
                case "help":
                    _gameService.Help();
                    break;
                case "go":
                    Console.Clear();
                    _gameService.Go(option);
                    break;
                case "take":
                    _gameService.TakeItem(option);
                    break;
                case "use":
                    _gameService.UseItem(option);
                    break;
                default:
                    System.Console.WriteLine("Invalid command");
                    break;
            }

        }

        //NOTE this should print your messages for the game.
        private void PrintMessages()
        {
            foreach (Message message in _gameService.Messages)
            {
                message.Print();
            }
        }

    }
}