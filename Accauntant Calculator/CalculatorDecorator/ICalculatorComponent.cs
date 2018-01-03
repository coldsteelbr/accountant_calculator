using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator
{
    /// <summary>
    /// Component
    /// </summary>
    interface ICalculatorComponent
    {
        /// <summary>
        /// Operation
        /// </summary>
        /// <returns></returns>
        decimal GetPrice();
    }
}
