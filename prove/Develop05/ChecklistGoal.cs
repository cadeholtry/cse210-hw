public class ChecklistGoal : Goal {
    private int _bonusPoints;
    private int _totalRepetition;
    private int _numberRepetition;
    public ChecklistGoal (string type, string name, string description, int points, bool completed, int bonusPoints, int totalRepetition, int numberRepetition) : base(type, name, description, points, completed) {
        _type = type;
        _name = name;
        _description = description;
        _points = points;
        _completed = completed;
        _bonusPoints = bonusPoints;
        _totalRepetition = totalRepetition;
        _numberRepetition = numberRepetition; 
    }
    public override string WriteOutGoal()
    {
        string reference = "";
        if (_completed == false) {
            reference = $"[ ] {_name} ({_description}) -- Currently completed: {_numberRepetition}/{_totalRepetition}";
        }
        else {
            reference = $"[X] {_name} ({_description}) -- Currently completed: {_numberRepetition}/{_totalRepetition}";
        }
        return reference;
    }
    public override string GenerateStorageInfo()
    {
        string info = $"{_type},{_name},{_description},{_points},{_completed},{_bonusPoints},{_totalRepetition},{_numberRepetition}";
        return info;
    }
    public override void SetComplete()
    {
        if (_numberRepetition == _totalRepetition) {
            _completed = true;
        }
        else {
            _numberRepetition += 1;
        }
    }
    public override int GetPoints()
    {
        if (_numberRepetition < _totalRepetition) {
            return _points;
        }
        else {
            return _bonusPoints;
        }
    }
}