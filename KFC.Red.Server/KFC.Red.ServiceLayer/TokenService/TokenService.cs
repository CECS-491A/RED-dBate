using KFC.Red.ServiceLayer.TokenService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.TokenService
{
    public class TokenService : IToken
    {
        private const string APISecret = "55083F27BBAE9685079F170BD0B9C418E09ABB90EA0AB92D406A94F13ADA4A4F";

        public string GenerateSignature(string text)
        {
            HMACSHA256 hmacsha1 = new HMACSHA256(Encoding.ASCII.GetBytes(APISecret));
            byte[] SignatureBuffer = Encoding.ASCII.GetBytes(text);
            byte[] signatureBytes = hmacsha1.ComputeHash(SignatureBuffer);
            return Convert.ToBase64String(signatureBytes);
        }

        public string GenerateToken()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] b = new byte[64 / 2];
            provider.GetBytes(b);
            string hex = BitConverter.ToString(b).Replace("-", "");
            return hex;
        }

        public bool isValidSignature(string preSig, string sig)
        {
            return GenerateSignature(preSig) == sig;
        }
    }
}
