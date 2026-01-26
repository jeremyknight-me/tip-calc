namespace JK.TipCalc.Calculator;

public class Tip
{
    private Tip(int percent)
    {
        Percent = Percent.Create(percent);
    }

    public Percent Percent { get; set; }
    public decimal TipAmount { get; private set; }
    public decimal Total { get; private set; }

    public void SetMealValues(decimal mealAmount, decimal mealDiscount)
    {
        TipAmount = (mealAmount + mealDiscount) * (Percent.Value / 100m);
        Total = mealAmount + TipAmount;
    }

    public void RoundDown()
    {
        var diff = Total - decimal.Floor(Total);
        Total -= diff;
        TipAmount -= diff;
    }

    public void RoundUp()
    {
        var diff = decimal.Ceiling(Total) - Total;
        Total += diff;
        TipAmount += diff;
    }

    public static Tip Create(int percent)
    {
        return new Tip(percent);
    }
}
