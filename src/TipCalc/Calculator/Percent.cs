namespace JK.TipCalc.Calculator;

public sealed class Percent
{
    private Percent()
    {
    }

    public int Value
    {
        get => field;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new InvalidPercentException(nameof(value));
            }

            field = value;
        }
    }

    public static Percent Create(int value) => new() { Value = value };

    public override string ToString()
    {
        return Value.ToString("##");
    }
}
