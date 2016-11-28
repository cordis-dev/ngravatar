using System;
using System.Text;
using System.Security.Cryptography;

namespace NGravatar
{
    internal class GravatarHasher
    {
        public static string Hash(string emailAddress)
        {
            if (null == emailAddress)
                throw new ArgumentNullException("emailAddress");

            emailAddress = emailAddress.Trim().ToLower();

            var bytes = Encoding.UTF8.GetBytes(emailAddress);
            byte[] hashedBytes;
            using (var provider = new MD5CryptoServiceProvider())
            {
                hashedBytes = provider.ComputeHash(bytes);
            }
            var length = hashedBytes.Length;
            var stringBuilder = new StringBuilder(length * 2);

            for (var i = 0; i < length; i++)
            {
                stringBuilder.Append(hashedBytes[i].ToString("X2"));
            }

            return stringBuilder.ToString().ToLower();
        }
    }
}
