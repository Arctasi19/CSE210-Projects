public class CheckListGoal : Goal
{
    private int _goalBonusPoints;
    private int _timesCompleted;
    private int _targetAmount;
    private bool _isComplete;
    public CheckListGoal(string name, string description, int value, int target, int bonus) : base(name, description, value)
    {
        _targetAmount = target;
        _goalBonusPoints = bonus;
    }
    public CheckListGoal(string name, string description, int value, int target, int bonus, int timesCompleted, bool isComplete) : base(name, description, value)
    {
        _targetAmount = target;
        _goalBonusPoints = bonus;
        _timesCompleted = timesCompleted;
        _isComplete = isComplete;
    }
    public override int RecordEvent()
    {
        _timesCompleted += 1;
        if (_timesCompleted == _targetAmount)
        {
            IsComplete();
            return _goalValue + _goalBonusPoints;
        } 
        else
        {
            return _goalValue;
        }
    }
    public override void IsComplete()
    {
        _isComplete = true;
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_goalName}|{_goalDescription}|{_goalValue}|{_isComplete}|{_goalBonusPoints}|{_timesCompleted}|{_targetAmount}";
    }
    public override string Display()
    {
        return $"{_goalName} ({_goalDescription}) -- Currently completed: {_timesCompleted}/{_targetAmount}";
    }
    public override bool CheckComplete()
    {
        return _isComplete;
    }
}