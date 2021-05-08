using JK.TipCalc.Models;

namespace JK.TipCalc.Components
{
    public partial class SimpleView
    {
        protected TipCalculationList PercentCalculations { get; private set; }


        protected override void OnInitialized()
        {
            this.PercentCalculations = new TipCalculationList
            {
                new TipCalculation { Amount = 100m, Percent = 10 },
                new TipCalculation { Amount = 100m, Percent = 15 },
                new TipCalculation { Amount = 100m, Percent = 18 },
                new TipCalculation { Amount = 100m, Percent = 20 },
                new TipCalculation { Amount = 100m, Percent = 22 }
            };
        }
    }
}
