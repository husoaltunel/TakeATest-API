using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Hashing.Abstract
{
    public interface IHashingHelper
    {
        public string GeneratePasswordSalt();
        public string GeneratePasswordHash(string password, string passwordSalt);
        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt);
    }
}
