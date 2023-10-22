public class Reference {
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse;
    public Reference(string book, int chapter, int verse) {
        _book = book;
        _chapter = chapter;
        _firstVerse = verse;
        _lastVerse = 0;
    }
    public Reference(string book, int chapter, int firstVerse, int lastVerse) {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }
    public string GetReference() {
        string reference = "";
        if (_lastVerse == 0) {
            reference = $"{_book} {_chapter}:{_firstVerse}";
            return reference;
        }
        else {
            reference = $"{_book} {_chapter}:{_firstVerse}-{_lastVerse}";
            return reference;
        }
    }
}