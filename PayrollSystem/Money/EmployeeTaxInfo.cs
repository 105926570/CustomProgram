using System;
using static PayrollSystem.UsefullUniversalCommands;

namespace PayrollSystem
{
    public class EmployeeTaxInfo
    {
        private int _tfn;
        private bool _isResident;
        private int _taxBracket;
        private double _yearlyIncome;

        public EmployeeTaxInfo() //Default Constructor
        {
            _tfn = GenerateRandomNumber(999999999);
            _isResident = true;
            _yearlyIncome = 0;
            _taxBracket = 0;
        }

        public int TFN
        {
            get { return _tfn; }
            set {  _tfn = value; }
        }

        public bool IsResident
        {
            get { return _isResident; }
            set {  _isResident = value; }
        }

        public int taxBracket
        {
            get { return _taxBracket; }
            set { _taxBracket = value; }
        }

        public double YearlyIncome
        {
            get { return _yearlyIncome; }
            set { _yearlyIncome = value; }
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