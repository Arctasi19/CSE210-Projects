public abstract class Device //INCOMPLETE
{
    protected string _deviceName;
    protected string _deviceDesc;
    protected bool _isActive = false;
    public Device(string name, string desc)
    {
        _deviceName = name;
        _deviceDesc = desc;
    }
    public Device(string name, string desc, bool activity)
    {
        _deviceName = name;
        _deviceDesc = desc;
        _isActive = activity;
    }
    public virtual void ActiveOn()
    {
        _isActive = true;
    }
    public virtual void ActiveOff()
    {
        _isActive = false;
    }
    public abstract string GetStatus();
    public virtual string GetInfo()
    {
        return $"{_deviceName}: {_deviceDesc}";
    }
    public abstract string GetStringRepresentation();
    public abstract void DeviceUI();
    public int GetInt(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        int userInput = int.Parse(Console.ReadLine());
        return userInput;
    }
    public string GetStr(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        string userInput = Console.ReadLine();
        return userInput;
    }
}