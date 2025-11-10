using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static PayrollSystem.Program;

namespace PayrollSystem
{
    public static class UsefullUniversalCommands
    {
        // RANDOM NUMBER GENERATION METHODS
        #region "Random Number Generation"

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
                numbers.Add(rand.Next(9));
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
        public static List<int> RandomArray(int highestNumber, int desiredNumberOfNumbers)
        {
            List<int> randomNumbers = new List<int>();
            int numberOfNumbersAdded = 0;

            while (desiredNumberOfNumbers > numberOfNumbersAdded)
                    randomNumbers.Add(rand.Next(highestNumber));

            //check if length is invalid or wrong:
            if (randomNumbers.Count != desiredNumberOfNumbers)
                    throw new ArgumentException();

            return randomNumbers;
        }
        #endregion

        /// <summary> prints to console and msg box simultaiously with just one function. 
        /// <example>Output: [currentdateandtime] - [message]</example></summary>
        /// <param name="message">mesage you wish to be printed</param>
        public static void shMsgBoxT(string message)
        {
            shMsgBox($"{DateTime.Now.ToString()} - {message}");
        }

        public static void shMsgBox(string msg)
        {
            MessageBox.Show(msg);
            Console.WriteLine(msg);
        }
    }
}