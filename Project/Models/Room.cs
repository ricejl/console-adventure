using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, IRoom> Exits { get; set; }

        // public IRoom Go(string direction)
        // {
        //     //checks if there's an exit in that room at that direction
        //     if (Exits.ContainsKey(direction))
        //     {
        //         // return this;
        //     }
        //     else
        //     {
        //         // return same room;
        //         //FIXME
        //     }
        //     //if yes, return appropiate IRoom
        //     //if no, return same room and give feedback
        // }

        public Room(string name, string description, bool locked)
        {
            Name = name;
            Description = description;
            Locked = locked;
            Items = new List<Item>();
            Exits = new Dictionary<string, IRoom>();
        }
    }
}