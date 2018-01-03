using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator.Decorators
{
    internal class EmployeesCalculatorDecorator : AbstractCalculatorDecorator
    {
        public int EmployeeCount { get; set; } = 0;
        private int mMinimalEmployeeCount;
        private decimal mExtraEmployeePrice;

        public EmployeesCalculatorDecorator(ICalculatorComponent component, int minimalEmployeeCount, decimal extraEmployeePrice) : base(component){
            mMinimalEmployeeCount = minimalEmployeeCount;
            mExtraEmployeePrice = extraEmployeePrice;
        }

        public override decimal GetPrice()
        {
            decimal extraEmployeesCost;

            // No additional money for minimal employee count
            if (EmployeeCount <= mMinimalEmployeeCount)
            {
                extraEmployeesCost = 0;
            }
            else
            {
                // adding price for each extra employee
                int extraEmployeeCount = EmployeeCount - mMinimalEmployeeCount;
                extraEmployeesCost = mExtraEmployeePrice * extraEmployeeCount;
            }
            return component.GetPrice() + extraEmployeesCost;
        }
    }
}
