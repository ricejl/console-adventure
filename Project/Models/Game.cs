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
            Room Tower = new Room("Tower", "You enter a lofty tower with open windows, the warm summer night's breeze gently floating the tattered white curtains of the east window up and to one side before they come to rest for a moment. The moonlight gives the room an eerie glow. The floorboards align circularly, drawing your attention to the center of the room.", true);
            Room Den = new Room("Den", "Upon entering, you are struck with the smell of old books and musty leather, no doubt emanating from the shelves of books lining the north wall. The opposite wall has a door. In the center of the room is a large, mahogany wooden desk.", false);
            Room Kitchen = new Room("Kitchen", "Dusty pans hang from the ceiling and a large selection of heavily used kitchen implements are scattered along the countertops. The room feels colder than the rest of the house. The metallic air permeates the entire space.", false);
            Room DrawingRoom = new Room("Drawing Room", "Ancient, floral wallpaper curls from the walls at yellowed seams. Once heavily trafficked, the stillness is broken only by your footsteps across the creaking, wooden floorboards.", false);
            Room Cellar = new Room("Cellar", "The space around you feels like the inside of a great stone beast, heavy with moisture and pulsating with life. You are unable to see anything.", false);
            Room Yard = new Room("Front yard", "The plants are overgrown and wild. To the north is the front door.", false);
            //  Adjacent to that, just to the east are a set of double doors that look like they lead into the space beneath the house.");

            Item key = new Item("key", "Worn edges and tiny scratches hint at a long history of use. There's an oddly-shaped bit at the end of a long shank with a an ornate bow at the top reminiscent of a gape-mouthed lion.");
            // Item kettle = new Item("kettle", "A plump, white body intricately decorated on the outside with fine, hand-painted blue strokes.");
            // Item hammer = new Item("hammer", "Its rusted head and splintered handle suggests it has long been exposed to the elements, but it nonetheless appears sturdy.");
            // Item bucket = new Item("bucket", "A wooden bucket held together with two thin metal rings. Despite its age it might still hold water.");
            Item matchbook = new Item("matchbook", "The label says these came from a pub at the village center and there are only two matches torn out. They can't have been here long.");
            // Item book = new Item("book", "The title on the book's spine is hard to read--The Eternal Path or is that Bath? Rath?");
            Item bathtub = new Item("bathtub", "The clawfoot tub is situated at the room's center, and every minute or two the faucet that feeds it is dripping water.");

            // Add exits to room
            Yard.Exits.Add("north", DrawingRoom);
            DrawingRoom.Exits.Add("south", Yard);
            DrawingRoom.Exits.Add("north", Kitchen);
            DrawingRoom.Exits.Add("west", Den);
            Kitchen.Exits.Add("down", Cellar);
            Kitchen.Exits.Add("south", DrawingRoom);
            Den.Exits.Add("east", DrawingRoom);
            Den.Exits.Add("up", Tower);
            Tower.Exits.Add("down", Den);
            // Yard.Exits.Add("down", Cellar);
            // Cellar.Exits.Add("up", Yard);

            // Add items to rooms
            // Yard.Items.Add(hammer);
            // DrawingRoom.Items.Add(kettle);
            // Kitchen.Items.Add(bucket);
            DrawingRoom.Items.Add(key);
            Den.Items.Add(matchbook); //lose
            // Den.Items.Add(book);
            Tower.Items.Add(bathtub); //win

            CurrentRoom = Yard;

            Player name = new Player("");
            CurrentPlayer = name;
        }

        public Game()
        {
            Setup();
        }
    }
}