using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.TokenService.Interface
{
    public interface IToken
    {
        string GenerateToken();
        bool isValidSignature(string preSig, string sig);
        string GenerateSignature(string text);
    }
}
