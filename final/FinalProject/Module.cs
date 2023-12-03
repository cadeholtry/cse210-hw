using System.Reflection.Emit;

public abstract class Module {
    protected int _xValue;
    protected int _yValue;
    protected string _type;
    protected bool _clicked;
    protected int _numCheck;
    public Module (int x, int y, string type, bool clicked, int numCheck) {
        _xValue = x;
        _yValue = y;
        _type = type;
        _clicked = clicked;
        _numCheck = numCheck;
    }
    public abstract void OnClick();
    public abstract string GetInformation();
    public abstract string DisplayModule();
    public abstract int GetXValue();
    public abstract int GetYValue();
    public abstract bool GetClicked();
    public abstract string GetModuleType();
    public virtual void SetNumCheck(int check) {
        _numCheck = check;
    }
}