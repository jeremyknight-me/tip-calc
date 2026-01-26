namespace JK.TipCalc.Calculator;

public sealed class TipCollection
{
    public TipCollection()
    {
    }

    public TipCollection(IEnumerable<int> percents)
    {
        foreach (var percent in percents)
        {
            Items.Add(Tip.Create(percent));
        }
    }

    public List<Tip> Items { get; private set; } = [];

    public void SetMealValues(decimal amount, decimal discount)
    {
        foreach (Tip item in Items)
        {
            item.SetMealValues(amount, discount);
        }
    }

    public void RoundDown()
    {
        foreach (Tip item in Items)
        {
            item.RoundDown();
        }
    }

    public void RoundUp()
    {
        foreach (Tip item in Items)
        {
            item.RoundUp();
        }
    }
}
