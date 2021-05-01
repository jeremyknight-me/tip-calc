using JK.TipCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JK.TipCalc.Tests.Models
{
    public class TipCalculationTests
    {
        [Theory]
        [InlineData(10.0, 20, 2.0)]
        [InlineData(100.0, 20, 20.0)]
        public void Tip_Theories(decimal amount, int percent, decimal expected)
        {
            var sut = new TipCalculation
            {
                Amount = amount,
                Percent = percent
            };
            var actual = sut.Tip;
            Assert.Equal(expected, actual);
        }
    }
}
