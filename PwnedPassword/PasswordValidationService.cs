using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PwnedPassword
{
    public class PasswordValidationService
    {
        private static string url = "https://api.pwnedpasswords.com/range/";
        //private static string userAgent = "DBate";
        private static readonly HttpClient httpClient = new HttpClient();

        public PasswordValidationService()
        {

        }

        public async Task<String> CheckPassword(string prefix)
        {
            Uri uri = new Uri(url + prefix);
            HttpRequestMessage pwnedRequest = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage pwnedResponse = null;

            try
            {
                pwnedResponse = await httpClient.SendAsync(pwnedRequest);
                pwnedResponse.EnsureSuccessStatusCode();

                string responseHashList = await pwnedResponse.Content.ReadAsStringAsync();
                return responseHashList;

            }
            catch (HttpRequestException re)
            {
                //Console.WriteLine()
                return null;

            }
        }
    }
}
