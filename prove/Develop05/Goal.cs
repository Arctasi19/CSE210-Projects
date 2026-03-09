public abstract class Goal
{
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalValue;
    public Goal(string name, string description, int points)
    {
        _goalName = name;
        _goalDescription = description;
        _goalValue = points;
    }
    public abstract void IsComplete();
    public abstract int RecordEvent();
    public abstract string GetStringRepresentation();
    public abstract string Display();
    public abstract bool CheckComplete();
    public virtual string GetName()
    {
        return $"{_goalName}";
    }
}