using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator
{
    // Decorator
    abstract class AbstractCalculatorDecorator : ICalculatorComponent
    {
        protected ICalculatorComponent component;

        public AbstractCalculatorDecorator(ICalculatorComponent component)
        {
            this.component = component;
        }

        public abstract decimal GetPrice();
    }
}
