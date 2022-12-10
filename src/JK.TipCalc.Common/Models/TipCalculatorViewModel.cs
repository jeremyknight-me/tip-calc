namespace JK.TipCalc.Common.Models;
public class TipCalculatorViewModel
{
    private decimal amount;
    private decimal discount;

    private TipCalculatorViewModel(int customTipPercent, IEnumerable<int> percentList)
    {
        this.CustomTip = Tip.Create(customTipPercent);
        this.Tips = new TipCollection(percentList);
    }

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
}