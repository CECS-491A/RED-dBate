using KFC.Red.DataAccessLayer.Models;
using KFC.RED.DataAccessLayer.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.SSO_Services
{
    public class SSO_APIService
    {
        const string API_URL = "http://localhost:5000";
        const string APP_ID = "3c3a7801-4596-47d9-85fd-3bf4925314e5";
        public static readonly string APISecret = "EFC25900C13CFFD65B648E5F88C17B0A859E919669E627464F8614CC6CC74D96";

        public async Task<HttpResponseMessage> DeleteUserFromSSO(User user)
        {
            var auth = new SignatureService();
            var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var payloadToSign = auth.PreparePayload(user.SsoId.ToString(), user.Email, timestamp);
            var signature = auth.Sign(payloadToSign);
            var requestPayload = new DeleteUserFromSSO_DTO
            {
                AppId = APP_ID,
                Email = user.Username,
                SsoUserId = user.SsoId.ToString(),
                Timestamp = timestamp,
                Signature = signature
            };
            var response = await PingDeleteUserFromSSORouteAsync(requestPayload);
            if (response.IsSuccessStatusCode)
            {
                return response;
            }
            throw new Exception("Delete User from SSO request error.");
        }

        public async Task<HttpResponseMessage> PingDeleteUserFromSSORouteAsync(DeleteUserFromSSO_DTO payload)
        {
            HttpClient client = new HttpClient();
            var stringPayload = JsonConvert.SerializeObject(payload);
            var jsonPayload = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var request = await client.PostAsync(API_URL + "/api/users/appdeleteuser", jsonPayload);
            return request;
        }
    }
}
