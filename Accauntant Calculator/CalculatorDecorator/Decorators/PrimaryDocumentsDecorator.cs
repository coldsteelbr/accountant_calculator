using Accauntant_Calculator.CalculatorDecorator;

namespace Accauntant_Calculator.CalculatorDecorator.Decorators
{
    class PrimaryDocumentsDecorator : AbstractCalculatorDecorator
    {
        private decimal mPercent;
        private ICalculatorComponent mBaseComponent;

        public PrimaryDocumentsDecorator(ICalculatorComponent component, ICalculatorComponent baseComponent, decimal percent) : base(component)
        {
            mPercent = percent;
            mBaseComponent = baseComponent;
        }

        public override decimal GetPrice()
        {
            return component.GetPrice() + mBaseComponent.GetPrice() * ( mPercent / 100);
        }
    }
}
