using System.Collections.Generic;
using System.Threading.Tasks;
using HaveIBeenPwned.Model;
using RestSharp;

namespace HaveIBeenPwned.Client
{
    public partial class HaveIBeenPwnedClient
    {
        private const string BREACH_RESOURCE = "breach";
        private const string BREACHES_RESOURCE = "breaches";
        private const string BREACH_ACCOUNT_RESOURCE = "breachedaccount";

        public async Task<Breach> GetBreach(string site)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"{BREACH_RESOURCE}/{site}";
            return await ExecuteTaskAsync<Breach>(request);
        }

        public async Task<List<Breach>> GetAllBreaches()
        {
            RestRequest request = new RestRequest(Method.GET);
            request.Resource = $"{BREACHES_RESOURCE}";
            return await ExecuteTaskAsync<List<Breach>>(request);
        }

        public async Task<List<Breach>> GetAccountBreaches(string account, bool? includeUnverified = false)
        {
            RestRequest request = new RestRequest(Method.GET);
            string includeUnverifiedQueryString = string.Empty;
            if (includeUnverified.HasValue && includeUnverified.Value)
            {
                includeUnverifiedQueryString = "?includeUnverified=true";
            }

            request.Resource = $"{BREACH_ACCOUNT_RESOURCE}/{account}{includeUnverifiedQueryString}";
            return await ExecuteTaskAsync<List<Breach>>(request);
        }
    }
}