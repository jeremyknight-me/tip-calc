using JK.TipCalc.Common.Models;

namespace JK.TipCalc.Common.Tests.Models;

public class PercentTests
{
    [Theory]
    [InlineData(0, null)]
    [InlineData(0, "")]
    [InlineData(0, " ")]
    [InlineData(0, "1.1")]
    [InlineData(0, "0")]
    [InlineData(1, "1")]
    [InlineData(100, "100")]
    public void SetValue_String_Theories(int expected, string value)
    {
        var sut = Percent.Create(0);
        sut.SetValue(value);
        Assert.Equal(expected, sut.Value);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(100, 100)]
    public void SetValue_Int_Theories(int expected, int value)
    {
        var sut = Percent.Create(0);
        sut.SetValue(value);
        Assert.Equal(expected, sut.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void SetValue_Int_OutOfRangeException_Theories(int value)
    {
        var sut = Percent.Create(0);
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => sut.SetValue(value));
    }
}
