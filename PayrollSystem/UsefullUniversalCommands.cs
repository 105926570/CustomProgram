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
        /// <summary>
        /// Generates a random number between the specified lowest and highest numbers using the current time in milliseconds as the seed.
        /// </summary>
        public static int GenerateRandomNumber(int highestNumber, int lowestNumber)
        {
            int randomNumber = new Random(DateTime.Now.Millisecond).Next(lowestNumber, highestNumber);
            return randomNumber;
        }

        /// <summary>
        /// Generates a random number between 0 and the specified highest number using the current time in milliseconds as the seed.
        /// </summary>
        public static int GenerateRandomNumber(int highestNumber)
        {
            int randomNumber = new Random(DateTime.Now.Millisecond).Next(0, highestNumber);
            return randomNumber;
        }

        /// <summary>
        /// Generates a random number between the specified lowest and highest numbers using the provided seed.
        /// </summary>
        public static int GenerateRandomNumberGivenSeed(int highestNumber, int lowestNumber, int seed)
        {
            int randomNumber = new Random(seed).Next(lowestNumber, highestNumber);
            return randomNumber;
        }

        /// <summary>
        /// Generates a random number between 0 and the specified highest number using the provided seed.
        /// </summary>
        public static int GenerateRandomNumberGivenSeed(int highestNumber, int seed)
        {
            int randomNumber = new Random(seed).Next(0, highestNumber);
            return randomNumber;
        }   
    }
}