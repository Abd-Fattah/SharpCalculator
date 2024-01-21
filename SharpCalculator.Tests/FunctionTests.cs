namespace SharpCalculator.Tests;

public class FunctionTests
{
    public FunctionTests()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    }

    [Theory]
    [InlineData(5)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Sin(double a) => 
        Assert.Equal(Math.Sin(a), Calculator.Calculate($"sin({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Cos(double a) => 
        Assert.Equal(Math.Cos(a), Calculator.Calculate($"cos({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Tan(double a) => 
        Assert.Equal(Math.Tan(a), Calculator.Calculate($"tan({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Ctg(double a) => 
        Assert.Equal(1 / Math.Tan(a), Calculator.Calculate($"ctg({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Asin(double a) => 
        Assert.Equal( Math.Asin(a), Calculator.Calculate($"asin({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Acos(double a) => 
        Assert.Equal( Math.Acos(a), Calculator.Calculate($"acos({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Atan(double a) => 
        Assert.Equal( Math.Atan(a), Calculator.Calculate($"atan({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Actg(double a) => 
        Assert.Equal( Math.Atan(1 / a), Calculator.Calculate($"actg({a})"));

    [Theory]
    [InlineData(0.9)]
    [InlineData(1)]
    [InlineData(-3)]
    [InlineData(-2)]
    public void Ln(double a) => 
        Assert.Equal( Math.Log(a), Calculator.Calculate($"ln({a})"));
}