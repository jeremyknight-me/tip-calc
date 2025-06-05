namespace JK.TipCalc.Calculator;

public class TipCalculatorViewModel
{
    private decimal amount;
    private decimal discount;

    private TipCalculatorViewModel(int customTipPercent, IEnumerable<int> percentList)
    {
        this.State = CalculatorState.Default;
        var fullList = percentList.Union(new int[] { customTipPercent });
        this.Tips = new TipCollection(fullList);
    }

    public CalculatorState State { get; private set; }
    public TipCollection Tips { get; private set; }
    public Tip CustomTip => this.Tips.Items.Last();
    public List<string> Errors { get; private set; } = new();
    public bool HasErrors => this.Errors.Any();

    public decimal Amount
    {
        get => this.amount;
        set
        {
            this.amount = value;
            this.Tips.SetMealValues(value, this.Discount);
        }
    }

    public decimal Discount
    {
        get => this.discount;
        set
        {
            this.discount = value;
            this.Tips.SetMealValues(this.Amount, value);
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

        this.CustomTip.Percent.SetValue(newValue);
        this.CustomTip.SetMealValues(this.Amount, this.Discount);
        switch (this.State)
        {
            case CalculatorState.RoundDown:
                this.CustomTip.RoundDown();
                break;
            case CalculatorState.RoundUp:
                this.CustomTip.RoundUp();
                break;
                //case CalculatorState.Default:
                //default:
        }
    }

    public void Reset()
    {
        this.Tips.SetMealValues(this.amount, this.discount);
        this.State = CalculatorState.Default;
    }

    public void RoundDown()
    {
        this.Tips.RoundDown();
        this.State = CalculatorState.RoundDown;
    }

    public void RoundUp()
    {
        this.Tips.RoundUp();
        this.State = CalculatorState.RoundUp;
    }
}
