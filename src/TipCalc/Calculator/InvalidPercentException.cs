namespace JK.TipCalc.Calculator;

public sealed class InvalidPercentException : ArgumentOutOfRangeException
{
    public InvalidPercentException(string argumentName)
        : base(argumentName, "Percent value must be an integer between 0 and 100")
    {
    }
}
