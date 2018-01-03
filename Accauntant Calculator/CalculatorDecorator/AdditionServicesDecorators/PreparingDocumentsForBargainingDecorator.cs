﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator.AdditionServicesDecorators
{
    class PreparingDocumentsForBargainingDecorator : AbstractCalculatorDecorator
    {
        private decimal mPrice;

        public PreparingDocumentsForBargainingDecorator(ICalculatorComponent component, decimal price) : base(component)
        {
            mPrice = price;
        }

        public override decimal GetPrice()
        {
            return component.GetPrice() + mPrice;
        }
    }
}
