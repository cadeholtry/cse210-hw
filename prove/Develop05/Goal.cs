using System.IO.Compression;

public abstract class Goal {
    protected string _type;
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _completed;
    public Goal (string type, string name, string description, int points, bool completed) {
        _type = type;
        _name = name;
        _description = description;
        _points = points;
        _completed = completed;
    }
    public virtual int GetPoints() {
        int points = _points;
        return points;
    }
    public string GetName() {
        string name = _name;
        return name;
    }
    public abstract string WriteOutGoal();
    public abstract string GenerateStorageInfo();
    public virtual void SetComplete() {
        _completed = true;
    }
}