using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
    public class GameService : IGameService
    {
        private IGame _game { get; set; }

        public List<Message> Messages { get; set; }
        public GameService()
        {
            _game = new Game();
            Messages = new List<Message>();
        }
        public void Go(string direction)
        {
            //checks if there's an exit in that room at that direction
            if (_game.CurrentRoom.Exits.ContainsKey(direction))
            {
                Console.Clear();
                _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
                Messages.Add(new Message($"You walk {direction} into the {_game.CurrentRoom.Name}.\n"));
                Messages.Add(new Message($"{_game.CurrentRoom.Description}"));
                if (_game.CurrentRoom.Items.Count > 0)
                {
                    foreach (Item item in _game.CurrentRoom.Items)
                    {
                        Messages.Add(new Message($"There is a {item.Name} in the room. {item.Description}"));
                    }
                }
            }
            else
            {
                Messages.Add(new Message("You ran into a wall. Try a different direction.", ConsoleColor.Red));
            }
        }
        public void Help()
        {
            Messages.Add(new Message("-- Menu --\nQuit - quit the game\nGo + direction - to change rooms (eg, go east)\nUse + item--utilize object (eg, use key)\nTake + item - add item to inventory\nLook - gives room description\nInventory - see list of items you've taken\n"));
        }

        public void Inventory()
        {
            Messages.Add(new Message("Your item(s):"));
            foreach (Item item in _game.CurrentPlayer.Inventory)
            {
                Messages.Add(new Message($"{item.Name}"));
            }
        }

        public void Look()
        {
            Messages.Add(new Message($"{_game.CurrentRoom.Description}"));
        }

        public void Quit()
        {
            throw new System.NotImplementedException();
        }
        ///<summary>
        ///Restarts the game 
        ///</summary>
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public void Setup(string playerName)
        {
            //if string is at least one character and not empty space(s), assign playerName to current player
            if (String.IsNullOrWhiteSpace(playerName) || String.IsNullOrEmpty(playerName))
            {
                Messages.Add(new Message("Invalid name. Please try again."));
            }
            else
            {
                //?? cannot do this because CurrentPlayer is not instantiated and cannot be instantiated because it's an interface
                _game.CurrentPlayer.Name = playerName;
            }

        }
        ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
        public void TakeItem(string itemName)
        {
            // foreach (Item item in _game.CurrentRoom.Items)
            // {
            if (_game.CurrentRoom.Items[0].Name == itemName)
            {
                _game.CurrentPlayer.Inventory.Add(_game.CurrentRoom.Items[0]);
                _game.CurrentRoom.Items.Remove(_game.CurrentRoom.Items[0]);
                Messages.Add(new Message($"Taken: {itemName}"));
            }
            else
            {
                Messages.Add(new Message($"Sorry, there is no {itemName} to take."));
                // }
            }

        }
        ///<summary>
        ///No need to Pass a room since Items can only be used in the CurrentRoom
        ///Make sure you validate the item is in the room or player inventory before
        ///being able to use the item
        ///</summary>
        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}