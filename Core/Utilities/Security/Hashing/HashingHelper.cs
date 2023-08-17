using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt)) //o şifrenin üretildiği key'i veriyoruz
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // verdiğimiz key'e göre gelen şifreyi tekrar hashliyoruz
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) //burdada db'den gelen hash ile oluşturduğumuz hash'i karşılaştırıyoruz.
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
