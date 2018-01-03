using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator.Decorators
{
    class KKMDecorator : AbstractCalculatorDecorator
    {
        private int mExtraKKMCount = 0;
        private decimal mPrice;
        public KKMDecorator(ICalculatorComponent component, int kkmCount, int baseKkmCount, decimal price) : base(component)
        {
            mPrice = price;
            if (kkmCount > baseKkmCount) {
                mExtraKKMCount = kkmCount - baseKkmCount;
            } 
        }

        public override decimal GetPrice()
        {
            return component.GetPrice() + mExtraKKMCount * mPrice;
        }
    }
}
