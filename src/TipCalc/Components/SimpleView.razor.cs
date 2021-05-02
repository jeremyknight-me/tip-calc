using JK.TipCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JK.TipCalc.Components
{
    public partial class SimpleView
    {
        protected IEnumerable<TipCalculation> PercentCalculations { get; private set; }

        protected override void OnInitialized()
        {
            this.PercentCalculations = new List<TipCalculation>
            {
                new TipCalculation { Amount = 100m, Percent = 10 },
                new TipCalculation { Amount = 100m, Percent = 15 },
                new TipCalculation { Amount = 100m, Percent = 18 },
                new TipCalculation { Amount = 100m, Percent = 20 },
                new TipCalculation { Amount = 100m, Percent = 22 }
            };
        }
    }
}
