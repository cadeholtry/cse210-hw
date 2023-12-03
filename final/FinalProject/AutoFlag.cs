public class AutoFlag : PowerUp {

    public AutoFlag (int x, int y, string type, bool clicked, string pType, int numCheck = 0) : base (x,y,type, clicked, pType, numCheck) {
        _xValue = x;
        _yValue =  y;
        _type = type;
        _clicked = clicked;
        _powerType = pType;
    }
    public override void OnClick()
    {
        _clicked = true;
    }
    public override string GetInformation()
    {
        string info = $"{_xValue},{_yValue},{_type},{_clicked},{_powerType}";
        return info;
    }
    public override string DisplayModule()
    {
        if (_clicked == true) {
            return "%";
        }
        else {
            return "-";
        }
    }
    public override int GetXValue()
    {
        int xValue = _xValue;
        return xValue;
    }
    public override int GetYValue()
    {
        int yValue = _yValue;
        return yValue;
    }
    public override bool GetClicked() {
        bool clicked = _clicked;
        return clicked;
    }
    public override string GetModuleType()
    {
        string type = _type;
        return type;
    }
    public override void SetNumCheck(int check) {
        _numCheck = check;
    }
}