using JK.TipCalc.Common.Models;
using Microsoft.AspNetCore.Components;

namespace JK.TipCalc.Common.Components;
public partial class TipCalculator
{
    protected TipList TipModel { get; private set; }

    protected override void OnInitialized()
    {
        this.TipModel = new TipList
        {
            CustomTip = new TipCalculation { Percent = 25 },
            TipCalculations = new List<TipCalculation>
                {
                    new TipCalculation { Percent = 10 },
                    new TipCalculation { Percent = 15 },
                    new TipCalculation { Percent = 18 },
                    new TipCalculation { Percent = 20 },
                    new TipCalculation { Percent = 22 }
                }
        };
    }

    protected void HandleCustomTipAmountChanged(ChangeEventArgs e)
    {
        var candidate = e?.Value.ToString();
        this.TipModel.CustomTip.Percent = int.TryParse(candidate, out int value) ? value : 0;
    }
}
