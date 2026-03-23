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
    public virtual void ToggleActive()
    {
        
    }
    public abstract string GetStatus();
    public virtual string GetInfo()
    {
        return $"{_deviceName}: {_deviceDesc}";
    }
    public abstract string GetStringRepresentation();
}