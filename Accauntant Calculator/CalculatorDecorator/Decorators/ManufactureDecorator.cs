using Accauntant_Calculator.CalculatorDecorator;

namespace Accauntant_Calculator.CalculatorDecorator.Decorators
{
    class ManufactureDecorator : AbstractCalculatorDecorator
    {
        private decimal mPercent;
        private ICalculatorComponent mBaseComponent;

        public ManufactureDecorator(ICalculatorComponent component, ICalculatorComponent baseComponent, decimal percent) : base(component)
        {
            mPercent = percent;
            mBaseComponent = baseComponent;
        }

        public override decimal GetPrice()
        {
            return component.GetPrice() + mBaseComponent.GetPrice() * ( mPercent / (decimal)100);
        }
    }
}
