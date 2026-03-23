public class Thermostat : Device //INCOMPLETE
{
    private int _currentTemp;
    private int _desiredTemp;
    public Thermostat(string name, string desc, bool active) : base(name, desc, active)
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
        return $"SmartLight|{_deviceName}|{_deviceDesc}|{_isActive}|{_currentTemp}";
    }
}