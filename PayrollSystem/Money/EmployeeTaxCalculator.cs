using System;

namespace PayrollSystem
{
    internal class EmployeeTaxCalculator
    {

        private readonly double[] bracketStarts = new double[] { 0, 18200, 45000, 135000, 190000 }; //if above, then the index of that number is the tax bracket
        private readonly double[] taxPercentagesResident = new double[] { 0f, 0.16f, 0.30f, 0.37f, 0.45f };
        private readonly double[] taxPercentagesNonResident = new double[] { 0.30f, 0.30f, 0.30f, 0.37f, 0.45f };
        private bool _isResident;
        private int _taxBracket = 0;
        private double _yearlyIncome = 0.0;


        public EmployeeTaxCalculator(double yearlyIncome)
        {
            _yearlyIncome = yearlyIncome;
        }


        public double AmountToBeTaxedAtEndOfYear(double yearlyIncome) //This is the function run when generating tax.
        {
            int taxBracket = CalculateTaxBracket(yearlyIncome);
            //Check if user is a resident or not and calculate tax acordingly.
            if (_isResident == true) //is resident
                return CalcResident(yearlyIncome, taxBracket);
            else // not resident
                return CalcNonResident(yearlyIncome, taxBracket);
        }

        public double AmountToBeTaxedAtEndOfYearRounded(double yearlyIncome) //This is the function run when generating tax.
        {
            return Math.Round(AmountToBeTaxedAtEndOfYear(yearlyIncome), 2);
        }


        private int CalculateTaxBracket(double yearlyIncome)
        {
            if (/*yearlyIncome > bracketStarts[0] &&*/ yearlyIncome <= bracketStarts[1])
                return 0;
            else if (yearlyIncome > bracketStarts[1] && yearlyIncome <= bracketStarts[2])
                return 1;
            else if (yearlyIncome > bracketStarts[2] && yearlyIncome <= bracketStarts[3])
                return 2;
            else if (yearlyIncome > bracketStarts[3] && yearlyIncome <= bracketStarts[4])
                return 3;
            else
                return 4;
        }


        private double CalcResident(double yearlyIncome, int taxBracket)
        {
            double[] taxPercentages = taxPercentagesResident;
            double remainder = yearlyIncome - bracketStarts[taxBracket];

            switch (taxBracket)
            {
                case 1:
                    return remainder * taxPercentages[taxBracket];

                case 2:
                    return (remainder * taxPercentages[taxBracket])
                         + ((bracketStarts[2] - bracketStarts[1]) * taxPercentages[1]);

                case 3:
                    return (remainder * taxPercentages[taxBracket])
                         + ((bracketStarts[3] - bracketStarts[2]) * taxPercentages[2])
                         + ((bracketStarts[2] - bracketStarts[1]) * taxPercentages[1]);

                case 4:
                    return (remainder * taxPercentages[taxBracket])
                         + ((bracketStarts[4] - bracketStarts[3]) * taxPercentages[3])
                         + ((bracketStarts[3] - bracketStarts[2]) * taxPercentages[2])
                         + ((bracketStarts[2] - bracketStarts[1]) * taxPercentages[1]);

                default:
                    return 0.0;
            }
        }


        private double CalcNonResident(double yearlyIncome, int taxBracket)
        {
            double[] taxPercentages = taxPercentagesNonResident;
            double remainder = yearlyIncome - bracketStarts[taxBracket];

            switch (taxBracket)
            {
                case 0: // Foreign residents are taxed from the first dollar
                    return yearlyIncome * taxPercentages[0];

                case 1:
                    return (remainder * taxPercentages[taxBracket])
                         + (bracketStarts[1] * taxPercentages[0]);

                case 2:
                    return (remainder * taxPercentages[taxBracket])
                         + ((bracketStarts[2] - bracketStarts[1]) * taxPercentages[1])
                         + (bracketStarts[1] * taxPercentages[0]);

                case 3:
                    return (remainder * taxPercentages[taxBracket])
                         + ((bracketStarts[3] - bracketStarts[2]) * taxPercentages[2])
                         + ((bracketStarts[2] - bracketStarts[1]) * taxPercentages[1])
                         + (bracketStarts[1] * taxPercentages[0]);

                case 4:
                    return (remainder * taxPercentages[taxBracket])
                         + ((bracketStarts[4] - bracketStarts[3]) * taxPercentages[3])
                         + ((bracketStarts[3] - bracketStarts[2]) * taxPercentages[2])
                         + ((bracketStarts[2] - bracketStarts[1]) * taxPercentages[1])
                         + (bracketStarts[1] * taxPercentages[0]);

                default:
                    return 0.0;
            }
        }

        //properties:
        public double YearlyIncome
        {
            set
            {
                _yearlyIncome = value;
                _taxBracket = CalculateTaxBracket(_yearlyIncome); // update bracket automatically
            }
            get { return _yearlyIncome; }
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
//
//Ensure that the following tax brackets are implemented in the payroll calculations:
//
///         Australian Tax Brackets for the 2023-2024 financial year
/// [no.]   [yearly income]    [tax rate]	    [base tax plus]
///     0   $0 – $18,200	       0%            ------------
///     1   $18,201 – $45,000	  16%     	    16c for each $1 over $18,200
///     2   $45,001 – $135,000	  30%	        $4,288 plus 30c for each $1 over $45,000
///     3   $135,001 – $190,000	  37%	        $31,288 plus 37c for each $1 over $135,000
///     4   $190,001 and over	  45%	        $51,638 plus 45c for each $1 over $190,000
/// source: https://www.ato.gov.au/rates/individual-income-tax-rates/
