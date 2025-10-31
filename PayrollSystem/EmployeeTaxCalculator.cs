using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{

    public class EmployeeTaxCalculator
    {
        private float[] bracketStarts = new float[] { 0, 18200, 45000, 135000, 190000 }; //if above, then the index of that number is the tax bracket
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
            switch (bracketIndex)
            {
                case 0:
                    return 0.0f;
                case 1:
                    return 0.16f;            
                case 2:
                    return 0.30f;
                case 3:
                    return 0.37f;                 
                case 4:
                    return 0.45f;
                default:
                    return 0.0f;
            }
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
    }
}
