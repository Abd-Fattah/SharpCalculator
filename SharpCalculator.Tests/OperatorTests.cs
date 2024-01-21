namespace SharpCalculator.Tests;

public class OperatorTests
{
    public OperatorTests()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    }

    [Theory]
    [InlineData(15,5)]
    [InlineData(13,-6)]
    [InlineData(-1,-6)]
    [InlineData(-13,6)]
    public void Sum(double a,double b) => 
        Assert.Equal(a+b, Calculator.Calculate($"({a})+({b})"));

    [Theory]
    [InlineData(15,5)]
    [InlineData(13,-6)]
    [InlineData(-1,-6)]
    [InlineData(-13,6)]
    public void Subtract(double a,double b) => 
        Assert.Equal(a-b, Calculator.Calculate($"({a})-({b})"));

    [Theory]
    [InlineData(15,5)]
    [InlineData(13,-6)]
    [InlineData(-1,-6)]
    [InlineData(-13,6)]
    public void Multiplying(double a,double b) => 
        Assert.Equal(a*b, Calculator.Calculate($"({a})*({b})"));

    [Theory]
    [InlineData(15,5)]
    [InlineData(24,-6)]
    [InlineData(-12,-6)]
    [InlineData(-36,6)]
    public void Dividing(double a,double b) => 
        Assert.Equal(a/b, Calculator.Calculate($"({a})/({b})"));
    
    [Theory]
    [InlineData(2,5)]
    [InlineData(1,-1)]
    [InlineData(-3,-4)]
    [InlineData(-2,2)]
    public void Power(double a,double b) => 
        Assert.Equal(Math.Pow(a,b), Calculator.Calculate($"({a})^({b})"));

    [Theory]
    [InlineData(5,2)]
    [InlineData(1,-1)]
    [InlineData(-3,-2)]
    [InlineData(-2,2)]
    public void Mod(double a,double b) => 
        Assert.Equal( a%b, Calculator.Calculate($"({a})%({b})"));
}