using KFC.Red.ServiceLayer.Token.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.Token
{
    public class TokenService : IToken
    {
        public string GenerateToken()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] b = new byte[64 / 2];
            provider.GetBytes(b);
            string hex = BitConverter.ToString(b).Replace("-", "");
            return hex;
        }
    }
}
