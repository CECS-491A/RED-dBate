using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KFC.Red.ServiceLayer.SSO_Services
{
    public class SignatureService
    {
        public bool IsValidClientRequest(string userId, string email, long timestamp, string signature)
        {
            // Dictionary represents the signed body of the request to the destination server
            // Props can be added to this, and they will be added to signature
            var payload = PreparePayload(userId, email, timestamp);
            var generatedSignature = Sign(payload);
            return generatedSignature == signature;
        }

        public Dictionary<string, string> PreparePayload(string userId, string email, long timestamp)
        {
            var preparedPayload = new Dictionary<string, string>();
            preparedPayload.Add("ssoUserId", userId);
            preparedPayload.Add("email", email);
            preparedPayload.Add("timestamp", timestamp.ToString());
            return preparedPayload;
        }

        // Signs a dictionary with the provided key by constructing a key/value string
        public string Sign(Dictionary<string, string> payload)
        {
            // Order the provided dictionary by key
            // This is necessary so that the recipient of the payload will be able to generate the
            // correct hash even if the order changes
            var orderedPayload = from payloadItem in payload
                                 orderby payloadItem.Value descending
                                 select payloadItem;

            var payloadString = "";
            // Build a payload string with the format:
            // key =value;key2=value2;
            // SECURITY: This must be passed in this format so that the resulting hash is the same
            foreach (var pair in orderedPayload)
            {
                payloadString = payloadString + pair.Key + "=" + pair.Value + ";";
            }

            var signature = Sign(payloadString);
            return signature;
        }

        // Signs a string with the provided key
        public string Sign(string payloadString)
        {
            // Instantiate a new hashing algorithm with the provided key
            HMACSHA256 hashingAlg = new HMACSHA256(Encoding.ASCII.GetBytes(SSO_APIService.APISecret));

            // Get the raw bytes from our payload string
            byte[] payloadBuffer = Encoding.ASCII.GetBytes(payloadString);

            // Calculate our hash from the byte array
            byte[] signatureBytes = hashingAlg.ComputeHash(payloadBuffer);

            var signature = Convert.ToBase64String(signatureBytes);
            return signature;
        }
    }
}
