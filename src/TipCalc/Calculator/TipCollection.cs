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
            this.Items.Add(Tip.Create(percent));
        }
    }

    public List<Tip> Items { get; private set; } = new();

    public void SetMealValues(decimal amount, decimal discount)
    {
        foreach (var item in this.Items)
        {
            item.SetMealValues(amount, discount);
        }
    }

    public void RoundDown()
    {
        foreach (var item in this.Items)
        {
            item.RoundDown();
        }
    }

    public void RoundUp()
    {
        foreach (var item in this.Items)
        {
            item.RoundUp();
        }
    }
}
