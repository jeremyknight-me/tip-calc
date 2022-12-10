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

    public static Tip Create(int percent)
    {
        return new Tip(percent);
    }
}
