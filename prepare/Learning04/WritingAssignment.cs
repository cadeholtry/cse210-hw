using Microsoft.VisualBasic;

public class WritingAssignment : Assignment {
    private string _title;
    public WritingAssignment(string name, string topic, string title) : base(name, topic) {
        _title = title;
    }
    public string GetWritingInfo() {
        string info = $"{_title} by {_studentName}";
        return info;
    }
}