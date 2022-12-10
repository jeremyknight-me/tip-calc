namespace JK.TipCalc.Common.Models;
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
        foreach (var tip in this.Items)
        {
            tip.SetMealValues(amount, discount);
        }
    }
}
