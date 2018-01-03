using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator.Decorators
{
    class ExpatsDecorator : AbstractCalculatorDecorator
    {
        private decimal mPrice;
        private int mExpatCount;

        public ExpatsDecorator(ICalculatorComponent component, int expatCount, decimal price) : base(component)
        {
            mPrice = price;
            mExpatCount = expatCount;
        }

        public override decimal GetPrice()
        {
            return component.GetPrice() + mExpatCount * mPrice;
        }
    }
}
