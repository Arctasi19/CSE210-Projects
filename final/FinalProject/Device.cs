public abstract class Device 
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