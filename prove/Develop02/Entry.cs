using System.Data;
using Microsoft.VisualBasic;

public class Entry {
    public string _date;
    public string _entry;
    public int _index;
    public List<Prompts> _prompts = new List<Prompts>();
    public void GeneratePrompt() {
        _prompts[_index].DisplayPrompt();
    }
    public string GenerateEntry() {
        // Don't ask me why I did this like this... I just needed it to work lol
        var prompts = new List<string> {
            "What did you eat today?",
            "Who did you talk to today?",
            "What did you do for your missionary work today?",
            "Did you have any ideas for decks?",
            "Did you talk to Brittan today? What did you talk about?"
        };
        var currentEntry = $"{_date} - Prompt: {prompts[_index]} - Entry: {_entry}";
        return currentEntry;
    }  
}