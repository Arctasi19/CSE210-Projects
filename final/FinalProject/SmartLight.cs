public class SmartLight : Device, IDimmable, IColorChangeable //INCOMPLETE
{
    private bool _canDim;
    private bool _canChangeColor;
    private int _brightness = 0;
    private string _color = "white";
    private List<String> colorsOptions = ["red", "green", "blue","white"];
    public SmartLight(string name, string desc, bool canDim, bool canChangeColor) : base(name, desc)
    {
        _canChangeColor = canChangeColor;
        _canDim = canDim;
    }
    public SmartLight(string name, string desc, bool active, bool canDim, bool canChangeColor, int brightness, string color) : base(name, desc, active)
    {
        _canChangeColor = canChangeColor;
        _canDim = canDim;
        _brightness = brightness;
        _color = color;
    }
    public void SetBrightness(int level)
    {
        if (_canDim)
        {
            _brightness = level;
            Console.WriteLine($"{_deviceName} brightness set to {_brightness}");
        }
        else
        {
            Console.WriteLine($"Error: This device does not support dimming");
        }
    }
    public void SetColor(string color)
    {
        if (_canChangeColor)
        {
            _color = color;
            Console.WriteLine($"{_deviceName} color set to {_color}");
        }
        else
        {
            Console.WriteLine($"Error: This device does not support color changing");
        }
    }
    public override string GetStatus() 
    {
        string status = _isActive? "ON" : "OFF";
        if (_canDim)
        {
            status += $" (Brightness: {_brightness}%)";
        }
        if (_canChangeColor)
        {
            status += $" [Color: {_color}]";
        }
        return $"{_deviceName} " + status;
    }
    public override string GetInfo()
    {
        string info = $"{_deviceName}: {_deviceDesc} ";
        if (_canDim)
        {
            info += "| Dimmable ";
        }
        if (_canChangeColor)
        {
            info += "| Color Changeable ";
        }
        return info;
    }
    public override string GetStringRepresentation()
    {
        return $"SmartLight|{_deviceName}|{_deviceDesc}|{_isActive}|{_canDim}|{_canChangeColor}|{_brightness}|{_color}";
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
            if (_canChangeColor == true)
            {
                Console.WriteLine("4. Set Color");
            }
            if (_canDim == true)
            {
                Console.WriteLine("5. Set Brightness");
            }
            Console.WriteLine("6. Go Back To Room Menu");

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
            else if (userChoice == 4 && _canChangeColor == true) //Set Color
            {

                while (true)
                {
                    string color = GetStr("What color (red, green, blue, white) would you like to set this light to? ");
                    if (colorsOptions.Contains(color.ToLower()))
                    {
                        SetColor(color);
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter red, green, blue, or white");
                    }
                }
            }
            else if (userChoice == 5 && _canDim == true) //Set Brightness
            {
                while (true)
                {
                    int luminosity = GetInt("What brightness level would you like to set this light to? ");
                    if (luminosity <= 100 && luminosity>= 1)
                    {
                        SetBrightness(luminosity);
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid brightness % between 1 and 100");
                    }
                }
            }
            else if (userChoice == 6) //Go Back
            {
                Console.Clear();
                Console.WriteLine("Returning to Room Menu.");
                break;
            }
        }
    }
}