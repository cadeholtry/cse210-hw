using System.Data;
using Microsoft.VisualBasic;
public class Scripture {
    private List<Word> _words = new List<Word>();
    private Reference _reference;
    private string _scripture;
    public Scripture(Reference reference, string scripture) {
        _reference = reference;
        _scripture = scripture;
        string[] words = _scripture.Split(" ");
        foreach (string word in words) {
            Word newWord = new Word(word, true);
            _words.Add(newWord);
        }
    }
    public void HideWords() {
        var random = new Random();
        foreach (Word word in _words) {
            if (word.GetVisible() == true) {
                int chance = random.Next(3);
                if (chance == 2) {
                    word.SetVisiblity(false);
                }
            }
        }
    }
    public void DisplayScripture() {
        Console.Clear();
        Console.Write($"{_reference.GetReference()}: ");
        foreach (Word word in _words) {
            string finalWord = word.GetWord();
            Console.Write($"{finalWord} ");
        }
        Console.WriteLine(" ");
    }
    public void FinalCheck() {
        int check = 1;
        foreach (Word word in _words) {
            if (word.GetVisible() == true) {
                check = 0;
            }
        }
        if (check == 1) {
            Console.WriteLine("No more words to hide!");
            Environment.Exit(0);
        }
    }
}