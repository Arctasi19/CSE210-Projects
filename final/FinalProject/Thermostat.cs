public class Thermostat : Device //INCOMPLETE
{
    private int _currentTemp;
    private int _desiredTemp;
    public Thermostat(string name, string desc) : base(name, desc)
    {
        
    }
    public Thermostat(string name, string desc, bool active, int current) : base(name, desc, active)
    {
        _currentTemp = current;
    }
    public void SetTemp(int desired)
    {
        _desiredTemp = desired;
    }
    public override string GetStatus()
    {
        string status = _isActive? "ON" : "OFF";
        return $"{_deviceName}" + status + $"Current Temperature: {_currentTemp}";
    }
    public override string GetStringRepresentation()
    {
        return $"Thermostat|{_deviceName}|{_deviceDesc}|{_isActive}|{_currentTemp}";
    }
    public override void DeviceUI()
    {
        Console.Clear();
        int userChoice = -1;
        while (userChoice != 8)
        {
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
                Console.WriteLine(GetStatus());
            }
            else if (userChoice == 2) //Turn On
            {
                ActiveOn();
            }
            else if (userChoice == 3) //Turn Off
            {
                ActiveOff();
            }
            else if (userChoice == 4) //Set Temp
            {
                while (true)
                {
                    int temp = GetInt("What temperature would you like this Thermostat to be?");
                    SetTemp(temp);
                }
            }
            else if (userChoice == 5) //Go Back
            {
                break;
            }
        }
    }
}