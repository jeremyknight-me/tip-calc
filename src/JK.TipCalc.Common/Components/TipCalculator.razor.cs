using JK.TipCalc.Common.Models;
using Microsoft.AspNetCore.Components;

namespace JK.TipCalc.Common.Components;
public partial class TipCalculator
{
    protected TipCalculatorViewModel ViewModel { get; private set; }

    protected override void OnInitialized()
    {
        const int customTipPercent = 25;
        var percents = new int[] { 10, 15, 28, 20, 22 };
        this.ViewModel = TipCalculatorViewModel.Create(customTipPercent, percents);
    }

    protected void HandleCustomTipAmountChanged(ChangeEventArgs e)
    {
        var candidate = e?.Value?.ToString()?.Trim() ?? string.Empty;
        this.ViewModel.CustomTip.Percent.SetValue(candidate);
    }
}
