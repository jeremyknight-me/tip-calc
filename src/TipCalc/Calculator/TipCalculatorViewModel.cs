namespace JK.TipCalc.Calculator;

public class TipCalculatorViewModel
{
    private TipCalculatorViewModel(int customTipPercent, IEnumerable<int> percentList)
    {
        State = CalculatorState.Default;
        IEnumerable<int> fullList = percentList.Union([customTipPercent]);
        Tips = new TipCollection(fullList);
    }

    public CalculatorState State { get; private set; }
    public TipCollection Tips { get; private set; }
    public Tip CustomTip => Tips.Items.Last();
    public List<string> Errors { get; private set; } = new();
    public bool HasErrors => Errors.Any();

    public decimal Amount
    {
        get => field;
        set
        {
            field = value;
            Tips.SetMealValues(value, Discount);
        }
    }

    public decimal Discount
    {
        get => field;
        set
        {
            field = value;
            Tips.SetMealValues(Amount, value);
        }
    }

    public static TipCalculatorViewModel Create(int customTipPercent, int[] percentList)
        => new(customTipPercent, percentList);

    public void ChangeCustomTip(string value)
    {
        var newValue = int.TryParse(value, out int intValue) ? intValue : 0;
        if (newValue < 0 || newValue > 100)
        {
            throw new InvalidPercentException(nameof(newValue));
        }

        CustomTip.Percent.Value = newValue;
        CustomTip.SetMealValues(Amount, Discount);
        switch (State)
        {
            case CalculatorState.RoundDown:
                CustomTip.RoundDown();
                break;
            case CalculatorState.RoundUp:
                CustomTip.RoundUp();
                break;
                //case CalculatorState.Default:
                //default:
        }
    }

    public void Reset()
    {
        Tips.SetMealValues(Amount, Discount);
        State = CalculatorState.Default;
    }

    public void RoundDown()
    {
        Tips.RoundDown();
        State = CalculatorState.RoundDown;
    }

    public void RoundUp()
    {
        Tips.RoundUp();
        State = CalculatorState.RoundUp;
    }
}
