public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public int GetTop()
    {
        return _numerator;
    }
    public void SetTop(int topNumber)
    {
        _numerator = topNumber;
    }
    public int GetBottom()
    {
        return _denominator;
    }
    public void SetBottom(int bottomNumber)
    {
        _denominator = bottomNumber;
    }
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }
    public double GetDecimalValue()
    {
        return (double)_numerator / (double)_denominator;
    }
}