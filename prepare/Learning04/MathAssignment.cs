public class MathAssignment : Assignment {
    private string _textbookSection;
    private string _problems;
    public MathAssignment(string name, string topic, string section, string problems) : base(name, topic) {
        _problems = problems;
        _textbookSection = section;
    }
    public string GetHomeworkList() {
        string homeworkList = $"Section {_textbookSection} Problems {_problems}";
        return homeworkList;
    }
}