public class BreathingActivity : Activity {
    public BreathingActivity (string name, string description, int duration) : base(name, description, duration) {
        _name = name;
        _description = description;
        _duration = duration;
    }
    public void StartBreathing() {
        Console.Clear();
        Console.WriteLine("Get ready....");
        Pause();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        Thread.Sleep(500);
        DateTime currentTime = DateTime.Now;
        int timer = 0;
        while (currentTime < futureTime) {
            timer = 4;
            Console.Write("\nBreathe in... ");
            while (timer > 0) {
                Console.Write($"{timer}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                timer -= 1;
            }
            timer = 6;
            Console.Write("\nBreathe out... ");
            while (timer > 0) {
                Console.Write($"{timer}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
                timer -= 1;
            }
            Console.WriteLine("");
            currentTime = DateTime.Now;
        }
    }
}