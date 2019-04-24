using System;
using System.Security.Cryptography;

namespace KFC.Red.ServiceLayer
{
    public class ReusableServices
    {

        // random number generator

        private static RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public int GetNumberForRandomization(int minValue, int maxValue)
        {
            //byte array that holds the random number
            byte[] randomNum = new byte[1];

            //fills byte array with random values
            _generator.GetBytes(randomNum);

            //convert randomNum to double 
            double asciiValue = Convert.ToDouble(randomNum[0]);

            //keeps multiplier between 0.0 and .99999999999 for rounding purposes
            double multiplier = Math.Max(0, (asciiValue / 255d) - 0.00000000001d);

            //adding 1 to range for rounding purposes
            int range = maxValue - minValue + 1;

            double randomNumInRange = Math.Floor(multiplier * range);

            return (int)(minValue + randomNumInRange);
        }
    }
}
