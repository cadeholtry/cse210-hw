using System.ComponentModel;
using System.Formats.Asn1;

public class ListingActivity : Activity {
    private readonly List<string> _prompts;
    private readonly List<string> _answers;
    public ListingActivity (string name, string description, int duration, List<string> prompts, List<string> answers) : base (name, description, duration) {
        _name = name;
        _description = description;
        _duration = duration;
        _prompts = prompts;
        _answers = answers;
    }
    public void AddAnswer() {
        Console.Write("> ");
        string answer = Console.ReadLine();
        _answers.Add(answer);
    }
    public int GeneratePrompt() {
        var random = new Random();
        int index = random.Next(_prompts.Count);
        return index;
    }
    public void StartListing() {
        Console.Clear();
        Console.WriteLine("Get ready....");
        Pause();
        Console.WriteLine("");
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[GeneratePrompt()]} ---");
        int timer = 5;
        Console.Write("You may begin in: ");
        while (timer > 0) {
            Console.Write($"{timer}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            timer -= 1;
        }
        Console.WriteLine("");
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        Thread.Sleep(500);
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime) {
            AddAnswer();
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"\nYou listed {_answers.Count} items!\n");
    }
}