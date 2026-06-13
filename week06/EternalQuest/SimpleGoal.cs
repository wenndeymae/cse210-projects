public class SimpleGoal : Goal
{
    private bool _complete = false;

    public SimpleGoal(string name, string desc, int points)
        : base(name, desc, points) { }

    public override int RecordEvent()
    {
        if (_complete) return 0;
        _complete = true;
        return _points;
    }

    public override bool IsComplete() => _complete;

    public override string GetStatus()
        => _complete ? "[X]" : "[ ]";

    public override string GetSaveString()
        => $"Simple|{_name}|{_description}|{_points}|{_complete}";
}