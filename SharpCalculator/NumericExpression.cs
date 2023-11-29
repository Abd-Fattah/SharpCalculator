namespace SharpCalculator;

public class NumericExpression : IExpression
{
    private double n;

    public NumericExpression(double n)
    {
        this.n = n;
    }

    public double Calculate() => n;
}