public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int value) : base(name, description, value)
    {
        
    }
    public override int RecordEvent()
    {
        return _goalValue;
    }
    public override void IsComplete()
    {

    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_goalName}|{_goalDescription}|{_goalValue}";
    }
    public override string Display()
    {
        return $"{_goalName} ({_goalDescription})";
    }
    public override bool CheckComplete()
    {
        return false;
    }
}