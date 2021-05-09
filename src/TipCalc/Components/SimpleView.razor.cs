using JK.TipCalc.Models;
using Microsoft.AspNetCore.Components;

namespace JK.TipCalc.Components
{
    public partial class SimpleView
    {
        protected TipCalculationList PercentCalculations { get; private set; }

        protected override void OnInitialized()
        {
            this.PercentCalculations = new TipCalculationList
            {
                new TipCalculation { Percent = 10 },
                new TipCalculation { Percent = 15 },
                new TipCalculation { Percent = 18 },
                new TipCalculation { Percent = 20 },
                new TipCalculation { Percent = 22 }
            };
        }

        protected void HandleTipAmountChanged(ChangeEventArgs e)
        {
            var candidate = e?.Value.ToString();
            this.PercentCalculations.TipAmount = decimal.TryParse(candidate, out decimal value) ? value : 0;
        }
    }
}
