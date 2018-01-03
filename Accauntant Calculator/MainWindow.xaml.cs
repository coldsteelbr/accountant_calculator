using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Accauntant_Calculator.CalculatorDecorator.Decorators;
using Accauntant_Calculator.CalculatorDecorator;
using Accauntant_Calculator.CalculatorDecorator.AdditionServicesDecorators;

namespace Accauntant_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int BASE_EMPLOYEE_COUNT = 3;
        private const decimal EXTRA_EMPLOYEE_PRICE = 300;
        private const decimal VED_PRICE = 5000;
        private const decimal CURRENCY_ACCOUNT_PRICE = 1000;
        private const int BASE_KKM_COUNT = 1;
        private const decimal EXTRA_KKM_PRICE = 3000;
        private const decimal EXTRA_BRANCH_PRICE = 5000;
        private const decimal LEASING_CREDIT_PRICE = 2000;
        private const decimal EXPAT_PRICE = 500;
        private const decimal CLIENT_BANK_PRICE = 5000;
        private const decimal PRIMERY_DOCUMENTS_PERCENT = 30;
        private const decimal FIXED_ASSETS_PRICE = 3000;
        private const decimal MANUFACTURE_PERCENT = 30;

        private const decimal HIDDEN_COEFFICIENT = 1.15M;

        // Additional services
        private const decimal PREPARING_DOCUMENTS_FOR_BARGAINING_PRICE = 3000;
        private const decimal RESUBMISSION_OF_REPORT_PRICE = 5000;
        private const decimal KEEPING_DOCUMENTS_OF_PAST_YEARS_PRICE = 10000;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AbstractCalculatorDecorator currentDecorator;

            // Base
            BaseCalculatorComponent baseComponent
                = new BaseCalculatorComponent(cmb_taxRegime.SelectedValue.ToString(), cmb_operationCountRanges.SelectedValue.ToString(), new BasicPriceList());

            ICalculatorComponent currentComponent = baseComponent;

            // Employees decorator
            EmployeesCalculatorDecorator employeeDecorator = new EmployeesCalculatorDecorator(currentComponent, BASE_EMPLOYEE_COUNT, EXTRA_EMPLOYEE_PRICE);
            employeeDecorator.EmployeeCount = nud_employees.Value.Value;
            currentComponent = employeeDecorator;

            // VED decorator
            if (chk_ved.IsChecked.Value)
            {
                VEDExportImportDecorator vedDecorator = new VEDExportImportDecorator(currentComponent, VED_PRICE);
                currentComponent = vedDecorator;
            }
            // Currency account decorator
            CurrencyAccountCountDecorator currencyDecorator
                = new CurrencyAccountCountDecorator(currentComponent, price: CURRENCY_ACCOUNT_PRICE, accountCount: nud_currencyAccounts.Value.Value);
            currentComponent = currencyDecorator;

            // KKM decorator
            KKMDecorator kkmDecorator = new KKMDecorator(currentComponent, nud_kkmCount.Value.Value, BASE_KKM_COUNT, EXTRA_KKM_PRICE);
            currentComponent = kkmDecorator;

            // Branches decorator
            if (chk_branches.IsChecked.Value)
            {
                BranchesDecorator branchesDecorator
                = new BranchesDecorator(currentComponent, EXTRA_BRANCH_PRICE);
                currentComponent = branchesDecorator;
            }
            // Leasing/Credit
            if (chk_leasingCredits.IsChecked.Value)
            {
                LeasingCreditDecorator leasingCreditDecorator = new LeasingCreditDecorator(currentComponent, LEASING_CREDIT_PRICE);
                currentComponent = leasingCreditDecorator;
            }
            // Expats decorator
            ExpatsDecorator expatsDecorator = new ExpatsDecorator(currentComponent, nud_expatCount.Value.Value, EXPAT_PRICE);
            currentComponent = expatsDecorator;

            // Client bank decorator
            if (chk_clientBank.IsChecked.Value)
            {
                ClientBankDecorator clientBankDecorator = new ClientBankDecorator(currentComponent, CLIENT_BANK_PRICE);
                currentComponent = clientBankDecorator;
            }
            // Primary documents decorator
            if (chk_primaryDocuments.IsChecked.Value)
            {
                PrimaryDocumentsDecorator primaryDocumentsDecorator = new PrimaryDocumentsDecorator(currentComponent, baseComponent, PRIMERY_DOCUMENTS_PERCENT);
                currentComponent = primaryDocumentsDecorator;
            }
            // Fixed assets decorator
            if (chk_fixedAssets.IsChecked.Value)
            {
                FixedAssetsDecorator fixedAssetsDecorator = new FixedAssetsDecorator(currentComponent, FIXED_ASSETS_PRICE);
                currentComponent = fixedAssetsDecorator;
            }
            // Manufacture decorator
            if (chk_manufacture.IsChecked.Value)
            {
                ManufactureDecorator manufactureDecorator = new ManufactureDecorator(currentComponent, baseComponent, MANUFACTURE_PERCENT);
                currentComponent = manufactureDecorator;
            }

            // RESULT

            lbl_result.Content = currentComponent.GetPrice() * HIDDEN_COEFFICIENT + " rub.";

            //
            // Additional services
            //

            DummyBaseComponent dummy = new DummyBaseComponent();
            ICalculatorComponent addServCurrent = dummy;

            if (chk_keepingDocumentsOfPastYears.IsChecked.Value)
            {
                KeepingDocumentsOFPastYears keepingDecor = new KeepingDocumentsOFPastYears(addServCurrent, KEEPING_DOCUMENTS_OF_PAST_YEARS_PRICE);
                addServCurrent = keepingDecor;
            }

            if (chk_preparingDocumentsForTrading.IsChecked.Value)
            {
                PreparingDocumentsForBargainingDecorator preparingDocumentsDecor = new PreparingDocumentsForBargainingDecorator(addServCurrent, PREPARING_DOCUMENTS_FOR_BARGAINING_PRICE);
                addServCurrent = preparingDocumentsDecor;
            }

            if (chk_resubmissionOfDocuments.IsChecked.Value)
            {
                ResubmissionOfReport resubmissionDecor = new ResubmissionOfReport(addServCurrent, RESUBMISSION_OF_REPORT_PRICE);
                addServCurrent = resubmissionDecor;
            }
            // RESULT
            lbl_AdditionalServiceResult.Content = addServCurrent.GetPrice() + " rub.";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // populate Tax Regime
            cmb_taxRegime.ItemsSource = BasicPriceList.TaxModeNames;
            cmb_taxRegime.SelectedIndex = 0;

            // number of operations
            cmb_operationCountRanges.ItemsSource = BasicPriceList.OperationRangeNames;
            cmb_operationCountRanges.SelectedIndex = 0;
        }
    }
}
