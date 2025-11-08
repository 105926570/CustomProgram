using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Generates a random number given a length
        /// </summary>
        /// <param name="length">this is the length of the number, i.e, the amount of didgits that appear in the outputted number.</param>
        /// <returns>integer of a given length.</returns>
        public static int GenerateRandomNumberGivenItsLength(int length)
        {
            List<int> numbers = new List<int> { };
            int index = 0;

            //add a random number to the list for each number in the expected output
            while (index < length)
            {
                numbers.Add(GenerateRandomNumber(9));
                index++;
            }

            int multiplier = 1;
            int output = 0;
            foreach (int num in numbers)
            {
                output += num * multiplier;
                multiplier *= 10;
            }

            return output;
        }

        /// <summary>
        /// Generates a set number of random random numbers,
        /// witch are between 0 and the specified highest number using the provided seed,
        /// as an array of integers.
        /// </summary>
        public static List<int> GenerateANumberOfUniqueNumbers(int highestNumber, int desiredNumberOfNumbers)
        {
            List<int> generatedNumbers = new List<int>();
            int numberCreated = 0;
            int generatedRandomNumber;

            while (numberCreated < desiredNumberOfNumbers)
            {
                generatedRandomNumber = GenerateRandomNumber(highestNumber);
                bool unique = true;

                foreach (int numb in generatedNumbers)
                { if (numb == generatedRandomNumber) unique = false; }

                if (unique)
                {
                    generatedNumbers.Add(generatedRandomNumber);
                    numberCreated++;
                }
            }
            return generatedNumbers;
        }
        #endregion
    }
}