namespace SharpCalculator.Tests;

public class FunctionTests
{
    public const int PRECISION = 8;
    
    public FunctionTests()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    }

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    [InlineData(Math.PI/4)]
    [InlineData(Math.PI/2)]
    [InlineData(Math.PI*3/4)]
    [InlineData(Math.PI*2)]
    [InlineData(999)]
    [InlineData(-999)]
    public void Sin(double a) => 
        Assert.Equal(Math.Sin(a), Calculator.Calculate($"sin({a})"), PRECISION);

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    [InlineData(Math.PI/4)]
    [InlineData(Math.PI/2)]
    [InlineData(Math.PI*3/4)]
    [InlineData(Math.PI*2)]
    [InlineData(999)]
    [InlineData(-999)]
    public void Cos(double a) => 
        Assert.Equal(Math.Cos(a), Calculator.Calculate($"cos({a})"), PRECISION);

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    [InlineData(Math.PI/4)]
    [InlineData(Math.PI/1.99)]
    [InlineData(Math.PI*3/4)]
    [InlineData(Math.PI*1.99)]
    [InlineData(999)]
    [InlineData(-999)]
    public void Tan(double a) => 
        Assert.Equal(Math.Tan(a), Calculator.Calculate($"tan({a})"), PRECISION);

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    [InlineData(Math.PI/4)]
    [InlineData(Math.PI/2)]
    [InlineData(Math.PI*3/4)]
    [InlineData(Math.PI*1.99)]
    [InlineData(999)]
    [InlineData(-999)]
    public void Ctg(double a) => 
        Assert.Equal(1 / Math.Tan(a), Calculator.Calculate($"ctg({a})"), PRECISION);

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Asin(double a) => 
        Assert.Equal( Math.Asin(a), Calculator.Calculate($"asin({a})"), PRECISION);

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Acos(double a) => 
        Assert.Equal( Math.Acos(a), Calculator.Calculate($"acos({a})"), PRECISION);

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Atan(double a) => 
        Assert.Equal( Math.Atan(a), Calculator.Calculate($"atan({a})"), PRECISION);

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Actg(double a) => 
        Assert.Equal( Math.Atan(1 / a), Calculator.Calculate($"actg({a})"), PRECISION);

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Ln(double a) => 
        Assert.Equal( Math.Log(a), Calculator.Calculate($"ln({a})"), PRECISION);
}