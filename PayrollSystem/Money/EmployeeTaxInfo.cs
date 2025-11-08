using System;

namespace PayrollSystem
{
    public class EmployeeTaxInfo
    {
        private EmployeeTaxCalculator _taxCalculator;
        private int _tfn;

        public EmployeeTaxInfo(float yearlyIncome)
        { }

        public int TFN
        {
            get { return _tfn; }
            set
            {
                int i = 0;
                while (value > 0)
                {
                    value /= 10; // Integer division removes the last digit
                    i++;
                }

                if (i != 9)
                {
                    throw new ArgumentOutOfRangeException("Error: TFN does not have 9 digits in it.");
                }
                _tfn = value;
            }
        }

        //Ensure that the following tax brackets are implemented in the payroll calculations:

        ///         Australian Tax Brackets for the 2023-2024 financial year
        /// [no.]   [yearly income]    [tax rate]	    [base tax plus]
        ///     0   $0 – $18,200	       0%            ------------
        ///     1   $18,201 – $45,000	  16%     	    16c for each $1 over $18,200
        ///     2   $45,001 – $135,000	  30%	        $4,288 plus 30c for each $1 over $45,000
        ///     3   $135,001 – $190,000	  37%	        $31,288 plus 37c for each $1 over $135,000
        ///     4   $190,001 and over	  45%	        $51,638 plus 45c for each $1 over $190,000
        /// source: https://www.ato.gov.au/rates/individual-income-tax-rates/
    }
}