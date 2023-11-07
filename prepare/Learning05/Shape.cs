public abstract class Shape {
    private string _color;
    public string GetColor() {
        string color = _color;
        return color;
    }
    public void SetColor(string color) {
        _color = color;
    }
    public Shape (string color) {
        _color = color;
    }
    public abstract double GetArea();
}