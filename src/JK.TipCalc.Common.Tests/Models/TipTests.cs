using JK.TipCalc.Common.Models;

namespace JK.TipCalc.Common.Tests.Models;

public class TipTests
{
    [Theory]
    [InlineData(2.0, 20, 10.0, 0)]
    [InlineData(20.0, 20, 100, 0)]
    [InlineData(20.0, 20, 50.0, 50.0)]
    public void SetMealValues_Theories(decimal expected, int percent, decimal amount, decimal discount)
    {
        var sut = Tip.Create(percent);
        sut.SetMealValues(amount, discount);
        Assert.Equal(expected, sut.TipAmount);
    }

    [Theory]
    [InlineData(0.3, 6.0, 5.70)]
    [InlineData(2.79, 18.0, 15.21)]
    public void RoundDown_Theories(decimal expectedTip, decimal expectedTotal, decimal amount)
    {
        var sut = Tip.Create(20);
        sut.SetMealValues(amount, 0);
        sut.RoundDown();
        Assert.Equal(expectedTip, sut.TipAmount);
        Assert.Equal(expectedTotal, sut.Total);
    }

    [Theory]
    [InlineData(1.3, 7.0, 5.70)]
    [InlineData(3.79, 19.0, 15.21)]
    public void RoundUp_Theories(decimal expectedTip, decimal expectedTotal, decimal amount)
    {
        var sut = Tip.Create(20);
        sut.SetMealValues(amount, 0);
        sut.RoundUp();
        Assert.Equal(expectedTip, sut.TipAmount);
        Assert.Equal(expectedTotal, sut.Total);
    }
}
