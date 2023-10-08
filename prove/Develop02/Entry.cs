using System.Data;
using Microsoft.VisualBasic;

public class Entry {
    public string _entry;
    public List<string> _prompts = new List<string>();
    public string GeneratePrompt() {
        var random = new Random();
        var promptIndex = random.Next(_prompts.Count);
        string currentPrompt = $"{_prompts[promptIndex]}";
        return currentPrompt;
    }
}