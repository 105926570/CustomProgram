using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    internal class EmployeeTaxInfo
    {
        public int TaxBracket;
        public EmployeeTaxInfo() { }


        //Ensure that the following tax brackets are implemented in the payroll calculations:

        /// Australian Tax Brackets for the 2023-2024 financial year
        /// [yearly income]   [tax rate]	[base tax plus]
        /// $0 – $18,200	     0%         Nil
        /// $18,201 – $45,000	16%     	16c for each $1 over $18,200
        /// $45,001 – $135,000	30%	        $4,288 plus 30c for each $1 over $45,000
        /// $135,001 – $190,000	37%	        $31,288 plus 37c for each $1 over $135,000
        /// $190,001 and over	45%	        $51,638 plus 45c for each $1 over $190,000
        /// source: https://www.ato.gov.au/rates/individual-income-tax-rates/
    }
}