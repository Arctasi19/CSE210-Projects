using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class HouseManager
{
    private List<Room> _rooms = new List<Room>();
    public HouseManager()
    {
        
    }
    public void ListRooms()
    {
        Console.Clear();
        Console.WriteLine("Rooms: ");
        for (int i = 0; i < _rooms.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {_rooms[i].GetInfo()}");
        }
        Console.WriteLine();
    }
    public List<Room> GetRooms()
    {
        return _rooms;
    }
    public void NewRoom()
    {
        _rooms.Add(new Room(GetStr("What is the name of this new room? ")));
        Console.Clear();
        Console.WriteLine("Room Created.");
    }
    public void DeleteRoom()
    {
        if (_rooms.Count() > 0)
        {
            ListRooms();
            while (true)
            {
                int deletionIndex = GetInt("Which room, by number, would you like to delete?");
                if (deletionIndex <= _rooms.Count())
                {
                    _rooms.RemoveAt(deletionIndex - 1);
                    Console.Clear();
                    Console.WriteLine("Room Deleted");
                    break;
                }
                else
                {
                    Console.WriteLine("please enter a valid room number.");
                    Thread.Sleep(2000);
                }
            }
        }
        else 
        {
            Console.Clear();
            Console.WriteLine("You have no rooms to delete.");
        }
        
    }
    public void SaveHouse(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Room room in _rooms)
            {
                outputFile.WriteLine(room.GetStringRepresentation());
                foreach (Device device in room.GetDevices())
                {
                    outputFile.WriteLine(device.GetStringRepresentation());
                }
            }
        }
        Console.Clear();
        Console.WriteLine("House and settings saved.");
    }
    public void LoadHouse(string fileName)
    {
        if (!File.Exists(fileName)) 
        {
            Console.WriteLine("House not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _rooms.Clear();
        Room currentRoom = null;

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            string type = parts[0];

            if (type == "ROOM")
            {
                currentRoom = new Room(parts[1]);
                _rooms.Add(currentRoom);
            }
            else if (currentRoom != null)
            {
                if (type == "SmartLight")
                {
                    SmartLight light = new SmartLight(parts[1], parts[2], bool.Parse(parts[3]),
                    bool.Parse(parts[4]), bool.Parse(parts[5]), int.Parse(parts[6]), parts[7]);
                    currentRoom.AddDevice(light);
                }
                else if (type == "Thermostat")
                {
                    Thermostat thermostat = new Thermostat(parts[1], parts[2], bool.Parse(parts[3]),
                    int.Parse(parts[4]));
                    currentRoom.AddDevice(thermostat);
                }
                else if (type == "Fan")
                {
                    Fan fan = new Fan(parts[1], parts[2], bool.Parse(parts[3]),
                    int.Parse(parts[4]));
                    currentRoom.AddDevice(fan);
                }
                else if (type == "Speaker")
                {
                    Speaker speaker = new Speaker(parts[1], parts[2], bool.Parse(parts[3]),
                    int.Parse(parts[4]));
                    currentRoom.AddDevice(speaker);
                }
            }
        }
        Console.Clear();
        Console.WriteLine("House and settings Loaded from file.");
    }
    public void AwayMode()
    {
        Console.WriteLine("Turning all devices off for Away Mode... ");
        for (int r = 0; r < _rooms.Count(); r++)
        {
            _rooms[r].AllOff();
        }
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("All devices now off for Away Mode.");
    }
    public void RoomUI()
    {
        if (_rooms.Count() > 0)
        {
            ListRooms();
            while (true)
            {
                int roomSelect = GetInt("Which room, by number, would you like to access?");
                if (roomSelect <= _rooms.Count() && roomSelect > 0)
                {
                    Console.Clear();
                    Room selectedRoom = _rooms[roomSelect-1];

                    int userChoice = -1;
                    while (userChoice != 8)
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine($"Room: {selectedRoom.GetInfo()}");
                        Console.WriteLine("\nWhat would you like to do?");
                        Console.WriteLine("1. Add New Device");
                        Console.WriteLine("2. Delete Device");
                        Console.WriteLine("3. List Devices");
                        Console.WriteLine("4. Access a Device");
                        Console.WriteLine("5. Turn All Room Devices Off");
                        Console.WriteLine("6. Turn All Room Lights Off");
                        Console.WriteLine("7. Turn All Room Lights On");
                        Console.WriteLine("8. Go back to the Main Menu");

                        userChoice = GetInt("Select a choice from the menu:"); //retrieves user input

                        if (userChoice == 1) //Create a new device
                        {
                            selectedRoom.NewDevice();
                        }
                        else if (userChoice == 2) //Delete a device
                        {
                            selectedRoom.DeleteDevice();
                        }
                        else if (userChoice == 3) //List all devices in Room
                        {
                            selectedRoom.ListDevices();
                        }
                        else if (userChoice == 4) //Access a device menu
                        {
                            selectedRoom.DeviceAccess();
                        }
                        else if (userChoice == 5) //Turn all devices off
                        {
                            selectedRoom.AllOff();
                        }
                        else if (userChoice == 6) //All lights off
                        {
                            selectedRoom.AllLightsOff();
                        }
                        else if (userChoice == 7) //All lights on
                        {
                            selectedRoom.AllLightsOn();
                        }
                        else if (userChoice == 8)
                        {
                            Console.Clear();
                            Console.WriteLine("Returning To Main Menu.");
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid menu option.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("please enter a valid room option.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                break;
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("You currently have no rooms to access.");
        }
    }
    public int GetInt(string prompt)
    {
        while (true)
        {
            int number;
            Console.WriteLine(prompt);
            Console.Write("> ");
            string userInput = Console.ReadLine();
            bool success = int.TryParse(userInput, out number);
            if (success)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Please enter only digits");
            }
        }
    }
    public string GetStr(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        string userInput = Console.ReadLine();
        return userInput;
    }
}