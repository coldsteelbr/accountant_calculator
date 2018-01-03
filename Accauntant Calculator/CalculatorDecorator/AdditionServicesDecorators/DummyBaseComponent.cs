using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator.AdditionServicesDecorators
{
    class DummyBaseComponent : ICalculatorComponent
    {
        public DummyBaseComponent()
        {
        }

        public decimal GetPrice()
        {
            return 0;
        }
    }
}
