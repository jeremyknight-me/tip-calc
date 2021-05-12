using System.Collections;
using System.Collections.Generic;

namespace JK.TipCalc.Models
{
    public class TipCalculationList : IList<TipCalculation>
    {
        private List<TipCalculation> list;
        private decimal billAmount;

        public TipCalculationList()
        {
            this.list = new List<TipCalculation>();
            this.billAmount = 0;
        }

        #region IList Implementation

        public TipCalculation this[int index]
        {
            get => this.list[index];
            set => this.list[index] = value;
        }

        public int Count => this.list.Count;
        public bool IsReadOnly => false;

        public void Add(TipCalculation item) => this.list.Add(item);
        public void Clear() => this.list.Clear();
        public bool Contains(TipCalculation item) => this.list.Contains(item);
        public void CopyTo(TipCalculation[] array, int arrayIndex) => this.list.CopyTo(array, arrayIndex);
        public IEnumerator<TipCalculation> GetEnumerator() => this.list.GetEnumerator();
        public int IndexOf(TipCalculation item) => this.list.IndexOf(item);
        public void Insert(int index, TipCalculation item) => this.list.Insert(index, item);
        public bool Remove(TipCalculation item) => this.list.Remove(item);
        public void RemoveAt(int index) => this.RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => this.list.GetEnumerator();

        #endregion

        public decimal BillAmount 
        {
            get => this.billAmount; 
            set
            {
                this.billAmount = value;
                foreach (var tipCalc in this.list)
                {
                    tipCalc.Amount = value;
                }
            }
        }
    }
}
