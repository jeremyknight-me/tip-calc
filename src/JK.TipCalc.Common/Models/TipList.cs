namespace JK.TipCalc.Common.Models;
public class TipList
{
    private decimal amount;
    private decimal discount;

    public List<TipCalculation> TipCalculations { get; set; }
    public TipCalculation CustomTip { get; set; }

    public decimal Amount
    {
        get => this.amount;
        set
        {
            this.amount = value;
            this.CustomTip.Amount = value;
            this.TipCalculations.ForEach(calc => calc.Amount = value);
        }
    }

    public decimal Discount
    {
        get => this.discount;
        set
        {
            this.discount = value;
            this.CustomTip.Discount = value;
            this.TipCalculations.ForEach(calc => calc.Discount = value);
        }
    }
}