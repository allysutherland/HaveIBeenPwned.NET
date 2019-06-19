using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace HaveIBeenPwned.Client
{
    public partial class HaveIBeenPwnedClient
    {
        private const string PASSWORD_RESOURCE = "range";

        private readonly RestClient _clientPassword = new RestClient
        {
            BaseUrl = new Uri("https://api.pwnedpasswords.com"),
            Timeout = TIMEOUT_MS
        };

        public async Task<bool> IsPasswordPwned(string password)
        {
            // compute the SHA1 hash of the password
            SHA1 sha1 = SHA1.Create();
            byte[] byteString = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha1.ComputeHash(byteString);
            string hashString = "";
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("X2"));
            }

            hashString = sb.ToString();

            // break the SHA1 into two pieces
            string hashFirstFive = hashString.Substring(0, 5);
            string hashLeftover = hashString.Substring(5, hashString.Length - 5);

            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"{PASSWORD_RESOURCE}/{hashFirstFive}";
            StringBuilder response = await ExecuteTaskAsync(request);

            return response != null && response.ToString().Contains(hashLeftover);
        }

        private async Task<StringBuilder> ExecuteTaskAsync(IRestRequest request)
        {
            IRestResponse<StringBuilder> response = await _clientPassword.ExecuteTaskAsync<StringBuilder>(request);
            return new StringBuilder(response.Content);
        }
    }
}