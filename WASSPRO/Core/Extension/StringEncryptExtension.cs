using System;
using System.Security.Cryptography;
using System.Text;

namespace QLCongNo.Core.Extension
{
    /// <summary>
    /// Provides extension methods for string encryption.
    /// </summary>
    public static class StringEncryptExtension
    {
        /// <summary>
        /// Computes the MD5 hash of the input string.
        /// </summary>
        /// <param name="input">The input string to compute the hash for.</param>
        /// <returns>The MD5 hash of the input string.</returns>
        public static string ComputeMd5Hash(this string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}