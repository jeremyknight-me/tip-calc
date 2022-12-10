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
            throw new ArgumentOutOfRangeException(nameof(value), "Percent value must be an integer between 0 and 100");
        }

        this.Value = value;
    }

    public void SetValue(string value)
    {
        var newValue = int.TryParse(value, out int intValue) ? intValue : 0;
        this.SetValue(newValue);
    }

    public static Percent Create(int value) => new(value);

    public override string ToString()
    {
        return this.Value.ToString("##");
    }
}
