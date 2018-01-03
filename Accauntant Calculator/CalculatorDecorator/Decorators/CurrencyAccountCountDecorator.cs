using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator.Decorators
{
    class CurrencyAccountCountDecorator : AbstractCalculatorDecorator
    {
        private int mAccountCount;
        private decimal mPrice;
        public CurrencyAccountCountDecorator(ICalculatorComponent component, decimal price, int accountCount) : base(component)
        {
            mAccountCount = accountCount;
            mPrice = price;
        }

        public override decimal GetPrice()
        {
            return component.GetPrice() + mPrice * mAccountCount;
        }
    }
}
