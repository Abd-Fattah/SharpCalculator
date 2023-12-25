namespace SharpCalculator.Tests;

public class ComplicatedExpressionTests
{
    public ComplicatedExpressionTests()
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    }

    [Theory]
    [InlineData(0.9,2,3)]
    public void Expression1(double a, double b, double c) => 
        Assert.Equal( a/(b+c), Calculator.Calculate($"({a})/(({b})+({c}))"));

    [Theory]
    [InlineData(0.9,2,3)]
    public void Expression2(double a, double b, double c) => 
        Assert.Equal( Math.Sin(a)-b*Math.Cos(c), Calculator.Calculate($"sin(({a}))-(({b})*cos(({c})))"));

    [Theory]
    [InlineData(0.9,2,3)]
    public void Expression3(double a, double b, double c) => 
        Assert.Equal( a*Math.Pow(b,c)+a*Math.Pow(b,c+1)+a*Math.Pow(b,c+2), Calculator.Calculate($"({a})*({b})^({c}) + ({a})*({b})^({c+1}) + ({a})*({b})^({c+2})"));

    [Theory]
    [InlineData(0.9,2,3)]
    public void Expression4(double a, double b, double c) => 
        Assert.Equal(a/(b+Math.Tan(c)), Calculator.Calculate($"({a})/(({b})+tan(({c})))"));
}