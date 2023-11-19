using System.Runtime.CompilerServices;

public class EternalGoal : Goal {
    public EternalGoal (string type, string name, string description, int points, bool completed) : base(type, name, description, points, completed) {
        _type = type;
        _name = name;
        _description = description;
        _points = points;
        _completed = completed;
    }
    public override string WriteOutGoal()
    {
        string reference = "";
        if (_completed == false) {
            reference = $"[ ] {_name} ({_description})";
        }
        else {
            reference = $"[X] {_name} ({_description})";
        }
        return reference;
    }
    public override string GenerateStorageInfo()
    {
        string info = $"{_type},{_name},{_description},{_points},{_completed}";
        return info;
    }
}