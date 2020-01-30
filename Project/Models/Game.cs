using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
    public class Game : IGame
    {
        public IRoom CurrentRoom { get; set; }
        public IPlayer CurrentPlayer { get; set; }

        //NOTE Make yo rooms here...
        public void Setup()
        {
            // TODO create rooms
            Room Tower = new Room("Tower", "You enter a lofty tower with open windows, the wind whipping the shudders to and frow. The moonlight gives the room an eerie glow.");
            Room Den = new Room("Den", "Upon entering, you are struck with the smell of old books and musty leather, no doubt emanating from the shelves of books lining the west and south walls. In the center of the room is a large, mahogany wooden desk.");
            Room Kitchen = new Room("Kitchen", "Dusty pans hang from the ceiling and a large selection of heavily used kitchen implements are scattered along the countertops. The room feels colder than the rest of the house. The metallic air permeates the entire space.");
            Room DrawingRoom = new Room("Drawing Room", "Ancient, floral wallpaper curls from the walls at yellowed seams. Once heavily trafficked, the stillness is broken only by your footsteps across the creaking, wooden floorboards.");
            Room Cellar = new Room("Cellar", "The space around you feels like the inside of a great stone beast, heavy with moisture and pulsating with life. You are unable to see anything.");
        }
    }
}