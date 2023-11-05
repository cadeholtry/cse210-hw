using System.IO.Compression;
using System.Threading.Tasks.Dataflow;

public class Activity {
    protected string _name;
    protected string _description;
    protected int _duration;
    public Activity (string name, string description, int duration) {
        _name = name;
        _description = description;
        _duration = duration;
    }
    public void SetDuration() {
        Console.WriteLine("How long in seconds, would you like for your session?");
        Console.Write("> ");
        string userInput = Console.ReadLine();
        _duration = int.Parse(userInput);
    }
    public void DisplayStart() {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine("");
        Console.WriteLine($"{_description}");
        Console.WriteLine("");
    }
    public void Pause() {
        int timer = 0;
        while (timer < 5) {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            timer += 1;
        }
        Console.Write("\b \b");
    }
    public void DisplayEnd() {
        Console.WriteLine("Well Done!");
        Pause();
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}\n");
        Pause();
        Console.Clear();
    }
}