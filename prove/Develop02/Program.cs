using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Cade's personal digital journal!");
        int quit = 0;
        while (quit == 0) {
            Console.WriteLine("What would you like to do? Please type a number.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("> ");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);
            if (number == 1) {
                // Generating prompts in a really backwards way this was the best I could do
                Prompts prompt1 = new Prompts();
                prompt1._prompt = "What did you eat today?";
                Prompts prompt2 = new Prompts();
                prompt2._prompt = "Who did you talk to today?";
                Prompts prompt3 = new Prompts();
                prompt3._prompt = "What did you do for your missionary work today?";
                Prompts prompt4 = new Prompts();
                prompt4._prompt = "Did you have any ideas for decks?";
                Prompts prompt5 = new Prompts();
                prompt5._prompt = "Did you talk to Brittan today? What did you talk about?";
                
                // Getting an Entry and saving it to a text file
                Entry entry = new Entry();
                entry._prompts.Add(prompt1);
                entry._prompts.Add(prompt2);
                entry._prompts.Add(prompt3);
                entry._prompts.Add(prompt4);
                entry._prompts.Add(prompt5);
                var random = new Random();
                entry._index = random.Next(entry._prompts.Count);
                entry.GeneratePrompt();
                Console.Write("> ");
                entry._entry = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;
                entry._date = theCurrentTime.ToShortDateString();
                string currentEntry = entry.GenerateEntry();
                string unsaved = "Current Journal.txt";
                using (StreamWriter outputFile = new StreamWriter(unsaved, true)){
                    outputFile.WriteLine(currentEntry);
                    outputFile.WriteLine("");
                }
            }
            else if (number == 2) {
                string fileName = "Current Journal.txt";
                string[] lines = System.IO.File.ReadAllLines(fileName);
                foreach (string line in lines) {
                    Console.WriteLine(line);
                }
            }
            else if (number == 3) {
                Console.WriteLine("Please select a file to load from:");
                Console.Write("> ");
                string loadFile = Console.ReadLine();
                string unsaved = "Current Journal.txt";
                string[] oldEntries = System.IO.File.ReadAllLines(loadFile);
                using (StreamWriter outputFile = new StreamWriter(unsaved)){
                    outputFile.WriteLine("");
                }
                foreach (string line in oldEntries) {
                    using (StreamWriter outputFile = new StreamWriter(unsaved, true)){
                    outputFile.WriteLine(line);
                    }
                }
                using (StreamWriter outputFile = new StreamWriter(unsaved)){
                    outputFile.WriteLine("");
                }
            }
            else if (number == 4) {
                Console.WriteLine("Please select a file to save to:");
                Console.Write("> ");
                string saveFile = Console.ReadLine();
                string unsaved = "Current Journal.txt";
                string[] newEntries = System.IO.File.ReadAllLines(unsaved);
                foreach (string line in newEntries) {
                    using (StreamWriter outputFile = new StreamWriter(saveFile, true)){
                    outputFile.WriteLine(line);
                    }
                }
            }
            else if (number == 5) {
                Console.WriteLine("Thank you for using this journal! See you soon!");
                string unsaved = "Current Journal.txt";
                using (StreamWriter outputFile = new StreamWriter(unsaved)){
                    outputFile.WriteLine("");
                }
                quit = 1;
            }
        }
    }
}