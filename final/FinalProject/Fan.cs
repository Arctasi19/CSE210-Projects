public class Fan : Device 
{
    private int _speed;
    public Fan(string name, string desc) : base(name, desc)
    {
        
    }
    public Fan(string name, string desc, bool active, int speed) : base(name, desc, active)
    {
        _speed = speed;
    }
    public void SetSpeed(int speed)
    {
        _speed = speed;
    }
    public override string GetStatus()
    {
        string status = _isActive? "ON" : "OFF";
        return $"{_deviceName} " + status + $" Current Set Speed: {_speed}";
    }
    public override string GetStringRepresentation()
    {
        return $"Fan|{_deviceName}|{_deviceDesc}|{_isActive}|{_speed}";
    }
    public override void DeviceUI()
    {
        int userChoice = -1;
        while (userChoice != 8)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine($"Device: {GetInfo()}");
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Status");
            Console.WriteLine("2. Turn On");
            Console.WriteLine("3. Turn Off");
            Console.WriteLine("4. Set Desired Temperature");
            Console.WriteLine("5. Go Back To Room Menu");

            userChoice = GetInt("Select a choice from the menu:"); //retrieves user input

            if (userChoice == 1) //Get Status
            {
                Console.Clear();
                Console.WriteLine(GetStatus());
            }
            else if (userChoice == 2) //Turn On
            {
                ActiveOn();
                Console.Clear();
            }
            else if (userChoice == 3) //Turn Off
            {
                ActiveOff();
                Console.Clear();
            }
            else if (userChoice == 4) //Set Speed
            {
                while (true)
                {
                    int speed = GetInt("What speed setting would you like this fan to be? (1 2 3)");
                    if (speed <= 3 && speed >= 1)
                    {
                        SetSpeed(speed);
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid speed setting from 1 to 3");
                    }
                }
            }
            else if (userChoice == 5) //Go Back
            {
                Console.Clear();
                Console.WriteLine("Returning to Room Menu.");
                break;
            }
        }
    }
}