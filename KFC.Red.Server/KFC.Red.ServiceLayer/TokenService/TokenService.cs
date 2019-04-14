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
        private const string APISecret = "E81193660735AD71930C067694EE1B7EE018C8F28FDCB369F0153CF34B6456B8";

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
