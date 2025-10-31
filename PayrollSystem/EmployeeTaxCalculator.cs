using System;

namespace PayrollSystem
{
    public class EmployeeTaxCalculator
    {

        private readonly float[] bracketStarts = new float[] { 0, 18200, 45000, 135000, 190000 }; //if above, then the index of that number is the tax bracket
        private readonly float[] taxPercentages = new float[] { 0f, 0.16f, 0.30f, 0.37f, 0.45f };
        private int _taxBracket = 0;
        private float _yearlyIncome = 0.0f;


        public EmployeeTaxCalculator(float yearlyIncome) 
        {
            _yearlyIncome = yearlyIncome;
        }


        public float AmountToBeTaxedAtEndOfYear(float yearlyIncome) //This is the function run when generating tax.
        { 
            float yearlyTax = 0f;
            int taxBracketNumber = CalculateTaxBracket(yearlyIncome);

            float baseTax = CalculateBaseTax(taxBracketNumber);
            float extraInBracket = FindFinalTax(baseTax, taxBracketNumber, yearlyIncome);
            yearlyTax = baseTax + extraInBracket;

            return yearlyTax;
        }


        private int CalculateTaxBracket(float yearlyIncome)
        {
            if (/*yearlyIncome > bracketStarts[0] &&*/ yearlyIncome <= bracketStarts[1])
            {
                return 0;
            }
            else if (yearlyIncome > bracketStarts[1] && yearlyIncome <= bracketStarts[2])
            {
                return 1;
            }
            else if (yearlyIncome > bracketStarts[2] && yearlyIncome <= bracketStarts[3])
            {
                return 2;
            }
            else if (yearlyIncome > bracketStarts[3] && yearlyIncome <= bracketStarts[4])
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        private float CalculateBaseTax(int taxBracket)
        {
            int currentInLoop = 0;
            int targetInt = taxBracket - 1;
            float baseTax = 0f;

            while (currentInLoop < targetInt)
            {
                baseTax += bracketStarts[currentInLoop] * taxPercentages[currentInLoop];
            }
            return baseTax;
        }


        private float FindFinalTax(float baseTax, int taxBracketNumber, float yearlyIncome)
        {
            float remainder = yearlyIncome - baseTax;
            remainder = remainder * taxPercentages[taxBracketNumber];
            return remainder;
        }



    //properties:
        public float YearlyIncome
        {
            set { _yearlyIncome = value;  }
            get { return _yearlyIncome;  }
        }

        public int TaxBracket
        {
            get { return _taxBracket; }
        }
    }
}

//
// Use this website to test code output:
//
//  https://www.ato.gov.au/single-page-applications/calculatorsandtools?anchor=STC#STC/report
//
// Todo:
//
//  - make it so that when the yearly income is changed, the yearly tax is updated straight away, in case any references to the employee tax infos tax-to-pay are referred to.
//