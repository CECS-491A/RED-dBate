using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Password
{
    public class PasswordValidationService
    {
        private static string url = "https://api.pwnedpasswords.com/range/";
        private static readonly HttpClient httpClient = new HttpClient();

        public PasswordValidationService()
        {

        }

        /// <summary>
        /// Will make a request to the pwned passwords api in order to receive passwords  that start with the prefix and their ranges.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns>A Task<String> that contains all hashed passwords that start with the prefix along with their count. </String></returns>
        public async Task<String> FindPassword(string prefix)
        {
            //The prefix is added to the end of the url in order to make request to pwned passwords api.
            Uri uri = new Uri(url + prefix);

            //create both HTTP request and response messages
            HttpRequestMessage pwnedRequest = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage pwnedResponse = null;

            try
            {
                //Make request to pwned passwords api.
                pwnedResponse = await httpClient.SendAsync(pwnedRequest);
                pwnedResponse.EnsureSuccessStatusCode();

                //Convert response from pwned passwords into a Task<String> and return it.
                string responseHashList = await pwnedResponse.Content.ReadAsStringAsync();
                return responseHashList;

            }
            catch (HttpRequestException httpRequestError)
            {
                Console.WriteLine("Error: " + httpRequestError);
                return null;

            }
        }
    }
}
