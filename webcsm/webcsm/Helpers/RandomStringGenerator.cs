using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace webcsm.Helpers
{
    public static class RandomStringGenerator
    {
        private static readonly RandomNumberGenerator CryptoRandomDataGenerator = new RNGCryptoServiceProvider();
        public static string GenerateRandomString(int length)
        {
            byte[] buffer = new byte[length];
            CryptoRandomDataGenerator.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

    }
}