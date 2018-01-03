using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accauntant_Calculator.CalculatorDecorator
{ 
    class BasicPriceList
    {
        public static string[] TaxModeNames
         = { "ОСНО", "УСН 15%", "УСН 6%" };


        public static string[] OperationRangeNames 
            = { "<= 50", "51-100", "101-150", "151-200", "201-300", "301-400" };

        Dictionary<String, Dictionary<String, decimal>> mDictionary = new Dictionary<String, Dictionary<string, decimal>>();

        public BasicPriceList()
        {
            Dictionary<String, decimal> osnoRow = new Dictionary<string, decimal>();
            Dictionary<String, decimal> usn15Row = new Dictionary<string, decimal>();
            Dictionary<String, decimal> usn6Row = new Dictionary<string, decimal>();

            // OSNO 
            osnoRow.Add(OperationRangeNames[0], 20000);
            osnoRow.Add(OperationRangeNames[1], 25000);
            osnoRow.Add(OperationRangeNames[2], 30000);
            osnoRow.Add(OperationRangeNames[3], 35000);
            osnoRow.Add(OperationRangeNames[4], 42000);
            osnoRow.Add(OperationRangeNames[5], 49000);

            // USN 15
            usn15Row.Add(OperationRangeNames[0], 10000);
            usn15Row.Add(OperationRangeNames[1], 17000);
            usn15Row.Add(OperationRangeNames[2], 35000);
            usn15Row.Add(OperationRangeNames[3], 28000);
            usn15Row.Add(OperationRangeNames[4], 33000);
            usn15Row.Add(OperationRangeNames[5], 38000);

            // USN 6
            usn6Row.Add(OperationRangeNames[0], 10000);
            usn6Row.Add(OperationRangeNames[1], 15000);
            usn6Row.Add(OperationRangeNames[2], 20000);
            usn6Row.Add(OperationRangeNames[3], 23000);
            usn6Row.Add(OperationRangeNames[4], 26000);
            usn6Row.Add(OperationRangeNames[5], 29000);

            mDictionary.Add(TaxModeNames[0], osnoRow);
            mDictionary.Add(TaxModeNames[1], usn15Row);
            mDictionary.Add(TaxModeNames[2], usn6Row);
        }

        public Dictionary<String, Dictionary<String, decimal>> GetPriceList()
        {
            return mDictionary;
        }
    }
    

    /// <summary>
    /// ConcreteComponent
    /// </summary>
    class BaseCalculatorComponent : ICalculatorComponent
    {

        private String mTaxMode;
        private String mOperationCountRangeName;
        private BasicPriceList mPriceList;

        public BaseCalculatorComponent(String taxMode, string operationCount, BasicPriceList priceList)
        {
            mTaxMode = taxMode;
            mOperationCountRangeName = operationCount;
            mPriceList = priceList;
        }

        decimal ICalculatorComponent.GetPrice()
        {
            return mPriceList.GetPriceList()[mTaxMode][mOperationCountRangeName];
        }
    }
}
