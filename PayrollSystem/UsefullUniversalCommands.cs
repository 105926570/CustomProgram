using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public static class UsefullUniversalCommands
    {
        // RANDOM NUMBER GENERATION METHODS
        #region "Random Number Generation"

        /// <summary>
        /// Generates a random number between the specified lowest and highest numbers using the current time in milliseconds as the seed.
        /// </summary>
        public static int GenerateRandomNumber(int highestNumber, int lowestNumber)
        {
            return new Random(DateTime.Now.Millisecond).Next(lowestNumber, highestNumber);
        }

        /// <summary>
        /// Generates a random number between 0 and the specified highest number using the current time in milliseconds as the seed.
        /// </summary>
        public static int GenerateRandomNumber(int highestNumber)
        {
            return new Random(DateTime.Now.Millisecond).Next(0, highestNumber);
        }

        /// <summary>
        /// Generates a random number between the specified lowest and highest numbers using the provided seed.
        /// </summary>
        public static int GenerateRandomNumberGivenSeed(int highestNumber, int lowestNumber, int seed)
        {
            return new Random(seed).Next(lowestNumber, highestNumber);
        }

        /// <summary>
        /// Generates a random number between 0 and the specified highest number using the provided seed.
        /// </summary>
        public static int GenerateRandomNumberGivenSeed(int highestNumber, int seed)
        {
            return new Random(seed).Next(0, highestNumber); 
        }

        public static List<int> GenerateANumberOfUniqueNumbers(int highestNumber, int desiredNumberOfNumbers) 
        { 
            List<int> numbers = new List<int>();
            int i = 0;
            int num;

            while (i < desiredNumberOfNumbers)
            {
                //generate number
                //check if its unique
                //  if yes, add it to array again
                //   if no, do nothing

                num = GenerateRandomNumber(highestNumber);

                bool unique = true;

                foreach (int numb in numbers) 
                { 
                    if (numb == num) unique = false;
                }
                if (unique)
                {
                    numbers.Add(num);
                    i++;
                }
            }
            return numbers;
        }

        #endregion
    }
}