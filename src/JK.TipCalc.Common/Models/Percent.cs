namespace JK.TipCalc.Common.Models;
public sealed class Percent
{
    public int Value { get; private set; } = 0;

    private Percent(int value)
    {
        this.SetValue(value);
    }

    public void SetValue(int value)
    {
        if (value < 0 || value > 100)
        {
            throw new InvalidPercentException(nameof(value));
        }

        this.Value = value;
    }

    public static Percent Create(int value) => new(value);

    public override string ToString()
    {
        return this.Value.ToString("##");
    }
}
