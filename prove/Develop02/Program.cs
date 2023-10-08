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
                // Generating prompts
                
                string prompt1 = "What did you eat today?";
                string prompt2 = "Who did you talk to today?";
                string prompt3 = "What did you do for your missionary work today?";
                string prompt4 = "Did you have any ideas for decks?";
                string prompt5 = "Did you talk to Brittan today? What did you talk about?";
                
                // Getting an Entry
                Entry entry = new Entry();
                entry._prompts.Add(prompt1);
                entry._prompts.Add(prompt2);
                entry._prompts.Add(prompt3);
                entry._prompts.Add(prompt4);
                entry._prompts.Add(prompt5);
                var currentPrompt = entry.GeneratePrompt();
                Console.WriteLine($"{currentPrompt}");
                Console.Write("> ");
                entry._entry = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;

                // Writing to a Journal
                Journal newJournal = new Journal();
                newJournal._date = theCurrentTime.ToShortDateString();
                newJournal._currentPrompt = currentPrompt;
                newJournal._currentEntry = entry._entry;
                newJournal.StoreJournalEntry();
            }
            else if (number == 2) {
                Journal displayJournal = new Journal();
                displayJournal.DisplayJournal();
            }
            else if (number == 3) {
                Journal loadJournal = new Journal();
                loadJournal.LoadOldJournal();
            }
            else if (number == 4) {
                Journal saveJournal = new Journal();
                saveJournal.SaveJournal();
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