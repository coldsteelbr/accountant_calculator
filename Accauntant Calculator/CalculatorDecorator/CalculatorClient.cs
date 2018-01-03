using Accauntant_Calculator.CalculatorDecorator.Decorators;

namespace Accauntant_Calculator.CalculatorDecorator
{
    class CalculatorClient
    {
        public decimal GetPrice()
        {

            AbstractCalculatorDecorator currentDecorator;

            // base
            BaseCalculatorComponent baseComponent
                = new BaseCalculatorComponent(BasicPriceList.TaxModeNames[0], BasicPriceList.OperationRangeNames[5], new BasicPriceList());

            // Employees decorator
            EmployeesCalculatorDecorator employeeDecorator = new EmployeesCalculatorDecorator(baseComponent, 3, 300);
            employeeDecorator.EmployeeCount = 4;
            currentDecorator = employeeDecorator;

            // VED decorator
            VEDExportImportDecorator vedDecorator = new VEDExportImportDecorator(currentDecorator, 5000);
            currentDecorator = vedDecorator;

            // Currency account decorator
            CurrencyAccountCountDecorator currencyDecorator = new CurrencyAccountCountDecorator(currentDecorator, 1000, 2);
            currentDecorator = currencyDecorator;

            // KKM decorator
            KKMDecorator kkmDecorator = new KKMDecorator(currencyDecorator, 2, 1, 3000);
            currentDecorator = kkmDecorator;

            // Branches decorator
            //BranchesDecorator branchesDecorator = new BranchesDecorator(currentDecorator, 5000);
            //currentDecorator = branchesDecorator;

            // Leasing/Credit
            LeasingCreditDecorator leasingCreditDecorator = new LeasingCreditDecorator(currentDecorator, 2000);
            currentDecorator = leasingCreditDecorator;

            // Expats decorator
            ExpatsDecorator expatsDecorator = new ExpatsDecorator(currentDecorator, 3, 500);
            currentDecorator = expatsDecorator;

            // Client bank decorator
            ClientBankDecorator clientBankDecorator = new ClientBankDecorator(currentDecorator, 5000);
            currentDecorator = clientBankDecorator;

            // Primary documents decorator
            PrimaryDocumentsDecorator primaryDocumentsDecorator = new PrimaryDocumentsDecorator(currentDecorator, baseComponent, 30);
            currentDecorator = primaryDocumentsDecorator;

            // Fixed assets decorator
            FixedAssetsDecorator fixedAssetsDecorator = new FixedAssetsDecorator(currentDecorator, 3000);
            currentDecorator = fixedAssetsDecorator;

            // Manufacture decorator
            ManufactureDecorator manufactureDecorator = new ManufactureDecorator(currentDecorator, baseComponent, 30);
            currentDecorator = manufactureDecorator;

            // LAST decorator
            return currentDecorator.GetPrice();
        }
    }
}
