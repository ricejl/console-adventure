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
            List<Message> Messages = new List<Message>();
        }
        public void Go(string direction)
        {
            //checks if there's an exit in that room at that direction
            if (_game.CurrentRoom.Exits.ContainsKey(direction))
            {
                _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
                Messages.Add(new Message($"You walk {direction} into the {_game.CurrentRoom.Name}."));
            }
            else
            {
                Messages.Add(new Message("You ran into a wall. Try a different direction.", ConsoleColor.Red));
            }
        }
        public void Help()
        {
            throw new System.NotImplementedException();
        }

        public void Inventory()
        {
            throw new System.NotImplementedException();
        }

        public void Look()
        {
            throw new System.NotImplementedException();
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
            //game.currentplayer = playerName
            if (String.IsNullOrWhiteSpace(playerName) || String.IsNullOrEmpty(playerName))
            {
                Messages.Add(new Message("Invalid name. Please try again."));
            }
            else
            {
                _game.CurrentPlayer.Name = playerName;
            }

        }
        ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
        public void TakeItem(string itemName)
        {
            foreach (var item in _game.CurrentRoom.Items)
            {
                if (item.Name == itemName)
                {
                    _game.CurrentPlayer.Inventory.Add(item); //add to player inventory
                }
                else
                {
                    //error, sorry there is no
                }
            }

            //if room contains item, add to inventory
            //else give error message

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