using JK.TipCalc.Common.Models;

namespace JK.TipCalc.Tests.Models
{
    public class TipCalculationTests
    {
        [Theory]
        [InlineData(10.0, 0, 20, 2.0)]
        [InlineData(100.0, 0, 20, 20.0)]
        [InlineData(50.0, 50.0, 20, 20.0)]
        public void Tip_Theories(decimal amount, decimal discount, int percent, decimal expected)
        {
            var sut = new TipCalculation
            {
                Amount = amount,
                Discount = discount,
                Percent = percent
            };
            var actual = sut.Tip;
            Assert.Equal(expected, actual);
        }
    }
}
