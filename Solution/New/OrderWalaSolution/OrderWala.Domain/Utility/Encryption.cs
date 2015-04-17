using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    public static class Encryption
    {
        /// <summary>
        ///  Encrypt the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(this string password)
        {
            //byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(password));

            var sb = new StringBuilder();
            for (int i = 0; i < TDESKey.Length; i++)
            {
                sb.Append(TDESKey[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Encrypt the password in base64 string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptToBase64(this string password)
        {
            byte[] encodedBytes = Encoding.UTF8.GetBytes(password);
            string base64EncodedText = Convert.ToBase64String(encodedBytes);
            return base64EncodedText;
        }

        /// <summary>
        /// Decrypt the password to base 64 string
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecryptToBase64(this string password)
        {
            byte[] encodedBytes = Convert.FromBase64String(password);
            string plainText = Encoding.UTF8.GetString(encodedBytes);
            return plainText;
        }
    }
}
