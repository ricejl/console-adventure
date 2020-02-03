using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Controllers;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
    public class GameService : IGameService
    {
        private IGame _game { get; set; }

        public List<Message> Messages { get; set; }

        public bool Active { get; set; } = true;
        public GameService()
        {
            _game = new Game();
            Messages = new List<Message>();
        }
        public void Go(string direction)
        {
            //checks if there's an exit in that room at that direction
            if (_game.CurrentRoom.Exits.ContainsKey(direction) && _game.CurrentRoom.Exits[direction].Locked)
            {
                Messages.Add(new Message("It's locked.", ConsoleColor.DarkYellow));
            }
            else if (_game.CurrentRoom.Exits.ContainsKey(direction) && !_game.CurrentRoom.Exits[direction].Locked)
            {
                Messages.Clear();
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
            Messages.Add(new Message("-- Menu --\nQuit - quit the game\nReset - start over\nGo + direction - to change rooms (eg, go east)\nUse + item--utilize object (eg, use key)\nTake + item - add item to inventory\nLook - gives room description\nInventory - see list of items you've taken\n"));
        }

        public void Inventory()
        {
            Messages.Add(new Message("\nYour item(s):", ConsoleColor.Magenta));
            foreach (Item item in _game.CurrentPlayer.Inventory)
            {
                Messages.Add(new Message($"{item.Name}", ConsoleColor.Magenta));
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
            Console.Clear();
            GameController gc = new GameController();
            gc.Run();
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
            if (_game.CurrentRoom.Items[0].Name == itemName)
            {
                _game.CurrentPlayer.Inventory.Add(_game.CurrentRoom.Items[0]);
                _game.CurrentRoom.Items.Remove(_game.CurrentRoom.Items[0]);
                Messages.Add(new Message($"\nTaken: {itemName}", ConsoleColor.DarkGreen));
            }
            else
            {
                Messages.Add(new Message($"Sorry, there is no {itemName} to take.", ConsoleColor.Red));
                // }
            }

        }
        ///<summary>
        ///No need to Pass a room since Items can only be used in the CurrentRoom
        ///Make sure you validate the item is in the room or player inventory before
        ///being able to use the item
        ///</summary>
        private bool _hasItem = false;
        private bool _itemInRoom = false;
        public void UseItem(string itemName)
        {
            foreach (Item item in _game.CurrentPlayer.Inventory)
            {
                if (itemName == item.Name)
                { _hasItem = true; }
            }
            foreach (Item item in _game.CurrentRoom.Items)
            {
                if (itemName == item.Name)
                { _itemInRoom = true; }
            }
            if (_itemInRoom || _hasItem)
            {
                switch (itemName)
                {
                    case "key":
                        if (_game.CurrentRoom.Name == "Den")
                        {
                            _game.CurrentRoom.Exits["up"].Locked = false;
                            Messages.Add(new Message("You slide the key into the door and with a heavy, echoing clank it unlocks and groans open."));
                        }
                        break;
                    case "bathtub":
                        if (_game.CurrentRoom.Name == "Tower")
                        {
                            Messages.Add(new Message("You turn on the faucet. A brilliantly clear liquid begins to fill the tub. It looks iridescent, almost glowing. You're not sure if it's the effect of the moonlight or something else entirely. You climb inside and sink down in the water, closing your eyes as you feel the world receding."));
                            Messages.Add(new Message("You win.", ConsoleColor.DarkCyan));
                            Active = false;
                        }
                        else
                        {
                            Messages.Add(new Message("The bathrub is no longer connected to a water source and is unusable."));
                        }
                        break;
                    case "matchbook":
                        if (_game.CurrentRoom.Name != "Cellar")
                        {
                            Messages.Add(new Message("You strike a match and it catches on the curtain. Like a spark on gasoline, it lights afire and the whole room is engulfed."));
                            Messages.Add(new Message("Game over", ConsoleColor.DarkRed));
                            Active = false;
                        }
                        else
                        {
                            Messages.Add(new Message("You strike a match and see the cellar is teaming with cockroaches scrambling over each other to get away from the light source."));
                        }
                        break;
                    default:
                        {
                            Messages.Add(new Message($"The {itemName} cannot be used in this room."));
                            break;
                        }
                }

            }
            else
            {
                Messages.Add(new Message("Item not available."));
            }
        }
    }
}