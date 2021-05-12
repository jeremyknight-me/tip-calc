using JK.TipCalc.Models;
using Microsoft.AspNetCore.Components;

namespace JK.TipCalc.Components
{
    public partial class SimpleView
    {
        protected TipCalculationList PercentCalculations { get; private set; }
        protected TipCalculation CustomTip { get; private set; }

        protected override void OnInitialized()
        {
            this.CustomTip = new TipCalculation();
            this.PercentCalculations = new TipCalculationList
            {
                new TipCalculation { Percent = 10 },
                new TipCalculation { Percent = 15 },
                new TipCalculation { Percent = 18 },
                new TipCalculation { Percent = 20 },
                new TipCalculation { Percent = 22 }
            };
        }

        protected void HandleBillAmountChanged(ChangeEventArgs e)
        {
            var candidate = e?.Value.ToString();
            var parsedValue = decimal.TryParse(candidate, out decimal value) ? value : 0;
            this.PercentCalculations.BillAmount = parsedValue;
            this.CustomTip.Amount = parsedValue;
        }

        protected void HandleCustomTipAmountChanged(ChangeEventArgs e)
        {
            var candidate = e?.Value.ToString();
            this.CustomTip.Percent = int.TryParse(candidate, out int value) ? value : 0;
        }
    }
}
