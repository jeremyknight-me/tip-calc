namespace JK.TipCalc.Models
{
    public class TipCalculation
    {
        public decimal Amount { get; set; }
        public int Percent { get; set; }
        public decimal Tip => this.Amount * (this.Percent / 100m);
    }
}
