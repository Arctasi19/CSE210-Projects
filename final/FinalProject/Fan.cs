public class Fan : Device //INCOMPLETE
{
    private int _speed;
    public Fan(string name, string desc, bool active) : base(name, desc, active)
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
        return $"{_deviceName}" + status + $"Current Set Speed: {_speed}";
    }
    public override string GetStringRepresentation()
    {
        return $"SmartLight|{_deviceName}|{_deviceDesc}|{_isActive}|{_speed}";
    }
}