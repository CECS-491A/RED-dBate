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
        private const string APISecret = "B5B9F1B7B083546AE82BD0A57FB916341C3AF4A2A430EF4DE15B4FF813171DD6";

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
