public class Menu //INCOMPLETE
{
    private HouseManager HM = new HouseManager();
    public Menu()
    {
        
    }
    public void Run()
    {
        HouseManager HM = new HouseManager();
        Console.Clear();
        int userChoice = -1;
        while (userChoice != 8) 
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Create New Room");
            Console.WriteLine("2. List Rooms");
            Console.WriteLine("3. Open Room Options");
            Console.WriteLine("4. Save House");
            Console.WriteLine("5. Load House");
            Console.WriteLine("6. Delete Room");
            Console.WriteLine("7. Activate Away Mode");
            Console.WriteLine("8. Quit");

            userChoice = HM.GetInt("Select a choice from the menu:"); //retrieves user input

            //BELOW - matches user input to a menu option
            if (userChoice == 1) //Create new room
            {
                HM.NewRoom();
            }
            else if (userChoice == 2) //List Rooms
            {
               HM.ListRooms();
            }
            else if (userChoice == 3) //Open Room Options
            {
                HM.RoomUI();
            }
            else if (userChoice == 4) //Save House
            {
                string filename = HM.GetStr("What is the filename you would like to save to? ");
                HM.SaveHouse(filename);
            }
            else if (userChoice == 5) //Load House
            {
                string filename = HM.GetStr("What is the filename you would like to load from? ");
                HM.LoadHouse(filename);
            }
            else if (userChoice == 6) //Delete Room
            {
                HM.DeleteRoom();
            }
            else if (userChoice == 7) //Activate Away Mode
            {
                HM.AwayMode();
            }
            else if (userChoice == 8) //Quit
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}