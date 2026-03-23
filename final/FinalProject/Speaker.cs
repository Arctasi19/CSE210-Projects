public class Speaker : Device //INCOMPLETE
{
    private int _volume;
    public Speaker(string name, string desc, bool active) : base(name, desc, active)
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
        return $"{_deviceName}" + status + $"Current Set Volume: {_volume}";
    }
    public override string GetStringRepresentation()
    {
        return $"SmartLight|{_deviceName}|{_deviceDesc}|{_isActive}|{_volume}";
    }
}