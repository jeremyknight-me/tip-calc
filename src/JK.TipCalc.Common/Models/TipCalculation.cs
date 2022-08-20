namespace JK.TipCalc.Common.Models;
public class TipCalculation
{
    public decimal Amount { get; set; }
    public decimal Discount { get; set; }
    public int Percent { get; set; }
    public decimal Tip => (this.Amount + this.Discount) * (this.Percent / 100m);
    public decimal Total => this.Amount + this.Tip;
}
