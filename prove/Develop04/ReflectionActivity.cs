public class ReflectionActivity : Activity {
    private readonly List<string> _prompts;
    private readonly List<string> _questions;
    public ReflectionActivity (string name, string description, int duration, List<string> prompts, List<string> questions) : base(name, description, duration) {
        _name = name;
        _description = description;
        _duration = duration;
        _prompts = prompts;
        _questions = questions;
    }
    public int GeneratePrompt() {
        var random = new Random();
        int index = random.Next(_prompts.Count);
        return index;
    }
    public int GenerateQuestion() {
        var random = new Random();
        int index = random.Next(_questions.Count);
        return index;
    }
    public void StartReflection() {
        Console.Clear();
        Console.WriteLine("Get ready....");
        Pause();
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {_prompts[GeneratePrompt()]} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        string inMind = Console.ReadLine();
        if (inMind == "") {
            int timer = 5;
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            while (timer > 0) {
                Console.Write($"{timer}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                timer -= 1;
            }
            Console.Clear();
            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(_duration);
            Thread.Sleep(500);
            DateTime currentTime = DateTime.Now;
            while (currentTime < futureTime) {
                Console.WriteLine($"> {_questions[GenerateQuestion()]}");
                Pause();
                currentTime = DateTime.Now;
            }
            Console.WriteLine("");
        }
    }
}