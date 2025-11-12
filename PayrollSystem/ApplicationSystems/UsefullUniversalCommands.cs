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
        /// Generates a set number of random random numbers,
        /// witch are between 0 and the specified highest number using the provided seed,
        /// as an array of integers.
        /// </summary>
        public static List<int> GenerateListOfRandomIntegers(int HighestNumber, int listLength)
        {
            List<int> randomNumbers = new List<int>();
            int numberOfNumbersAdded = 0;

            while (listLength > numberOfNumbersAdded)
                randomNumbers.Add(rand.Next(HighestNumber));

            return randomNumbers;
        }
        #endregion

        /// <summary> prints to console and msg box simultaiously with just one function. 
        /// <example>Output: [currentdateandtime] - [message]</example></summary>
        /// <param name="message">mesage you wish to be printed</param>
        public static void ShowMessageBoxGivenString_StartingWithTime(string message)
        {
            ShowMessageBoxGivenString($"{DateTime.Now.ToString()} - {message}");
        }

        public static void ShowMessageBoxGivenString(string message)
        {
            MessageBox.Show(message);
            Console.WriteLine(message);
        }
    }
}