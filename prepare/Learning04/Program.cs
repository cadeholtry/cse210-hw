using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Cade Holtry", "CSE 210");
        string summary = assignment.GetSummary();
        Console.WriteLine(summary);
        MathAssignment mathAssignment = new MathAssignment("Cade Holtry", "Standard Deviation", "3", "4-8");
        summary = mathAssignment.GetSummary();
        string list = mathAssignment.GetHomeworkList();
        Console.WriteLine(summary);
        Console.WriteLine(list);
        WritingAssignment writingAssignment = new WritingAssignment("Cade Holtry", "Spellcasting", "Shadow Wizards and the Shadow Government");
        summary = writingAssignment.GetSummary();
        string title = writingAssignment.GetWritingInfo();
        Console.WriteLine(summary);
        Console.WriteLine(title);
    }
}