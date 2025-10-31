using System;

namespace PayrollSystem
{

    public class EmployeeTaxCalculator
    {
        private readonly float[] bracketStarts = new float[] { 0, 18200, 45000, 135000, 190000 }; //if above, then the index of that number is the tax bracket
        private readonly float[] taxPercentages = new float[] { 0f, 0.16f, 0.30f, 0.37f, 0.45f };
        public EmployeeTaxCalculator() { }

        public int CalculateTaxBracket(float yearlyIncome)
        {
            int i = 0;
            foreach (int money in bracketStarts)
            {
                if (yearlyIncome > money)
                {
                    return i;
                }
            }
            return 5;//if it is greater than all of them, return a 5. the highest tax bracket number.
        }

        public float CalculateRemainderIncome(float yearlyIncome, int taxBracketNumber)
        {
            float remainder;
            remainder = yearlyIncome - bracketStarts[taxBracketNumber];
            return remainder;
        }

        public float calculateTaxRate(int bracketIndex) // not yet needed, but functionality exists for proper tax calculation, including additional tax as a result of income on the base tax rate
        {
            return taxPercentages[bracketIndex];
        }

        public float AmountToBeTaxedAtEndOfYear(float taxPercentage, int taxBracketNumber, float yearlyIncome)
        {
            float taxToPay = (yearlyIncome * taxPercentage);

            switch (taxBracketNumber)
            {
                case 0:
                    break;
                case 1:
                    taxToPay += (yearlyIncome - bracketStarts[1]) * 0.16f;
                    break;
                case 2:
                    taxToPay += 4288f + (yearlyIncome - bracketStarts[2]) * 0.30f;
                    break;
                case 3:
                    taxToPay += 31288f + (yearlyIncome - bracketStarts[3]) * 0.37f;
                    break;
                case 4:
                    taxToPay += 51638f + (yearlyIncome - bracketStarts[4]) * 0.45f;
                    break;
            }
            return taxToPay;
        }

        public float AmountToBeTaxedAtEndOfYear(float yearlyIncome)
        {
            int taxBracketNumber = CalculateTaxBracket(yearlyIncome);
            float taxPercentage = calculateTaxRate(taxBracketNumber);
            float thing = AmountToBeTaxedAtEndOfYear(taxPercentage, taxBracketNumber, yearlyIncome);

            return thing;
        }
    }
}

// Todo. remake this entire function because apparently i have no idea how tax is calculated and that this is wrong
//       :(
//
// https://www.ato.gov.au/single-page-applications/calculatorsandtools?anchor=STC#STC/report