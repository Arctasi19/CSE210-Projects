using System.Threading.Channels;

public class Room 
{
    private List<Device> _devices = new List<Device>();
    private string _roomName;
    public Room(string name)
    {
        _roomName = name;
    }
    public void NewDevice()
    {
        Console.Clear();
        List<String> affirmative = ["yes", "y"];
        while (true)
        {
            Console.WriteLine("Devices:\n1. SmartLight\n2. Fan\n3. Speaker\n4. Thermostat");
            int deviceCreate = GetInt("What type of device, by number, would you like to create?");
            if (deviceCreate >= 1 && deviceCreate <= 4)
            {
                if (deviceCreate == 1) //Light
                {
                    Console.WriteLine("Creating a new SmartLight!");
                    string name = GetStr("What is this Light's name?");
                    string desc = GetStr("What is a short description for this light?");

                    string dimmableStr = GetStr("Is this light dimmable? (yes or no)");
                    bool dimmable = false;
                    if (affirmative.Contains(dimmableStr.ToLower()))
                    {
                        dimmable = true;
                    }

                    string colorStr = GetStr("Is this light color changeable? (yes or no)");
                    bool colorChangeable = false;
                    if (affirmative.Contains(colorStr.ToLower()))
                    {
                        colorChangeable = true;
                    }
                    
                    SmartLight light = new SmartLight(name, desc, dimmable, colorChangeable);
                    _devices.Add(light);
                    Console.Clear();
                    Console.WriteLine($"Smartlight {name} added to {_roomName}.");
                    break;
                }
                else if (deviceCreate == 2) //Fan
                {
                    Console.WriteLine("Creating a new Fan!");
                    string name = GetStr("What is this Fan's name?");
                    string desc = GetStr("What is a short description for this Fan?");

                    Fan fan = new Fan(name, desc);
                    _devices.Add(fan);
                    Console.Clear();
                    Console.WriteLine($"Fan {name} added to {_roomName}.");
                    break;
                }
                else if (deviceCreate == 3) //Speaker
                {
                    Console.WriteLine("Creating a new Speaker!");
                    string name = GetStr("What is this Speaker's name?");
                    string desc = GetStr("What is a short description for this Speaker?");

                    Speaker speaker = new Speaker(name, desc);
                    _devices.Add(speaker);
                    Console.Clear();
                    Console.WriteLine($"Speaker {name} added to {_roomName}.");
                    break;
                }
                else if (deviceCreate == 4) //Thermostat
                {
                    Console.WriteLine("Creating a new Thermostat!");
                    string name = GetStr("What is this Thermostat's name?");
                    string desc = GetStr("What is a short description for this Thermostat?");

                    Thermostat thermostat = new Thermostat(name, desc);
                    _devices.Add(thermostat);
                    Console.Clear();
                    Console.WriteLine($"Thermostat {name} added to {_roomName}.");
                    break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid device number.");
            }
        }
    }
    public void DeleteDevice()
    {
        if (_devices.Count() > 0)
        {
            Console.Clear();
            ListDevices();
            while (true)
            {
                int deletionIndex = GetInt("Which device, by number, would you like to delete?");
                if (deletionIndex <= _devices.Count())
                {
                    _devices.RemoveAt(deletionIndex - 1);
                    Console.Clear();
                    Console.WriteLine("Device deleted.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid device number.");
                    Thread.Sleep(2000);
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("You have no devices to delete.");
        }
    }
    public void ListDevices()
    {
        Console.Clear();
        Console.WriteLine($"Devices in {_roomName}: ");
        for (int i = 0; i < _devices.Count(); i++)
        {
            Console.WriteLine($"{i+1}. {_devices[i].GetInfo()}");
        }
        Console.WriteLine();
    }
    public void AddDevice(Device device)
    {
        _devices.Add(device);
        Console.Clear();
        Console.WriteLine("Device Added.");
    }
    public void AllOff()
    {
        foreach(Device device in _devices)
        {
            device.ActiveOff();
        }
    }
    public void AllLightsOff()
    {
        foreach(Device device in _devices)
        {
            if (device is SmartLight)
            {
                device.ActiveOff();
            }
        }
        Console.Clear();
        Console.WriteLine("All Lights are now Off.");
    }
    public void AllLightsOn()
    {
        foreach(Device device in _devices)
        {
            if (device is SmartLight)
            {
                device.ActiveOn();
            }
        }
        Console.Clear();
        Console.WriteLine("All Lights in this room are now On.");
    }
    public string GetInfo()
    {
        return $"{_roomName} ({_devices.Count} devices)";
    }
    public List<Device> GetDevices()
    {
        return _devices;
    }
    public string GetStringRepresentation()
    {
        return $"ROOM|{_roomName}";
    }
    public void DeviceAccess()
    {
        if (_devices.Count() > 0)
        {
            while (true)
            {
                Console.Clear();
                ListDevices();
                int deviceSelect = GetInt("Which device, by number, would you like to access?");
                if (deviceSelect <= _devices.Count() && deviceSelect > 0)
                {
                    Console.Clear();
                    Device selectedDevice = _devices[deviceSelect-1];
                    Console.Clear();
                    _devices[deviceSelect-1].DeviceUI();
                    break;
                }
                else
                {
                    Console.WriteLine("please enter a valid device option.");
                    Thread.Sleep(2000);
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("This room has no devices to access.");
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