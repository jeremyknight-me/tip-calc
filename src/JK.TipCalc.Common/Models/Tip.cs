namespace JK.TipCalc.Common.Models;

public class Tip
{
    private Tip(int percent)
    {
        this.Percent = Percent.Create(percent);
    }

    public Percent Percent { get; set; }
    public decimal TipAmount { get; private set; }
    public decimal Total { get; private set; }

    public void SetMealValues(decimal mealAmount, decimal mealDiscount)
    {
        this.TipAmount = (mealAmount + mealDiscount) * (this.Percent.Value / 100m);
        this.Total = mealAmount + this.TipAmount;
    }

    public void RoundDown()
    {
        var diff = this.Total - decimal.Floor(this.Total);
        this.Total -= diff;
        this.TipAmount -= diff;
    }

    public void RoundUp()
    {
        var diff = decimal.Ceiling(this.Total) - this.Total;
        this.Total += diff;
        this.TipAmount += diff;
    }

    public static Tip Create(int percent)
    {
        return new Tip(percent);
    }
}
