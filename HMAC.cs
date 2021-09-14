using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleAppGame
{
    class HMAC
    {
        public string input;
        private byte[] secretKey = new Byte[128];
        public HMAC(string Input)
        {
            input = Input;
        }
        private void MakeKey()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(secretKey);
            }
        }
        public void PrintKey()
        {
            Console.WriteLine($"HMAC Key: {Convert.ToBase64String(secretKey)}");
        }
        public void Sign()
        {
            MakeKey();
            byte[] hashValue = new Byte[128];
            byte[] stringByte = System.Text.Encoding.UTF8.GetBytes(input);

            using (HMACSHA384 hman = new HMACSHA384(secretKey))
            {
                hashValue = hman.ComputeHash(stringByte);
            }
            
            Console.WriteLine($"HMAC: {Convert.ToBase64String(hashValue)}");
            
        }

    }
}
