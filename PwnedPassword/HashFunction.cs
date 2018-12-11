using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PwnedPassword
{
    class HashFunction
    {
        /// <summary>
        /// Converts the password into bytes, hashes it, then formats it to uppercase hexadecimal.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>The hashed password</returns>
        public string StringHash(string password)
        {
            //Uses sha1 hash function to create hash of the password in bytes
            SHA1 sha = SHA1.Create();
            byte[] byteHash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            string stringHash = "";
            StringBuilder sb = new StringBuilder();

            //Formats bytes into uppercase hexadecimal characters and appends to stringbuilder
            for (int i = 0; i < byteHash.Length; i++)
            {
                sb.Append(byteHash[i].ToString("X2"));
            }
            stringHash = sb.ToString(); //Converts stringbuilder into string

            return stringHash;
        }
    }
}
