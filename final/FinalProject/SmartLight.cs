public class SmartLight : Device, IDimmable, IColorChangeable //INCOMPLETE
{
    private bool _canDim;
    private bool _canChangeColor;
    private int _brightness = 0;
    private string _color = "white";
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
        return $"{_deviceName}" + status;
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
}