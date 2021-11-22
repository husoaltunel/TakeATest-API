using Core.Utilities.Hashing.Abstract;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Hashing
{
    public class HashingHelper : IHashingHelper
    {

        public string GeneratePasswordSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[1024];

            rng.GetBytes(buffer);
            return BitConverter.ToString(buffer);


        }
        public string GeneratePasswordHash(string password, string passwordSalt)
        {
            var hash = new StringBuilder(); ;
            byte[] passwordSaltBytes = Encoding.UTF8.GetBytes(passwordSalt);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            using (var hmac = new HMACSHA512(passwordSaltBytes))
            {
                byte[] hashValue = hmac.ComputeHash(passwordBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            return passwordHash == GeneratePasswordHash(password, passwordSalt);
        }

    }
}
