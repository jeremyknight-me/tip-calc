using System.Collections.Generic;

namespace JK.TipCalc.Models
{
    public class TipList
    {
        private decimal amount;

        public List<TipCalculation> TipCalculations { get; set; }
        public TipCalculation CustomTip { get; set; }

        public decimal Amount
        {
            get => this.amount;
            set
            {
                this.amount = value;
                this.CustomTip.Amount = value;
                foreach (var calc in this.TipCalculations)
                {
                    calc.Amount = value;
                }
            }
        }
    }
}
