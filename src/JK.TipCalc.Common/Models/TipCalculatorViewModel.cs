namespace JK.TipCalc.Common.Models;
public class TipCalculatorViewModel
{
    private decimal amount;
    private decimal discount;

    private TipCalculatorViewModel(int customTipPercent, IEnumerable<int> percentList)
    {
        this.State = CalculatorState.Default;
        this.CustomTip = Tip.Create(customTipPercent);
        this.Tips = new TipCollection(percentList);
    }

    public CalculatorState State { get; private set; }
    public TipCollection Tips { get; private set; }
    public Tip CustomTip { get; private set; }

    public decimal Amount
    {
        get => this.amount;
        set
        {
            this.amount = value;
            this.CustomTip.SetMealValues(value, this.Discount);
            this.Tips.SetMealValues(value, this.Discount);
        }
    }

    public decimal Discount
    {
        get => this.discount;
        set
        {
            this.discount = value;
            this.CustomTip.SetMealValues(this.Amount, value);
            this.Tips.SetMealValues(this.Amount, value);
        }
    }

    public static TipCalculatorViewModel Create(int customTipPercent, int[] percentList)
        => new(customTipPercent, percentList);

    public void ChangeCustomTip(string value)
    {
        this.CustomTip.Percent.SetValue(value);
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
        this.CustomTip.SetMealValues(this.amount, this.discount);
        this.Tips.SetMealValues(this.amount, this.discount);
        this.State = CalculatorState.Default;
    }

    public void RoundDown()
    {
        this.CustomTip.RoundDown();
        this.Tips.RoundDown();
        this.State = CalculatorState.RoundDown;
    }

    public void RoundUp()
    {
        this.CustomTip.RoundUp();
        this.Tips.RoundUp();
        this.State = CalculatorState.RoundUp;
    }
}