public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public override int RecordEvent()
    {
        _count++;

        if (_count == _target)
            return _points + _bonus;

        return _points;
    }

    public override bool IsComplete()
        => _count >= _target;

    public override string GetStatus()
        => $"[{(_count >= _target ? "X" : " ")}] {_count}/{_target}";

    public override string GetSaveString()
        => $"Checklist|{_name}|{_description}|{_points}|{_count}|{_target}|{_bonus}";
}