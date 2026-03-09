public class SimpleGoal : Goal
{
    private bool _isComplete = false;
    public SimpleGoal(string name, string description, int value) : base(name, description, value)
    {
        
    }
    public SimpleGoal(string name, string description, int value, bool isComplete) : base(name, description, value)
    {
        _isComplete = isComplete;
    }
    public override int RecordEvent()
    {
        IsComplete();
        return _goalValue;
    }
    public override void IsComplete()
    {
        _isComplete = true;
    }
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_goalName}|{_goalDescription}|{_goalValue}|{_isComplete}";
    }
    public override string Display()
    {
        return $"{_goalName} ({_goalDescription})";
    }
    public override bool CheckComplete()
    {
        return _isComplete;
    }
}