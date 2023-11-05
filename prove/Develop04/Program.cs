using System;

class Program
{
    static void Main(string[] args)
    {
        int option = 0;
        int total = 0;
        int totalBA = 0;
        int totalRA = 0;
        int totalLA = 0;
        while (option < 5) {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. How Many Activities Have I Done?");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            option = int.Parse(Console.ReadLine());
            if (option == 1) {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", 0);
                breathingActivity.DisplayStart();
                breathingActivity.SetDuration();
                breathingActivity.StartBreathing();
                breathingActivity.DisplayEnd();
                totalBA += 1;
                total += 1;
            }
            else if (option == 2) {
                var prompts = new List<string> {
                    "Think of a time when you stood up for someone else.",
                    "Think of a time when you did something really difficult.",
                    "Think of a time when you helped someone in need.",
                    "Think of a time when you did something truly selfless."
                };
                var questions = new List<string> {
                    "Why was this experience meaningful to you?",
                    "Have you ever done anything like this before?",
                    "How did you get started?",
                    "How did you feel when it was complete?",
                    "What made this time different than other times when you were not as successful?",
                    "What is your favorite thing about this experience?",
                    "What could you learn from this experience that applies to other situations?",
                    "What did you learn about yourself through this experience?",
                    "How can you keep this experience in mind in the future?",
                };
                ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 0, prompts, questions);
                reflectionActivity.DisplayStart();
                reflectionActivity.SetDuration();
                reflectionActivity.StartReflection();
                reflectionActivity.DisplayEnd();
                totalRA += 1;
                total += 1;
            }
            else if (option == 3) {
                var prompts = new List<string> {
                    "Who are people that you appreciate?",
                    "What are personal strengths of yours?",
                    "Who are people that you have helped this week?",
                    "When have you felt the Holy Ghost this month?",
                    "Who are some of your personal heroes?"
                };
                var answers = new List<string> {};
                ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0, prompts, answers);
                listingActivity.DisplayStart();
                listingActivity.SetDuration();
                listingActivity.StartListing();
                listingActivity.DisplayEnd();
                totalLA += 1;
                total += 1;
            }
            else if (option == 4) {
                Console.Clear();
                Console.WriteLine($"You have completed {total} activities! \nThese include:");
                Console.WriteLine($"{totalBA} Breathing Activities");
                Console.WriteLine($"{totalRA} Reflection Activities");
                Console.WriteLine($"{totalLA} Listing Activities");
                Console.WriteLine("\nTo return to the home menu, please hit enter.");
                string userInput = Console.ReadLine();
                if (userInput == "") {
                    Console.Clear();
                }
            }
        }
    }
}