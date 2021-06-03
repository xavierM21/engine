using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace engine
{
    public static class RNG
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        private static readonly Random _simpleGenerator = new Random();
        public static int SimpleNumberBetween(int minVal, int maxVal)
        {
            return _simpleGenerator.Next(minVal, maxVal + 1);
        }
    }
}
