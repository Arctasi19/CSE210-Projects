public class Speaker : Device //INCOMPLETE
{
    private int _volume;
    public Speaker(string name, string desc) : base(name, desc)
    {
        
    }
    public Speaker(string name, string desc, bool active, int volume) : base(name, desc, active)
    {
        _volume = volume;
    }
    public void SetVolume(int vol)
    {
        _volume = vol;
    }
    public override string GetStatus()
    {
        string status = _isActive? "ON" : "OFF";
        return $"{_deviceName} " + status + $" Current Set Volume: {_volume}";
    }
    public override string GetStringRepresentation()
    {
        return $"Speaker|{_deviceName}|{_deviceDesc}|{_isActive}|{_volume}";
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
            Console.WriteLine("4. Set Desired Volume");
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
            else if (userChoice == 4) //Set Volume
            {
                while (true)
                {
                    int volume = GetInt("What volume would you like to set this speaker to? ");
                    if (volume <= 100 && volume>= 1)
                    {
                        SetVolume(volume);
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid volume % between 1 and 100");
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