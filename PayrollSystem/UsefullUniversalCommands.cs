using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class UsefullUniversalCommands
    {
        public DateTime datetime = DateTime.Now;

        /// <summary>
        /// Generates a random number between the specified lowest and highest numbers using the current time in milliseconds as the seed.
        /// </summary>
        public int GenerateRandomNumber(int highestNumber, int lowestNumber)
        {
            int i = datetime.Millisecond;
            int g = new Random(i).Next(lowestNumber, highestNumber);
            return g;
        }

        /// <summary>
        /// Generates a random number between 0 and the specified highest number using the current time in milliseconds as the seed.
        /// </summary>
        public int GenerateRandomNumber(int highestNumber)
        {
            int i = datetime.Millisecond;
            int g = new Random(i).Next(0, highestNumber);
            return g;
        }

        /// <summary>
        /// Generates a random number between the specified lowest and highest numbers using the provided seed.
        /// </summary>
        public int GenerateRandomNumberGivenSeed(int highestNumber, int lowestNumber, int seed)
        {
            int g = new Random(seed).Next(lowestNumber, highestNumber);
            return g;
        }

        /// <summary>
        /// Generates a random number between 0 and the specified highest number using the provided seed.
        /// </summary>
        public int GenerateRandomNumberGivenSeed(int highestNumber, int seed)
        {
            int g = new Random(seed).Next(0, highestNumber);
            return g;
        }   
    }
}
