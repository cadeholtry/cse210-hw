using Microsoft.VisualBasic;
using System.Data;

public class Journal {
    public string _date;
    public string _currentEntry;
    public string _currentPrompt;
    public void StoreJournalEntry() {
        var entryToStore = $"{_date} - Prompt: {_currentPrompt} - Entry: {_currentEntry}";
        string unsaved = "Current Journal.txt";
        using (StreamWriter outputFile = new StreamWriter(unsaved, true)){
            outputFile.WriteLine(entryToStore);
            outputFile.WriteLine("");
        }
    }
    public void DisplayJournal() {
        string fileName = "Current Journal.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines) {
            Console.WriteLine(line);
        }
    }
    public void LoadOldJournal() {
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
        using (StreamWriter outputFile = new StreamWriter(unsaved, true)){
            outputFile.WriteLine("");
        }
    }
    public void SaveJournal() {
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
}