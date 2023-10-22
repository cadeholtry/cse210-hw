using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Word {
    private string _word;
    private bool _isVisible;
    public Word(string word, bool isVisible) {
        _word = word;
        _isVisible = isVisible;
    }
    public string GetWord() {
        StringBuilder invisWord = new StringBuilder();
        if (_isVisible == false) {
            for (int i = 0; i < _word.Length; i++) {
                invisWord.Append("_");
            }
            _word = invisWord.ToString();
            return _word;
        }
        else {
            return _word;
        }
    }
    public bool GetVisible() {
        return _isVisible;
    }
    public void SetVisiblity(bool isVisible) {
        _isVisible = isVisible;
    }
}